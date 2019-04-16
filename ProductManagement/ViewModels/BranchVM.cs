using ProductManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.ViewModels
{
    public enum Status { Active = 1, Inactive = 0 }
    public class BranchVM
    {
        public IEnumerable<Branch> Branches { get; set; }
        public Branch Branch { get; set; }
        public string PageTitle { get; set; }
        public Status Status { get; set; }


    }
}
