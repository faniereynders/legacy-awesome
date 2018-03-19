using System.Collections.Generic;
using Awesome.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Awesome.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly ICustomersRepository customerRepository;
        public IEnumerable<Customer> Items { get; set; }

        [BindProperty]
        public string Query { get; set; }
        public IndexModel(ICustomersRepository customerRepository)
        {
            this.customerRepository = customerRepository;
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
            Items = customerRepository.GetCustomers(Query);
        }


    }
}