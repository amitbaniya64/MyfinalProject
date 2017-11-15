using Koshi.Areas.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Koshi.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
		// GET: Admin/Orders
		private DAL.KoshiContext db = new DAL.KoshiContext();
		public ActionResult Index()
        {
			
			return View(db.Order.ToList());
        }
        // This orderdetails model returns the order of customer by finding Id from db. 
		public ActionResult OrderDetails(int id)
		{
			var order = db.Order.Find(id);
			return View(order);
		}
    }
}