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
    /// instead of rolling my own, but the reason why I'm making 
    /// this a separate service is to keep my controller methods
    /// as light-weight as possible.
    /// </summary>
    public class ObjectMappingService
    {
        private readonly UsersService usersService;

        public ObjectMappingService(UsersService usersService)
        {
            this.usersService = usersService;
        }

        public HackerNewsItemViewModel Map(HackerNewsItem item)
        {
            var author = this.usersService.GetUserById(item.By);

            return new HackerNewsItemViewModel
            {
                Score = item.Score,
                By = author != null ? Map(this.usersService.GetUserById(item.By)) : new HackerNewsUserViewModel { Id = "anonymous user", Karma = -1 },
                Title = item.Title,
                Text = item.Text,
                Url = item.Url
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
