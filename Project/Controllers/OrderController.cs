using Project.Models;
using Project.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        [HttpGet()]
        public ActionResult Index()
        {
            //test
            EmployeeService employeeservice = new EmployeeService();
            ViewBag.namelist = employeeservice.GetName();
            ShipperService shipperservice = new ShipperService();
            ViewBag.shipperlist = shipperservice.GetShipper();
            return View();
        }       

        [HttpPost()]
        public ActionResult Search(Index arg)
        {
            OrderService orderService = new OrderService();         
            List<Index> orderdata = orderService.GetOrders(arg);
            return View(orderdata);
        }

        public ActionResult InserOrder()
        {
            EmployeeService employeeservice = new EmployeeService();
            ViewBag.namelist = employeeservice.GetName();
            ShipperService shipperservice = new ShipperService();
            ViewBag.shipperlist = shipperservice.GetShipper();
            CustomerService customerservice = new CustomerService();
            ViewBag.Customerlist = customerservice.GetCustomer();
            return View();
        }
        [HttpPost()]
        public ActionResult InserOrder(Orders orders)
        {
            OrderService orderservice = new OrderService();
            var mess = orderservice.InserOrder(orders);
            return View();
        }

    }
}