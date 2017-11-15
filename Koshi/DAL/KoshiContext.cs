using Koshi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Koshi.DAL
{
	public class KoshiContext : DbContext
	{
        // batabase set for Id..
		public KoshiContext() : base("KoshiContext")
		{
		}

		public DbSet<Product> Product { get; set; }
		public DbSet<Category> Category { get; set; }
		public DbSet<Cart> Cart { get; set; }
		public DbSet<CartProduct> CartProduct { get; set; }
		public DbSet<Address> Address { get; set; }
		public DbSet<CreditCard> CreditCard { get; set; }
		public DbSet<Customer> Customer { get; set; }
		public DbSet<Order> Order { get; set; }
		public DbSet<OrderItem> OrderItem { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
		}
	}
}