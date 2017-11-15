using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Koshi.DAL;
using Koshi.Models;
using Koshi.ViewModels;
using Vereyon.Web;

namespace Koshi.Controllers
{

	public class HomeController : BaseController
	{
		private KoshiContext db = new KoshiContext();
      // This ActionResult Index model is to bring product from the db and shows the list of products in the view model  and ActionResult Details to 
      // appear product deatail, call by productID which finds from db and returns in the view model detail page to add it in cart.  


		public ActionResult Index()
		{
			var products = db.Product;
			return View(products.ToList());
		}

		public ActionResult Details(int? id)
		{
			var viewModel = new AddToCart();

			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Product product = db.Product.Find(id);
			if (product == null)
			{
				return HttpNotFound();
			}

			viewModel.Product = product;

			return View(viewModel);
		}
	}
}