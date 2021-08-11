using System;
namespace miniBank3.Models
{
    public class Transaction
    {

        public string Id { get; set; }
        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string OwnerId { get; set; }
        public string OwnerName { get; set; }

    }

    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}


