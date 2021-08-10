using System;
using miniBank3.Controllers.entities;

namespace miniBank3.Models
{
    public class TransactionUtils
    {

        public static Transaction convertToDbTransactionType(ApiTransactionCreate apiTransaction)
        {
            return new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                Date = DateTime.Now.ToUniversalTime(),
                Amount = apiTransaction.Amount,
                FromAccount = apiTransaction.FromAccount,
                ToAccount = apiTransaction.ToAccount,
                Description = apiTransaction.Description

            };
        }


        public static Transaction convertToDbTransactionType(ApiTransactionUpdate apiTransaction)
        {
            return new Transaction
            {
                Amount = apiTransaction.Amount,
                FromAccount = apiTransaction.FromAccount,
                ToAccount = apiTransaction.ToAccount,
                Description = apiTransaction.Description

            };
        }

        public static Transaction copyExistingValues(Transaction existing, Transaction updated)
        {
            if (updated.Amount != null)
            {
                existing.Amount = updated.Amount;
            }
            if( updated.FromAccount != null)
            {
                existing.FromAccount = updated.FromAccount;
            }
            if( updated.ToAccount != null)
            {
                existing.ToAccount = updated.ToAccount;
            }
            if(updated.Description != null)
            {
                existing.Description = updated.Description;
            }

            return existing;
        }
    }
}
