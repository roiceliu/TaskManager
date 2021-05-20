using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DAL;
using Service;
using TaskManager.Models;
using TaskManager.Filters;

namespace TaskManager.Controllers
{
    [Authorize]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        QuoteService qs = new QuoteService();
        // GET api/values
        [HttpGet]
        public IEnumerable<tblQuote> Get()
        {
            return qs.GetallQuotes();
        }

        // GET api/values/5
        public tblQuote Get(int id)
        {
            return qs.GetbyID(id);
        }

        // POST api/values
        public IHttpActionResult Post([FromBody]Quote item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data input");
            }
            tblQuote quote = new tblQuote
            {
                QuoteType = item.QuoteType,
                Contact = item.Contact,
                Task = item.Task,
                DueDate = item.DueDate,
                TaskType = item.TaskType
            };

            qs.insert(quote);
            return Ok();
        }

        // PUT api/values/5
        public IHttpActionResult Put(int id, [FromBody]Quote item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data input");
            }

            tblQuote quote = new tblQuote
            {
                QuoteType = item.QuoteType,
                Contact = item.Contact,
                Task = item.Task,
                DueDate = item.DueDate,
                TaskType = item.TaskType
            };

            qs.update(id,quote);
            return Ok();
        }


        // DELETE api/values/5
        public void Delete(int id)
        {
            tblQuote item = Get(id);
            qs.delete(item);
        }
    }
}
