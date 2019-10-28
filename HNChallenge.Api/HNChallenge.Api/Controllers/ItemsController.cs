using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HNChallenge.Api.Entities;
using HNChallenge.Api.Services;
using HNChallenge.Api.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HNChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    ///<summary></summary>

    public class ItemsController : ControllerBase
    {
        private readonly ItemsService itemsService;
        private readonly UsersService usersService;
        private readonly ObjectMappingService mapper;

        public ItemsController(ItemsService itemsService, UsersService usersService, ObjectMappingService mapper)
        {
            this.itemsService = itemsService;
            this.usersService = usersService;
            this.mapper = mapper;
        }

        [HttpGet("info")]
        public ActionResult<string> GetInfo()
        {
            return "HackerNews Challenge Application Programming Interface";
        }

        // GET api/items
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "";
        }

        // GET api/items/5
        [HttpGet("{id}")]
        public ActionResult<HackerNewsItem> Get(int id)
        {
            return this.itemsService.GetItemById(id);
        }

        ///<remarks>
        /// In the interest of REST I am leaving these routes
        /// here but not implementing them, as I'm pretty sure
        /// HackerNews won't let me access these resources
        ///</remarks>
        // POST api/items
        [HttpPost]
        public void Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/items/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/items/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        // these guys don't really seem all that RESTful...
        [EnableCors("AllowOrigin")]
        [HttpGet("top")]
        public ActionResult<IEnumerable<HackerNewsItemViewModel>> GetTop([FromQuery] int page)
        {
            var items = this.itemsService.GetTopItems(page == 0 ? page : page - 1);

            return Ok(items.Select(i => mapper.Map(i)));
        }

        [EnableCors("AllowOrigin")]
        [HttpGet("new")]
        public ActionResult<IEnumerable<HackerNewsItemViewModel>> GetNew([FromQuery] int page)
        {
            var items = this.itemsService.GetNewItems(page == 0 ? page : page - 1);

            return Ok(items.Select(i => mapper.Map(i)));
        }

        [EnableCors("AllowOrigin")]
        [HttpGet("best")]
        public ActionResult<IEnumerable<HackerNewsItemViewModel>> GetBest([FromQuery] int page)
        {
            var items = this.itemsService.GetBestItems(page == 0 ? page : page - 1);

            return Ok(items.Select(i => mapper.Map(i)));
        }
    }
}
