using Microsoft.AspNetCore.Mvc.Rendering;
using ProductManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Interface
{
    public interface IStatusRepo
    {
        SelectList GetStatuses();
    }
}
