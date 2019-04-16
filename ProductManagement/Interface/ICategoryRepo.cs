using ProductManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Interface
{
    public interface ICategoryRepo
    {
        Category GetCategory(int CategoryId);
        string CreateCategory(Category category);
        string UpdateCategory(Category category);        
        string DeleteCategory(int CategoryId);
        IEnumerable<Category> GetCategories();

        IEnumerable<CategoryOption> GetCategoryOptions(int CategoryId);
    }
}
