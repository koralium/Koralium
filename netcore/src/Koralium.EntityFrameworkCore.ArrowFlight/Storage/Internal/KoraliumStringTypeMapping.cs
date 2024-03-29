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
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace Koralium.EntityFrameworkCore.ArrowFlight.Storage.Internal
{
    public class KoraliumStringTypeMapping : StringTypeMapping
    {
        public KoraliumStringTypeMapping(string storeType, DbType? dbType = null, bool unicode = false, int? size = null) : base(storeType, dbType, unicode, size)
        {
        }

        protected KoraliumStringTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
        {
        }
    }
}
