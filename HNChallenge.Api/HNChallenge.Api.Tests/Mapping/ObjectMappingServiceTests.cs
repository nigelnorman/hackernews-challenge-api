using HNChallenge.Api.Services;
using HNChallenge.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HNChallenge.Api.Tests.Mapping
{
    public class ObjectMappingServiceTests
    {
        private readonly ObjectMappingService mapper;
        private readonly UsersService usersService;
        private readonly ItemsService itemsService;

        public ObjectMappingServiceTests()
        {
            this.usersService = new UsersService();
            this.itemsService = new ItemsService(this.usersService);
            this.mapper = new ObjectMappingService(this.usersService);
        }

        [Fact]
        public void UserMapsToViewModel_success()
        {
            var userId = "nsquared";
            var user = Task.Run(async () => await this.usersService.GetUserById(userId).ConfigureAwait(false)).Result;
            var userVm = this.mapper.Map(user);

            var expectedVm = new HackerNewsUserViewModel
            {
                Id = "nsquared",
                Karma = 2
            };

            Assert.NotNull(userVm);
            Assert.Equal(userVm.Id, expectedVm.Id);
            Assert.Equal(userVm.Karma, expectedVm.Karma);
        }

        [Fact]
        public void ItemMapsToViewModel_success()
        {
            var itemId = 42;
            var item = Task.Run(async () => await this.itemsService.GetItemById(itemId).ConfigureAwait(false)).Result;
            var itemVm = Task.Run(async () => await this.mapper.Map(item).ConfigureAwait(false)).Result;

            var expectedItemVm = new HackerNewsItemViewModel
            {
                Id = 42,
                Type = "story",
                Title = "An alternative to VC: &#34;Selling In&#34;",
                Url = "http://www.venturebeat.com/contributors/2006/10/10/an-alternative-to-vc-selling-in/"
            };

            Assert.NotNull(itemVm);
            Assert.Equal(itemVm.Title, expectedItemVm.Title);
            Assert.Equal(itemVm.Url, expectedItemVm.Url);
        }

        [Fact]
        public void ItemViewModelHasMappedUserViewModel_success()
        {
            var itemId = 42;
            var item = Task.Run(async () => await this.itemsService.GetItemById(itemId).ConfigureAwait(false)).Result;
            var itemVm = Task.Run(async () => await this.mapper.Map(item).ConfigureAwait(false)).Result;

            var expectedItemVm = new HackerNewsItemViewModel
            {
                Id = 42,
                Type = "story",
                Title = "An alternative to VC: &#34;Selling In&#34;",
                By = new HackerNewsUserViewModel
                {
                    Id = "sergei"
                },
                Url = "http://www.venturebeat.com/contributors/2006/10/10/an-alternative-to-vc-selling-in/"
            };

            Assert.NotNull(itemVm.By);
            Assert.Equal(itemVm.By.Id, expectedItemVm.By.Id);
        }
    }
}
