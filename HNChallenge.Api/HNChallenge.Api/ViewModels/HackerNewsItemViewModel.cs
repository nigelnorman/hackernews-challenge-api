using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace HNChallenge.Api.ViewModels
{
    [DataContract]
    public class HackerNewsItemViewModel
    {
        [DataMember]
        public int Id { get; set; }

        // my gut tells me I want to use an enum for this
        // for reliability with comparisons in the client
        // but if we aren't using swagger, then the point
        // is likely moot.
        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public HackerNewsUserViewModel By { get; set; }

        [DataMember]
        // supposed to be in Unix time
        public int Time { get; set; }

        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public int? Poll { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public int Score { get; set; }

        [DataMember]
        public bool Dead { get; set; }

        [DataMember]
        public bool Deleted { get; set; }
    }
}
