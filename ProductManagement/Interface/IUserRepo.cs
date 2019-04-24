using ProductManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Interface
{
    public interface IUserRepo
    {
        User GetUserByUserName(string username, string password);
        string GetRoleById(int roleId);
    }
}
