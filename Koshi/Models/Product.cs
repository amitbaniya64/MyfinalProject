using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koshi.Models
{
	public class Product
	{
        // Get and set ProductId model.
		public int ProductID { get; set; }
		public int CategoryID { get; set; }
		public string ProductName { get; set; }
		public string ProductDescription { get; set; }
		public string ProductImage { get; set; }
		public decimal Price { get; set; }

		public virtual Category Category { get; set; }
		public virtual ICollection<CartProduct> CartProduct { get; set; }
	}
}