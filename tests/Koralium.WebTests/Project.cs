using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.WebTests
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Company Company { get; set; }
    }
}
