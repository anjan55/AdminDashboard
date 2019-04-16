using ProductManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Interface
{
    public interface IBranchRepo
    {
        Branch GeBranch(int BranchId);
        IEnumerable<Branch> GetBranches();
        string SaveBranch(Branch branch);
        string DeleteBranch(int BranchId);
        string AddBranch(Branch branch);



    }
}
