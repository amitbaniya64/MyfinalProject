using Koshi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koshi.ViewModels
{
    // model for addtocart, in the cart we have product and its quantity.  
	public class AddToCart
	{
		public Product Product { get; set; }
		public int Quantity { get; set; }
	}
}