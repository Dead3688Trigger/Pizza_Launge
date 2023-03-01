

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CUSTOMER
    {
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Telephone { get; set; }
        public string Order_ID { get; set; }
        public string Payment_ID { get; set; }
    }
}
