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

        public async Task<HackerNewsItem> GetItemById(int id)
        {
            var uri = $"{hackerNewsApiUri}/item/{id}.json";

            var response = await this.GetResponseStreamString(uri);

            var item = JsonConvert.DeserializeObject<HackerNewsItem>(response);

            return item;
        }

        public async Task<IEnumerable<HackerNewsItem>> GetTopItems(int page)
        {
            var uri = $"{hackerNewsApiUri}/topstories.json";

            var response = await this.GetResponseStreamString(uri);

            var itemIds = JsonConvert.DeserializeObject<List<int>>(response);

            return await this.GetFullItems(itemIds.Skip(page * 10).Take(10));
        }

        public async Task<IEnumerable<HackerNewsItem>> GetNewItems(int page)
        {
            var uri = $"{hackerNewsApiUri}/newstories.json";

            var response = await this.GetResponseStreamString(uri);

            var itemIds = JsonConvert.DeserializeObject<List<int>>(response);

            return await this.GetFullItems(itemIds.Skip(page * 10).Take(10));
        }

        public async Task<IEnumerable<HackerNewsItem>> GetBestItems(int page)
        {
            var uri = $"{hackerNewsApiUri}/beststories.json";

            var response = await this.GetResponseStreamString(uri);

            var itemIds = JsonConvert.DeserializeObject<List<int>>(response);

            return await this.GetFullItems(itemIds.Skip(page * 10).Take(10));
        }

        private async Task<IEnumerable<HackerNewsItem>> GetFullItems(IEnumerable<int> itemIds)
        {
            var items = new List<HackerNewsItem>();

            foreach (var id in itemIds)
            {
                var item = await this.GetItemById(id);

                if (item == null)
                {
                    continue;
                }
                items.Add(item);
            }

            return items;
        }

        private async Task<string> GetResponseStreamString(string uri)
        {
            var request = WebRequest.Create(uri);
            request.Method = "GET";

            var response = await request.GetResponseAsync();

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = await streamReader.ReadToEndAsync();

                return result;
            }
        }
    }
}
