using System;
namespace miniBank3.Controllers.entities
{
    public class ApiTransaction
    {
        public string Id { get; }
        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public ApiCustomer Owner { get; set; }

        public ApiTransaction()
        {
            Id = Guid.NewGuid().ToString();
            Date = DateTime.Now.ToUniversalTime();
        }
    }
}

