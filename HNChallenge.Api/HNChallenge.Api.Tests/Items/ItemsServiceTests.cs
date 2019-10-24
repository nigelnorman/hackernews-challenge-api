using HNChallenge.Api.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

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
            const int itemId = 666;

            var item = this.itemsService.GetItemById(itemId);

            Assert.NotNull(item);
        }
    }
}
