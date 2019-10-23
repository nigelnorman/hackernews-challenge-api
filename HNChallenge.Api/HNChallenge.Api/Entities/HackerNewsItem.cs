using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNChallenge.Api.Entities
{
    public class HackerNewsItem
    {
        public int Id { get; set; }

        // my gut tells me I want to use an enum for this
        // for reliability with comparisons in the client
        // but we'll see ...
        public string Type { get; set; }

        public string Title { get; set; }

        public string By { get; set; }

        // supposed to be in Unix time
        public int Time { get; set; }

        public string Text { get; set; }

        public int? Parent { get; set; }

        public ICollection<int> Kids { get; set; }

        public ICollection<int> Parts { get; set; }

        public int? Poll { get; set; }

        public string Url { get; set; }

        public int Score { get; set; }

        public int? Descendants { get; set; }

        public bool Dead { get; set; }

        public bool Deleted { get; set; }
    }
}
