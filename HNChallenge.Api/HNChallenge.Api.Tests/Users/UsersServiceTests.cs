using HNChallenge.Api.Entities;
using HNChallenge.Api.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HNChallenge.Api.Tests.Given_ItemsService_and_no_data
{
    public class UsersServiceTests
    {
        private readonly UsersService usersService;

        public UsersServiceTests()
        {
            this.usersService = new UsersService();
        }

        [Fact]
        public void GetUserById_success()
        {
            // oui, c'est moi
            const string userId = "nsquared";

            var user = this.usersService.GetUserById(userId);

            Assert.NotNull(user);
        }

    }
}
