using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DAL;
using Service;

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
        public IHttpActionResult Post([FromBody]tblQuote quote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data input");
            }
            qs.insert(quote);
            return Ok();
        }

        // PUT api/values/5
        public IHttpActionResult Put(int id, [FromBody]tblQuote quote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data input");
            }
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
