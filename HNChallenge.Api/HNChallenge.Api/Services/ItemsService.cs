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
    public class ItemsService
    {
        private const string hackerNewsApiUri = "https://hacker-news.firebaseio.com/v0";

        private readonly UsersService usersService;

        public ItemsService(UsersService usersService)
        {
            this.usersService = usersService;
        }

        public HackerNewsItem GetItemById(int id)
        {
            var uri = $"{hackerNewsApiUri}/item/{id}.json";

            var response = this.GetResponseStreamString(uri);

            var item = JsonConvert.DeserializeObject<HackerNewsItem>(response);

            return item;
        }

        public IEnumerable<HackerNewsItem> GetTopItems(int page)
        {
            var uri = $"{hackerNewsApiUri}/topstories.json";

            var response = this.GetResponseStreamString(uri);

            var itemIds = JsonConvert.DeserializeObject<List<int>>(response);

            return this.GetFullItems(itemIds.Skip(page * 10).Take(10));
        }

        public IEnumerable<HackerNewsItem> GetNewItems(int page)
        {
            var uri = $"{hackerNewsApiUri}/newstories.json";

            var response = this.GetResponseStreamString(uri);

            var itemIds = JsonConvert.DeserializeObject<List<int>>(response);

            return this.GetFullItems(itemIds.Skip(page * 10).Take(10));
        }

        public IEnumerable<HackerNewsItem> GetBestItems(int page)
        {
            var uri = $"{hackerNewsApiUri}/beststories.json";

            var response = this.GetResponseStreamString(uri);

            var itemIds = JsonConvert.DeserializeObject<List<int>>(response);

            return this.GetFullItems(itemIds.Skip(page * 10).Take(10));
        }

        private IEnumerable<HackerNewsItem> GetFullItems(IEnumerable<int> itemIds)
        {
            var items = new List<HackerNewsItem>();

            foreach (var id in itemIds)
            {
                var item = this.GetItemById(id);

                if (item == null)
                {
                    continue;
                }
                items.Add(item);
            }

            return items;
        }

        private string GetResponseStreamString(string uri)
        {
            var request = WebRequest.Create(uri);
            request.Method = "GET";

            var response = request.GetResponse();

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                return result;
            }
        }
    }
}
