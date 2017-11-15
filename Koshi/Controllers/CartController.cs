using Koshi.DAL;
using Koshi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vereyon.Web;

namespace Koshi.Controllers
{
    // In this cart controller section, applying  loop, get and post technique along with if and else statements to add the products to the cart and delete the product from the cart.
    // if the cart is empty then alerts a message to add items before to checkout and redirects to the home view page to select items.
    // In the ActionResult Create,if the cartId is null it creates new cartId for specific customer for the procuct to buy or else 
    // finds the cartId from database and add the items by productId and here also if the cartproduct is null creates new cartproduct for the product with quantity by id
    // and save the change in db and redirectes to the view of product for funther checkout.
    // in the ActionResult Delete, if user wants to remove the cartproduct then it finds the product by productnameId from database and finds the cartId and removes the
    //cartproduct and save change in db and fianally redirects to the index on the home page.
    public class CartController : BaseController
    {
		private KoshiContext db = new KoshiContext();

        // GET: Cart
        public ActionResult Index()
        {
			var cartId = base.GetUserCart();
			var cartProducts = db.CartProduct.Include("Product").Where(x => x.CartID == cartId).ToList();

			if (!cartProducts.Any())
			{
				FlashMessage.Info("Your cart is empty. Please add some items in cart for checkout.");
			}

            return View(cartProducts);
        }

		[HttpPost]
		public ActionResult Create(AddToCart model)
		{
			var cartId = base.GetUserCart();

			if (cartId == null)
			{
				var cart = new Models.Cart
				{
					CreatedDate = DateTime.Now
				};

				cart.CartProducts.Add(new Models.CartProduct
				{
					ProductID = model.Product.ProductID,
					Quantity = model.Quantity
				});

				db.Cart.Add(cart);
				db.SaveChanges();

				base.SetUserCart(cart.CartId);
			}
			else
			{
				var cart = db.Cart.Find(cartId);

				var cartProduct = cart.CartProducts.FirstOrDefault(x => x.ProductID == model.Product.ProductID);

				if (cartProduct == null)
				{
					cartProduct = new Models.CartProduct
					{
						ProductID = model.Product.ProductID,
						Quantity = model.Quantity
					};

					cart.CartProducts.Add(cartProduct);
				}
				else
				{
					cartProduct.Quantity = model.Quantity;
				}

				db.SaveChanges();
			}

			var product = db.Product.Find(model.Product.ProductID);
			FlashMessage.Confirmation(String.Format("{0} has been added to your cart", product.ProductName));

			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
		{
			var cartProduct = db.CartProduct.Find(id);
			var productName = cartProduct.Product.ProductName;

			if (cartProduct != null && cartProduct.CartID == base.GetUserCart())
			{
				db.CartProduct.Remove(cartProduct);
				db.SaveChanges();

				FlashMessage.Confirmation(String.Format("{0} has been removed from your cart", productName));
			}

			return RedirectToAction("Index");
		}
    }
}