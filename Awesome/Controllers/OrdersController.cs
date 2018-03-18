using Awesome.Data;
using Microsoft.AspNetCore.Mvc;

namespace Awesome.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrdersRepository ordersRepository;

        public OrdersController()
        {
            ordersRepository = new OrdersRepository(@"Server=.\sqlexpress;Database=test;Trusted_Connection=yes;");
        }

        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(Order order)
        {
            ordersRepository.AddOrder(order);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var order = ordersRepository.GetOneOrder(id);
            return View(order);
        }


        public ActionResult Index()
        {
            var orders = ordersRepository.GetAllOrders();
            return View(orders);
        }
    }
}