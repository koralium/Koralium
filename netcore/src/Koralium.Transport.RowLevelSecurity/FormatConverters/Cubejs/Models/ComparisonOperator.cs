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
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Koralium.Transport.RowLevelSecurity.FormatConverters.Cubejs.Models
{
    enum ComparisonOperator
    {
        Equals = 0,
        NotEquals = 1,
        Contains = 2,
        NotContains = 3,
        GreaterThan = 4,
        GreaterThanOrEqual = 5,
        LessThan = 6,
        LessThanOrEqual = 7,
        Set = 8,
        NotSet = 9,
        InDateRange = 10,
        NotInDateRange = 11,
        BeforeDate = 12,
        AfterDate = 13
    }
}
