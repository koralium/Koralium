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
namespace Koralium.SqlToExpression.Models
{
    public enum BooleanComparisonType
    {
        //
        // Summary:
        //     The '=' character, equal to.
        Equals = 0,
        //
        // Summary:
        //     The '>' character, greater than.
        GreaterThan = 1,
        //
        // Summary:
        //     The '<' character, less than.
        LessThan = 2,
        //
        // Summary:
        //     The '>' '=' characters, greater than or equal to.
        GreaterThanOrEqualTo = 3,
        //
        // Summary:
        //     The '<' '=' characters, less than or equal to.
        LessThanOrEqualTo = 4,
        //
        // Summary:
        //     The '<' '>' characters, not equal to.
        NotEqualToBrackets = 5,
        //
        // Summary:
        //     The '!' '=' characters, not equal to.
        NotEqualToExclamation = 6,
        //
        // Summary:
        //     The '!' '<' characters, not less than.
        NotLessThan = 7,
        //
        // Summary:
        //     The '!' '>' characters, not greater than.
        NotGreaterThan = 8,
        //
        // Summary:
        //     The '*' '=' characters, left outer join.
        LeftOuterJoin = 9,
        //
        // Summary:
        //     The '=' '*' characters, right outer join.
        RightOuterJoin = 10
    }
}
