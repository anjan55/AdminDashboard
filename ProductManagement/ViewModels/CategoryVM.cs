using Microsoft.AspNetCore.Mvc.Rendering;
using ProductManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.ViewModels
{
    public enum StatusOption { Active = 1, Inactive = 0 }
    public class CategoryVM
    {
        public IEnumerable<Category> Categories { get; set; }
        public Category Category { get; set; }
        public string PageTitle { get; set; }
        public StatusOption StatusOption { get; set; }

        public IEnumerable<CategoryOption> categoryOptions { get; set; }
    }
}