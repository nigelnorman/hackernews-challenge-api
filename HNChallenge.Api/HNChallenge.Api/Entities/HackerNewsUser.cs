using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNChallenge.Api.Entities
{
    public class HackerNewsUser
    {
        public string Id { get; set; }

        public int Delay { get; set; }

        // supposed to be in Unix time
        public int Created { get; set; }

        public int Karma { get; set; }

        public string About { get; set; }

        public ICollection<int> Submitted { get; set; }
    }
}
