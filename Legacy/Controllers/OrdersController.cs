using Legacy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Legacy.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrdersRepository ordersRepository;

        public OrdersController()
        {
            ordersRepository = new OrdersRepository(Config.ConnectionString);
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