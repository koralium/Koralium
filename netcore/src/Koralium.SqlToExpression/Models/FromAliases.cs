using System.Collections.Generic;

namespace Koralium.SqlToExpression.Models
{
    internal class FromAliases
    {
        private HashSet<string> _aliases = new HashSet<string>();

        public void AddAlias(string alias)
        {
            _aliases.Add(alias.ToLower());
        }

        public bool AliasExists(string alias)
        {
            return _aliases.Contains(alias.ToLower());
        }

        public void Clear()
        {
            _aliases.Clear();
        }

        public IEnumerable<string> Aliases => _aliases;
    }
}
