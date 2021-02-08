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
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;

namespace Koralium.EntityFrameworkCore.ArrowFlight.Infrastructure.Internal
{
    public class KoraliumOptionsExtension : RelationalOptionsExtension
    {
        private DbContextOptionsExtensionInfo _info;

        public KoraliumOptionsExtension() { }

        public KoraliumOptionsExtension(KoraliumOptionsExtension cpy)
        {

        }

        public override DbContextOptionsExtensionInfo Info
        {
            get
            {
                if (_info == null)
                {
                    _info = new ExtensionInfo(this);
                }
                return _info;
            }
        }

        public override void ApplyServices(IServiceCollection services)
        {
            services.AddEntityFrameworkKoralium();
        }

        protected override RelationalOptionsExtension Clone()
        {
            return new KoraliumOptionsExtension(this);
        }

        private sealed class ExtensionInfo : RelationalExtensionInfo
        {
            private string _logFragment;

            public ExtensionInfo(IDbContextOptionsExtension extension)
                : base(extension)
            {
            }

            private new KoraliumOptionsExtension Extension
                => (KoraliumOptionsExtension)base.Extension;

            public override bool IsDatabaseProvider => true;

            public override string LogFragment
            {
                get
                {
                    if (_logFragment == null)
                    {
                        var builder = new StringBuilder();

                        builder.Append(base.LogFragment);

                        _logFragment = builder.ToString();
                    }

                    return _logFragment;
                }
            }

            public override void PopulateDebugInfo(IDictionary<string, string> debugInfo)
                => debugInfo["Koralium"] = "1";
        }
    }
}
