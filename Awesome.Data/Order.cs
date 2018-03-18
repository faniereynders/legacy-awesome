using System;

namespace Awesome.Data
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public string Product { get; set; }
        public decimal UnitPrice { get; set; }
        public int CustomerId { get; set; }

    }
}
