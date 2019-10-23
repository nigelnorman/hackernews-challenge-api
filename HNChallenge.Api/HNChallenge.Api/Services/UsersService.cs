using HNChallenge.Api.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HNChallenge.Api.Services
{
    public class UsersService
    {
        private const string hackerNewsApiUri = "https://hacker-news.firebaseio.com/v0";

        public UsersService() { }

        public HackerNewsUser GetUserById(string id)
        {
            var uri = $"{hackerNewsApiUri}/user/{id}.json";

            var request = WebRequest.Create(uri);
            request.Method = "GET";

            var response = request.GetResponse();

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                var user = JsonConvert.DeserializeObject<HackerNewsUser>(result);

                return user;
            }
        }
    }
}
