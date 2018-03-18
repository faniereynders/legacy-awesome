using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Legacy.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Awesome.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly CustomersRepository customerRepo;
        public IEnumerable<Customer> Items { get; set; }

        [BindProperty]
        public string Query { get; set; }
        public IndexModel()
        {
            customerRepo = new CustomersRepository(@"Server=.\sqlexpress;Database=test;Trusted_Connection=yes;");
        }

        public void OnGet()
        {
            LoadCustomers();
        }
        public void OnPost()
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            Items = customerRepo.GetCustomers(Query);
        }


    }
}