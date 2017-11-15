using Koshi.DAL;
using Koshi.Models;
using Koshi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vereyon.Web;

namespace Koshi.Controllers
{
    public class CheckoutController : BaseController
    {
        // This sectiion is for checkout the product after adding the product in cart and shows in list.
        // if the the carproducts is empty, alerts the flashmessage to add product before to checkout, thus it again redirected to the home index or else returns to the view for the checkout.
        //In the post checkout model if the statement is valid,returns view model for checkout and fill the fields for place order,
        // here again if the cartproduct is empty then again alerts the same flash message to add the some item in the cart for checkout and redirects to the home index.
        // then after filling out the all corrects requirement informations in the checkout form and save the order informations in orderitem db and alerts the 
        //flash message by succesfully placing order and redirects to the home index.
        // ActionResult revieworder model is to show the view of orderlist of the products from the cartproduct before to place in order. 
        
		private KoshiContext db = new KoshiContext();

		// GET: Checkout
		public ActionResult Index()
        {
			var cartId = base.GetUserCart();
			var cartProducts = db.CartProduct.Include("Product").Where(x => x.CartID == cartId).ToList();

			if (!cartProducts.Any())
			{
				FlashMessage.Danger("Your cart is empty. Please add some items in cart for checkout.");
				return RedirectToAction("Index", "Home");
			}

			return View();
        }

		[HttpPost]
		public ActionResult Index(Checkout model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var cartId = base.GetUserCart();
			var cartProducts = db.CartProduct.Include("Product").Where(x => x.CartID == cartId).ToList();

			if (!cartProducts.Any())
			{
				FlashMessage.Danger("Your cart is empty. Please add some items in cart for checkout.");
				return RedirectToAction("Index", "Home");
			}

			var subTotal = cartProducts.Sum(x => x.Product.Price * x.Quantity);
			var shipping = Helpers.ShippingFee;
			var tax = subTotal * Helpers.Tax / 100;

			var address = new Address
			{
				AddressLine = model.Address,
				City = model.City,
				State = model.State,
				Zip = model.ZipCode,
				Country = model.Country
			};

			var creditCard = new CreditCard
			{
				CardCCV = model.CardCVV,
				CardNumber = model.CreditCardNumber,
				CardType = model.CardType,
				ExpirationMonth = model.ExpirationDateMonth,
				ExpirationYear = model.ExpirationYear
			};

			var customer = new Customer
			{
				EmailAddress = model.EmailAddress,
				FirstName = model.FirstName,
				LastName = model.LastName,
				PhoneNumber = model.PhoneNumber
			};

			customer.Address.Add(address);
			customer.CreditCard.Add(creditCard);

			var order = new Order
			{
				Address = address,
				CreditCard = creditCard,
				Customer = customer,
				Shipping = 10,
				SubTotal = subTotal,
				Tax = tax,
				Total = subTotal + shipping + tax
			};

			foreach (var item in cartProducts)
			{
				order.OrderItem.Add(new OrderItem
				{
					Price = item.Product.Price,
					ProductID = item.ProductID,
					Quantity = item.Quantity
				});
			}

			db.Order.Add(order);
			db.SaveChanges();

			base.SetUserCart(null);

			FlashMessage.Confirmation("Order has been successfully placed");

			return RedirectToAction("Index", "Home");
		}

		public ActionResult ReviewOrder()
		{
			var cartId = base.GetUserCart();
			var cartProducts = db.CartProduct.Include("Product").Where(x => x.CartID == cartId).ToList();

			return View(cartProducts);
		}
    }
}