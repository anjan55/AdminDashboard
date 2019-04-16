using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Entity
{
    public class CategoryOption
    {
        //CategoryOption
        public int OptionId { get; set; }
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Enter Option Name!")]
        public string OptionName { get; set; }
        public string OptionDesc { get; set; }
        public StatusOption OptionStatus { get; set; }
    }
}
