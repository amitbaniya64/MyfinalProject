using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koshi.Models
{
	public class Order
	{
        // OrderId model for List of orderItem. 
		public Order()
		{
			OrderItem = new List<OrderItem>();
		}

		public int OrderID { get; set; }
		public int CustomerID { get; set; }
		public int AddressID { get; set; }
		public int CreditCardID { get; set; }
		public decimal Shipping { get; set; }
		public decimal Tax { get; set; }
		public decimal SubTotal { get; set; }
		public decimal Total { get; set; }

		public virtual Customer Customer { get; set; }
		public virtual Address Address { get; set; }
		public virtual CreditCard CreditCard { get; set; }
		public virtual ICollection<OrderItem> OrderItem { get; set; }
	}
}