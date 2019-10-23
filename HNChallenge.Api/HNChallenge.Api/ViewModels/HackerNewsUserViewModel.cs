using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace HNChallenge.Api.ViewModels
{
    [DataContract]
    public class HackerNewsUserViewModel
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public int Karma { get; set; }
    }
}
