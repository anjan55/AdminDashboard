using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Entity
{
    
    public class Category
    {
        //Category
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Enter Category Name!")]
        public string CategoryName { get; set; }
        public string CategoryDesc { get; set; }        
        public StatusOption CategoryStatus { get; set; }

        


    }
    
}
