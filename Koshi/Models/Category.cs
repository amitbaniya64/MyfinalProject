using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koshi.Models
{
	public class Category
	{
        // Model Id for category of the product, shows one to many relationship.
		public int CategoryID { get; set; }
		public string Name { get; set; }

		public virtual ICollection<Product> Products { get; set; }
	}
}