using System.Collections.Generic;
using System.Threading.Tasks;
using miniBank3.Controllers.entities;

namespace miniBank3.Models
{
    internal interface ITransactionRepository

    {
        public Task<IEnumerable<ApiTransaction>> GetTransactionItems();
        public Task<ApiTransaction> TransactionItem(string Id);

        public Task<ApiTransaction> Add(ApiTransactionCreate apiTransaction);

    }
}