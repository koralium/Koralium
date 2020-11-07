﻿/*
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

namespace Koralium.WebTests.Entities
{
    public class Company
    {
        public string CompanyId { get; set; }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Company other)
            {
                return CompanyId == other.CompanyId &&
                    Name == other.Name;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CompanyId, Name);
        }
    }
}
