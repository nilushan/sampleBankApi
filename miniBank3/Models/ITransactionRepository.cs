using System.Collections.Generic;
using System.Threading.Tasks;
using miniBank3.Controllers.entities;

namespace miniBank3.Models
{
    internal interface ITransactionRepository

    {
        public Task<IEnumerable<ApiTransaction>> GetAllTransactionItems();
        public Task<ApiTransaction> GetTransactionItem(string Id);

        public Task<ApiTransaction> AddTransactionItem(ApiTransactionCreate apiTransaction);

    }
}