using HNChallenge.Api.Entities;
using HNChallenge.Api.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

//TODO

namespace HNChallenge.Api.Tests.Items
{
    public class ItemsServiceTests
    {
        private readonly ItemsService itemsService;

        public ItemsServiceTests()
        {
            var usersServiceDependency = new UsersService();
            this.itemsService = new ItemsService(usersServiceDependency);
        }

        [Fact]
        public void GetItemById_success()
        {
            const int itemId = 42;

            var item = this.itemsService.GetItemById(itemId);

            var expectedItem = new HackerNewsItem
            {
                Id = 42,
                Type = "story",
                Title = "An alternative to VC: &#34;Selling In&#34;",
                By = "sergei",
                Url = "http://www.venturebeat.com/contributors/2006/10/10/an-alternative-to-vc-selling-in/"
            };

            Assert.NotNull(item);
            Assert.Equal(item.Url, expectedItem.Url);
            Assert.Equal(item.By, expectedItem.By);
        }
    }
}
