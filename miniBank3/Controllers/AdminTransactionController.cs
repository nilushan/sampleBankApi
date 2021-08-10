using System.Collections.Generic;

using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using miniBank3.Controllers.entities;
using miniBank3.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace miniBank3.Controllers
{
    [Route("api/admin/[controller]")]
    public class AdminTransactionController : ControllerBase
    {
        private readonly ITransactionRepository _tranactionRepo;

        public AdminTransactionController(TransactionRepository transactionRepository)
        {
            _tranactionRepo = transactionRepository;
        }

        // GET: api/values
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public IEnumerable<ApiTransaction> Get()
        {
            ApiCustomer owner = new ApiCustomer
            {
                Id = "testCustomerID",
                Name = "testCustomerName"
            };

            var items = _tranactionRepo.GetAllTransactionItems().Result;
            return items;

        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetID")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiTransaction>> Get(string id)
        {
            var item = await _tranactionRepo.GetTransactionItem(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return item;
            }
        }


        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiTransaction>> Create([FromBody] ApiTransactionCreate value)
        {
            var ret = await _tranactionRepo.AddTransactionItem(value);
            return ret;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiTransaction>> Put(string id, [FromBody] ApiTransactionUpdate updateValues)
        {
            //ApiTransactionUpdate updateData = updateValues;
            //updateData.Id = id;

            var ret = await _tranactionRepo.UpdateTransactionItem(id, updateValues);

            if (ret == null)
            {
                return NotFound();
            }
            else
            {
                return ret;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
