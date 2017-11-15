using Koshi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Koshi.DAL
{
	public class KoshiInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<KoshiContext>
	{
		protected override void Seed(KoshiContext context)
		{
			var Category = new List<Category>
			{
			new Category{CategoryID=1,Name="Shoes"},
			new Category{CategoryID=2,Name="TShirt"},
			new Category{CategoryID=3,Name="Mobile"},
			new Category{CategoryID=4,Name="Computer"},
			new Category{CategoryID=5,Name="Woman Jeans"},

			};
			Category.ForEach(s => context.Category.Add(s));
			context.SaveChanges();

			var products = new List<Product>
			{
				new Product
				{
					CategoryID = 1,
					Price = 80,
					ProductDescription = "Test description",
					ProductID = 1,
					ProductImage = "Converse.jpg",
					ProductName = "Converse"
				},
				new Product
				{
					CategoryID = 2,
					Price = 50,
					ProductDescription = "Test aa",
					ProductID = 2,
					ProductImage = "Blue_Tshirt.jpg",
					ProductName = "Nike T Shirt"
				},

				new Product
				{
					CategoryID = 3,
					Price = 500,
					ProductDescription = "Test aa",
					ProductID = 3,
					ProductImage = "iphone_7_plus.jpg",
					ProductName = "iphone 7 plus"
				},
				new Product
				{
					CategoryID = 4,
					Price = 200,
					ProductDescription = "Test aa",
					ProductID = 4,
					ProductImage = "dell_desktop.jpg",
					ProductName = "Nike T Shirt"
				},
				new Product {
					CategoryID = 5,
					Price = 200,
					ProductDescription = "Test aa",
					ProductID = 5,
					ProductImage = "girl_levis.jpg",
					ProductName = "Woman Jeans"
				},
				new Product{
					CategoryID = 5,
					Price = 200,
					ProductDescription = "Test aa",
					ProductID = 6,
					ProductImage = "dell_desktop.jpg",
					ProductName = "Nike T Shirt"
				},
				new Product{
					CategoryID = 5,
					Price = 200,
					ProductDescription = "Test aa",
					ProductID = 7,
					ProductImage = "dell_desktop.jpg",
					ProductName = "Nike T Shirt"
				},

			};


			products.ForEach(s => context.Product.Add(s));
			context.SaveChanges();




		}

	}
}