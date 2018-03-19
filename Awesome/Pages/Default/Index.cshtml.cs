using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Awesome.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Awesome.Pages.Default
{
    public class IndexModel : PageModel
    {
        private readonly IOrdersRepository ordersRepository;

        public IndexModel(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }
        public int ProductCount { get; set; }
        public decimal OrdersTotal { get; set; }
        public void OnGet()
        {
            
            var aggregate = ordersRepository.GetOrdersAggregate();
            ProductCount = aggregate.productCount;
            OrdersTotal = aggregate.ordersTotal;
        }
    }
}