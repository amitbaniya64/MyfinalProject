using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koshi.Models
{
	public class CreditCard
	{ 
        //Making Creditcard model for each customer, Id type.

		public int CreditCardID { get; set; }
		public int CustomerID { get; set; }
		public int CardType { get; set; }
		public string CardNumber { get; set; }
		public string CardCCV { get; set; }
		public int ExpirationMonth { get; set; }
		public int ExpirationYear { get; set; }

		public virtual Customer Customer { get; set; }
		public virtual ICollection<Order> Order { get; set; }

	}
}