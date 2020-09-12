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
package io.prestosql.plugin.grpc.decoders;

import io.prestosql.plugin.grpc.GrpcExecutionColumn;
import io.prestosql.plugin.grpc.Presto;
import io.prestosql.spi.block.BlockBuilder;
import io.prestosql.spi.connector.ConnectorSession;

import java.util.List;

import static io.prestosql.spi.type.RealType.REAL;

public class FloatDecoder
        implements GrpcDecoder
{
    private int count;
    private int globalCount;
    private int nullCounter;

    @Override
    public GrpcDecoder create(int columnId, GrpcExecutionColumn column, ConnectorSession session)
    {
        return new FloatDecoder();
    }

    @Override
    public int decode(Presto.Block block, BlockBuilder builder, Presto.Page page)
    {
        List<Integer> nulls = block.getNullsList();
        List<Float> floats = block.getFloats().getValuesList();

        while (nulls.size() > nullCounter || floats.size() > count) {
            //Check null list if there are elements left
            if (nulls.size() > nullCounter) {
                if (nulls.get(nullCounter) == globalCount) {
                    builder.appendNull();
                    nullCounter++;
                    globalCount++;
                    continue;
                }
            }
            if (floats.size() > count) {
                REAL.writeLong(builder, Float.floatToRawIntBits(floats.get(count)));
                count++;
                globalCount++;
            }
        }
        return globalCount;
    }

    @Override
    public int decode(Presto.Block block, BlockBuilder builder, Presto.Page page, int numberOfElements)
    {
        List<Integer> nulls = block.getNullsList();
        List<Float> floats = block.getFloats().getValuesList();

        int localCount = 0;
        while ((nulls.size() > nullCounter || floats.size() > count) && numberOfElements > localCount) {
            //Check null list if there are elements left
            if (nulls.size() > nullCounter) {
                if (nulls.get(nullCounter) == globalCount) {
                    builder.appendNull();
                    nullCounter++;
                    globalCount++;
                    localCount++;
                    continue;
                }
            }
            if (floats.size() > count) {
                REAL.writeDouble(builder, Float.floatToRawIntBits(floats.get(count)));
                count++;
                globalCount++;
                localCount++;
            }
        }
        return 0;
    }

    @Override
    public void newPage(Presto.Page page)
    {
        this.count = 0;
        this.globalCount = 0;
        this.nullCounter = 0;
    }
}
