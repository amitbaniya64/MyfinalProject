using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koshi.Models
{
	public class Cart
	{

        // Model for cardId, shows the relationship between cartproduct with cartId.
		public Cart()
		{
			CartProducts = new List<CartProduct>();
		}

		public int CartId { get; set; }
		public DateTime CreatedDate { get; set; }

		public virtual ICollection<CartProduct> CartProducts { get; set; }
	}
}