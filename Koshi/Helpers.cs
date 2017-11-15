using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koshi
{
	public static class Helpers
	{
		public static decimal Tax
		{
			get
			{
				return 6;
			}
		}

		public static decimal ShippingFee
		{
			get
			{
				return 10;
			}
		}
	}
}