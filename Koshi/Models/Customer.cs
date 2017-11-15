using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koshi.Models
{
	public class Customer
	{
        // customerId model for on the basis of customer Address and Creditcard. 
		public Customer()
		{
			Address = new List<Address>();
			CreditCard = new List<CreditCard>();
		}

		public int CustomerID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public string PhoneNumber { get; set; }

		public virtual ICollection<Address> Address { get; set; }
		public virtual ICollection<CreditCard> CreditCard { get; set; }
	}
}