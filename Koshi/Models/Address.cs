using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koshi.Models
{
	public class Address
	{
        // customer Address model.
		public int AddressID { get; set; }
		public int CustomerID { get; set; }
		public string AddressLine { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public string Country { get; set; }

		public Customer Customer { get; set; }
	}
}