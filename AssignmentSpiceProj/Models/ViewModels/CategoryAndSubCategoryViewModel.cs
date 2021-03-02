using Spice.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssignmentSpiceProj.Models.ViewModels
{
    public class CategoryAndSubCategoryViewModel
    {
        public IEnumerable<Category> CategoryList { get; set; }
        public SubCategory SubCategory { get; set; }
        public List<string> SubCategoryList { get; set; }
        public string StatusMessage { get; set; }
    }
}