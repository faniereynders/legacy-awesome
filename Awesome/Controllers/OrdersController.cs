using Awesome.Data;
using Microsoft.AspNetCore.Mvc;

namespace Awesome.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersRepository ordersRepository;

        public OrdersController(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
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