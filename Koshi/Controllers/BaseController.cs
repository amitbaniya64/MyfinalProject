using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Koshi.Controllers
{
	public class BaseController : Controller
	{
        // This BaseController is made not to repeating common actions from every controller.
        // It loop the usercart by Id and seccion ends.
		public int? GetUserCart()
		{
			if (Session["UserCart"] == null)
				return null;
			else
				return Convert.ToInt32(Session["UserCart"]);
		}

		public void SetUserCart(int? cartId)
		{
			Session["UserCart"] = cartId;
		}
	}
}