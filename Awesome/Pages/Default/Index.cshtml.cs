using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Awesome.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Awesome.Pages.Default
{
    public class IndexModel : PageModel
    {
        public int ProductCount { get; set; }
        public decimal OrdersTotal { get; set; }
        public void OnGet()
        {
            var a = new OrdersRepository(@"Server=.\sqlexpress;Database=test;Trusted_Connection=yes;");
            var aggregate = a.GetOrdersAggregate();
            ProductCount = aggregate.productCount;
            OrdersTotal = aggregate.ordersTotal;
        }
    }
}