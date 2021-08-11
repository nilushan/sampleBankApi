using System;
namespace miniBank3.Controllers.entities
{
    public class ApiTransactionCreate
    {
        public string Id { get; }
        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string OwnerID { get; set; }

        public ApiTransactionCreate()
        {
            Id = Guid.NewGuid().ToString();
        }
    }

    public class ApiTransactionUpdate
    {

        //public string Id { get;  }
        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string OwnerID { get; set; }
    }
}

