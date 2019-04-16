using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Entity;
using ProductManagement.Interface;
using ProductManagement.ViewModels;

namespace ProductManagement.Controllers
{
    public class BranchController : Controller
    {
        private IBranchRepo _branchRepo;
        static string ResponseMessage = "";
        public BranchController(IBranchRepo branchRepo)
        {
            _branchRepo = branchRepo;
        }


        public IActionResult Index()
        {
            BranchVM branchViewModel = new BranchVM()
            {
                Branches = _branchRepo.GetBranches(),
                PageTitle = "Branch Details"
            };

            if (ResponseMessage.Length > 0)
            {
                ViewBag.Message = ResponseMessage;
                ResponseMessage = "";
            }
            else
            {
                ViewBag.Message = "";
            }
            return View(branchViewModel);
        }


        public ViewResult Update(int Id)
        {
            BranchVM branchViewModel = new BranchVM()
            {
                Branch = _branchRepo.GeBranch(Id),
                PageTitle = "Edit Employee"
            };

            return View(branchViewModel);

        }

        [HttpPost]
        public ActionResult Update(Branch branch)
        {
            if (ModelState.IsValid)
            {

                ResponseMessage = _branchRepo.SaveBranch(branch);
                
                return RedirectToAction("Index");
            }
            BranchVM branchViewModel = new BranchVM()
            {
                Branch = _branchRepo.GeBranch(branch.BranchId),
                PageTitle = "Edit Employee"
            };

            return View(branchViewModel);

        }


        [HttpPost]
        public ActionResult Create(Branch branch)
        {
            if (ModelState.IsValid)
            {
                ResponseMessage = _branchRepo.AddBranch(branch);
                return RedirectToAction("Index");

            }
            BranchVM branchViewModel = new BranchVM()
            {
                Branch = branch,
                PageTitle = "Create Employee"
            };
            return View(branchViewModel);


           
        }
        public ViewResult Create()
        {
            BranchVM branchViewModel = new BranchVM()
            {
               // Branch = _branchRepo.AddBranch(branch),
                PageTitle = "Edit Employee"
            };

            return View(branchViewModel);

        }

        //public ActionResult Delete(int BranchId)
        //{
        //    int id = _branchRepo.DeleteBranch(BranchId);
        //    if (id > 0)
        //    {
        //        ResponseMessage = "Data successfully deleted.";
        //    }
        //    return RedirectToAction("Index");

        //}
        public ActionResult Delete(int Id)
        {
            string id = _branchRepo.DeleteBranch(Id);
           // if (id > 0)
            //{
                ResponseMessage = "Data successfully deleted.";
            //}
            return RedirectToAction("Index");

        }



    }
}
