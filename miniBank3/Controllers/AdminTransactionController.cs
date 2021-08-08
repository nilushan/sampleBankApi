using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using miniBank3.Controllers.entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace miniBank3.Controllers
{
    [Route("api/admin/[controller]")]
    public class AdminTransactionController : Controller
    {
        // GET: api/values
        [HttpGet]
        [Produces( MediaTypeNames.Application.Json )]
        public IEnumerable<ApiTransaction> Get()
        {
            ApiCustomer owner = new ApiCustomer
            {
                Id = "testCustomerID",
                Name = "testCustomerName"
            };

            return Enumerable.Range(1, 5).Select(index => new ApiTransaction
            {
                Owner = owner

            }).ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
