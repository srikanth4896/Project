using Spice.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice.DataLayer
{
    public class SpiceDbContext:DbContext
    {
        public SpiceDbContext() : base("conn")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Coupon>Coupons { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    }
}
