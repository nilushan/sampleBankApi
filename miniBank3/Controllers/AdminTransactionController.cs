using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using miniBank3.Controllers.entities;
using miniBank3.Models;
using Newtonsoft.Json;

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

            var items = _tranactionRepo.GetTransactionItems().Result;
            return items;

            //return _context.TransactionItems.ToList().Select(transactionItem => new ApiTransaction
            //{
            //    Id = transactionItem.Id,
            //    FromAccount = transactionItem.FromAccount,
            //    ToAccount = transactionItem.ToAccount,
            //    Amount = transactionItem.Amount,
            //    Description = transactionItem.Description,
            //    Date = transactionItem.Date
            //}).ToArray();

        }

    // GET api/values/5
    [HttpGet("{id}" , Name = "GetID" )]
    public ApiTransaction Get(string id)
    {
            return _tranactionRepo.TransactionItem(id).Result;
    }

    // POST api/values
    [HttpPost]
    
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ApiTransaction>> Create( [FromBody]ApiTransactionCreate value)
    {


        //    Transaction newTransaction = new Transaction
        //{
        //    Id = Guid.NewGuid().ToString(),
        //    Date = DateTime.Now.ToUniversalTime(),
        //    Amount = value.Amount,
        //    FromAccount = value.FromAccount,
        //    ToAccount = value.ToAccount,
        //    Description = value.Description

        //};

            //_context.TransactionItems.Add(newTransaction);
            //await _context.SaveChangesAsync();

            var ret = _tranactionRepo.Add(value).Result;
            return ret;
        //return CreatedAtAction(nameof(Get), new { Id = value.Id }, newTransaction);


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
