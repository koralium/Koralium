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

namespace Koralium.Data.ArrowFlight.Decoders
{
    class EnumDecoder : StringDecoder
    {
        public override string GetDataTypeName()
        {
            return "enum";
        }

        public override Type GetFieldType()
        {
            return typeof(string);
        }

        public override object GetFieldValue(in int index, Type type)
        {
            if (type.IsEnum && Enum.TryParse(type, GetString(index), out var enumValue))
            {
                return enumValue;
            }
            return base.GetFieldValue(index, type);
        }
    }
}
