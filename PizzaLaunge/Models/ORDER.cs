

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ORDER
    {
        public string OrderId { get; set; }
        public string OrderDate { get; set; }
        public int Total_Price { get; set; }
        public string Order_Status { get; set; }

    }
}
