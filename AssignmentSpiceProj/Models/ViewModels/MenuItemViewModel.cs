using Spice.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentSpiceProj.Models.ViewModels
{
    public class MenuItemViewModel
    {
        public MenuItem MenuItem { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<SubCategory> SubCategory { get; set; }
        public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
    }
}