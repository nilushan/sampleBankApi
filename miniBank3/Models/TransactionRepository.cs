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
            Transaction newTransaction = TransactionUtils.convertToDbTransactionType(apiTransaction);

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
                    Date = transactionItem.Date,
                    Owner = new ApiCustomer
                    {
                        Id = transactionItem.OwnerId,
                        Name = transactionItem.OwnerName
                    }
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
                    Date = transactionItem.Date,
                    Owner = new ApiCustomer
                    {
                        Id = transactionItem.OwnerId,
                        Name = transactionItem.OwnerName
                    }
                };
                return apiTranaction;
            }
            else
            {
                return null;
            }
        }

        public async Task<ApiTransaction> UpdateTransactionItem( string id, ApiTransactionUpdate apiTransactionUpdate)
        {
            var found = _context.TransactionItems.Find(id);

            if( found == null)
            {
                return null; 
            }

            Transaction updatedTransaction = TransactionUtils.convertToDbTransactionType(apiTransactionUpdate);
            var updated = TransactionUtils.copyExistingValues(found, updatedTransaction);

            _context.TransactionItems.Update(updated);
            await _context.SaveChangesAsync();

            ApiTransaction createdTranaction = await this.GetTransactionItem(id);
            return createdTranaction;

        }


    }
}
