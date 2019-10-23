using HNChallenge.Api.Entities;
using HNChallenge.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNChallenge.Api.Services
{
    /// <summary>
    /// Normally I would probably employ something like AutoMapper 
    /// instead of rolling by own, but the reason why I'm making 
    /// this a separate service is to keep my controller methods
    /// as light-weight as possible.
    /// </summary>
    public class ObjectMappingService
    {
        public ObjectMappingService() { }

        public HackerNewsItemViewModel Map(HackerNewsItem item)
        {
            return new HackerNewsItemViewModel
            {
                Id = item.Id,
                Type = item.Type,

            };
        }

        public HackerNewsUserViewModel Map(HackerNewsUser user)
        {
            return new HackerNewsUserViewModel
            {
                Id = user.Id,
                Karma = user.Karma
            };
        }
    }
}
