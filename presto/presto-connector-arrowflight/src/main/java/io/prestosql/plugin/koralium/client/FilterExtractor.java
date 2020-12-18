/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
package io.prestosql.plugin.koralium.client;

import com.google.common.base.Joiner;
import com.google.common.base.VerifyException;
import com.google.common.collect.ImmutableList;
import io.prestosql.plugin.koralium.KoraliumPrestoColumn;
import io.prestosql.plugin.koralium.KoraliumType;
import io.prestosql.spi.connector.ConnectorSession;
import io.prestosql.spi.predicate.Domain;
import io.prestosql.spi.predicate.Range;
import io.prestosql.spi.predicate.TupleDomain;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

import static com.google.common.base.Preconditions.checkArgument;
import static com.google.common.base.Preconditions.checkState;

public final class FilterExtractor
{
    private FilterExtractor() {}

    public static String getFilter(ConnectorSession session, TupleDomain<KoraliumPrestoColumn> constraint)
    {
        ImmutableList.Builder<String> predicates = ImmutableList.builder();

        if (constraint.getDomains().isPresent()) {
            for (Map.Entry<KoraliumPrestoColumn, Domain> entry : constraint.getDomains().get().entrySet()) {
                KoraliumPrestoColumn column = entry.getKey();
                Domain domain = entry.getValue();

                checkArgument(!domain.isNone(), "Unexpected NONE domain for %s", column.getColumnName());
                if (!domain.isAll()) {
                    String predicate = "(" + buildPredicate(session, domain, column) + ")";
                    if (predicate != null) {
                        predicates.add(predicate);
                    }
                }
            }
        }
        return Joiner.on(" AND ").join(predicates.build());
    }

    private static String buildPredicate(ConnectorSession session, Domain domain, KoraliumPrestoColumn column)
    {
        if (domain.getValues().isNone()) {
            return column.getColumnName() + " IS NULL";
        }

        if (domain.getValues().isAll()) {
            return column.getColumnName() + " IS NOT NULL";
        }

        return buildRangeQuery(session, domain, column);
    }

    private static String buildRangeQuery(ConnectorSession session, Domain domain, KoraliumPrestoColumn column)
    {
        KoraliumType.ToStringConverter converter = column.getKoraliumType().GetConverter();
        //IEncoder typeConverter = column.getKoraliumType().getEncoder();
        String columnName = column.getColumnName();
        String predicateString = domain.getValues().getValuesProcessor().transform(
                ranges -> {
                    List<Object> singleValues = new ArrayList<>();
                    List<String> rangeConjuncts = new ArrayList<>();

                    for (Range range : ranges.getOrderedRanges()) {
                        checkState(!range.isAll(), "Invalid range for column: " + column.getColumnName());

                        if (range.isSingleValue()) {
                            singleValues.add(converter.convertToString(range.getSingleValue()));
                        }
                        else {
                            List<String> innerRangeConjucts = new ArrayList<>();
                            if (!range.getLow().isLowerUnbounded()) {
                                String lowBound = converter.convertToString(range.getLow().getValue());
                                switch (range.getLow().getBound()) {
                                    case ABOVE:
                                        innerRangeConjucts.add(columnName + " > " + lowBound);
                                        break;
                                    case EXACTLY:
                                        innerRangeConjucts.add(columnName + " >= " + lowBound);
                                        break;
                                    case BELOW:
                                        throw new VerifyException("Low Marker should never use BELOW bound");
                                    default:
                                        throw new AssertionError("Unhandled bound: " + range.getLow().getBound());
                                }
                            }
                            if (!range.getHigh().isUpperUnbounded()) {
                                String highBound = converter.convertToString(range.getHigh().getValue());
                                switch (range.getHigh().getBound()) {
                                    case ABOVE:
                                        throw new VerifyException("High Marker should never use ABOVE bound");
                                    case EXACTLY:
                                        innerRangeConjucts.add(columnName + " <= " + highBound);
                                        break;
                                    case BELOW:
                                        innerRangeConjucts.add(columnName + " < " + highBound);
                                        break;
                                    default:
                                        throw new AssertionError("Unhandled bound: " + range.getHigh().getBound());
                                }
                            }
                            rangeConjuncts.add(Joiner.on(" AND ").join(innerRangeConjucts));
                        }
                    }

                    String singlePredicate = null;
                    if (!singleValues.isEmpty()) {
                        List<String> equalStatements = singleValues.stream()
                                .map(x -> columnName + " = " + x)
                                .collect(Collectors.toList());

                        singlePredicate = Joiner.on(" OR ").join(equalStatements);
                    }

                    String rangePredicate = null;
                    if (!rangeConjuncts.isEmpty()) {
                        rangePredicate = Joiner.on(" OR ").join(rangeConjuncts);
                    }

                    if (singlePredicate != null && rangePredicate != null) {
                        return singlePredicate + " OR " + rangePredicate;
                    }
                    if (singlePredicate != null) {
                        return singlePredicate;
                    }
                    if (rangePredicate != null) {
                        return rangePredicate;
                    }

                    return null;
                },
                discreteValues -> {
                    if (discreteValues.isInclusive()) {
                        ImmutableList.Builder<Object> discreteValuesList = ImmutableList.builder();
                        for (Object discreteValue : discreteValues.getValues()) {
                            discreteValuesList.add(discreteValue);
                        }
                        String predicate = columnName + " in ("
                                + Joiner.on(",").join(discreteValuesList.build()) + ")";
                        return predicate;
                    }
                    return null;
                },
                allOrNone -> {
                    return null;
                });

        return predicateString;
    }
}
