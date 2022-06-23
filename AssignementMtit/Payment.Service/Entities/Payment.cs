using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.Service.Entities
{
    public class Payment: PaymentBaseEntity
    {
        public string customerId { get; set; }
        public string cardType { get; set; }
        public string cardNo { get; set; }
        public string amount { get; set; }
        public string description { get; set; }
    }
}
