using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Koshi.ViewModels
{
    // model for checkeout, all are required to be and some of the id should be valid.
	public class Checkout
	{
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string Address { get; set; }
		[Required]
		public string City { get; set; }
		[Required]
		public string State { get; set; }
		[Required]
		public string ZipCode { get; set; }
		[Required]
		public string Country { get; set; }
		[Required]
		[DataType(DataType.PhoneNumber)]
		[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
		public string PhoneNumber { get; set; }
		[Required]
		[EmailAddress]
		public string EmailAddress { get; set; }
		[Required]
		public int CardType { get; set; }
		[Required]
		[CreditCard]
		public string CreditCardNumber { get; set; }
		[Required]
		public string CardCVV { get; set; }
		[Required]
		public int ExpirationDateMonth { get; set; }
		[Required]
		public int ExpirationYear { get; set; }
	}
}