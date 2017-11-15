using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koshi.Models
{
	public class CartProduct
	{
        // Model for cartProduct
		public int CartProductID { get; set; }
		public int CartID { get; set; }
		public int ProductID { get; set; }
		public int Quantity { get; set; }

		public virtual Cart Cart { get; set; }
		public virtual Product Product { get; set; }
	}
}