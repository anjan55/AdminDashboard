using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Entity
{
    


    public class Branch
    {
       
        public int BranchId { get; set; }
        [Required(ErrorMessage = "Enter Branch Name!")]
        public string BranchName { get; set; }
        public string BranchDesc { get; set; }
        public StatusOption BranchStatus { get; set; }

    }
}
