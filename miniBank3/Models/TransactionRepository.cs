using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using miniBank3.Controllers.entities;

namespace miniBank3.Models
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DbTransactionContext _context;
        public TransactionRepository(DbTransactionContext context)
        {
            _context = context;
        }

        public async Task<ApiTransaction> AddTransactionItem(ApiTransactionCreate apiTransaction)
        {
            Transaction newTransaction = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                Date = DateTime.Now.ToUniversalTime(),
                Amount = apiTransaction.Amount,
                FromAccount = apiTransaction.FromAccount,
                ToAccount = apiTransaction.ToAccount,
                Description = apiTransaction.Description

            };

            try
            {

                _context.TransactionItems.Add(newTransaction);
                await _context.SaveChangesAsync();

                ApiTransaction createdTranaction = await this.GetTransactionItem(newTransaction.Id);
                return createdTranaction;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public async Task<IEnumerable<ApiTransaction>> GetAllTransactionItems()
        {

            var dbTranactions = await _context.TransactionItems.ToListAsync();

            return dbTranactions.ConvertAll(new Converter<Transaction, ApiTransaction>(
                transactionItem => new ApiTransaction
                {
                    Id = transactionItem.Id,
                    FromAccount = transactionItem.FromAccount,
                    ToAccount = transactionItem.ToAccount,
                    Amount = transactionItem.Amount,
                    Description = transactionItem.Description,
                    Date = transactionItem.Date
                }
                )).ToArray();

        }

        public async Task<ApiTransaction> GetTransactionItem(string Id)
        {
            var transactionItem = _context.TransactionItems.Find(Id);


            if (transactionItem != null)
            {
                ApiTransaction apiTranaction = new ApiTransaction
                {
                    Id = transactionItem.Id,
                    FromAccount = transactionItem.FromAccount,
                    ToAccount = transactionItem.ToAccount,
                    Amount = transactionItem.Amount,
                    Description = transactionItem.Description,
                    Date = transactionItem.Date
                };
                return apiTranaction;
            }
            else
            {
                return null;
            }
        }

    }
}
