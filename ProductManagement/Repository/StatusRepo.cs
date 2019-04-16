using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using ProductManagement.Entity;
using ProductManagement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Repository
{
    public class StatusRepo
    {        

        public SelectList GetStatuses()
        {
            return new SelectList(
                                        new List<SelectListItem>
                                        {
                                            new SelectListItem { Text = "Active", Value = "1"},
                                            new SelectListItem { Text = "Inactive", Value = "0"},
                                        }, "Value", "Text"
                                 );
        }
    }
}
