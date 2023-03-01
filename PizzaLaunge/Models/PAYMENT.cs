

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PAYMENT
    {
        public string PaymentID { get; set; }
        public string Payment_Status { get; set; }
        public byte[] Bill { get; set; }
    }
}
