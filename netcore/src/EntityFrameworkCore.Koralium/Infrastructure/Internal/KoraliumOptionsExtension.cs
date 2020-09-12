using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Koralium.Infrastructure.Internal
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
