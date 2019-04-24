using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Interface;

namespace ProductManagement.Controllers
{
    public class AuthenticateController : Controller
    {
        private IUserRepo _userRepo;
        public AuthenticateController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            try
            {
                var currentUser = _userRepo.GetUserByUserName(username,password);
                if (currentUser.UserId != 0)
                {
                    var userRole = _userRepo.GetRoleById(currentUser.RoleId);
                    //var claims = new List<Claim>
                    //{
                    //    new Claim(ClaimTypes.Name, currentUser.UserName),
                    //    new Claim(ClaimTypes.Role, "Admin")
                    //};

                    //var claimsIdentity = new ClaimsIdentity(
                    //    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    //var authProperties = new AuthenticationProperties
                    //{
                    //    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
                    //};

                    //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    //    new ClaimsPrincipal(claimsIdentity),
                    //    authProperties);
                    HttpContext.Session.SetString("username", currentUser.UserName);
                    return RedirectToAction("Index", "Home");
                    
                }
                else
                {
                    ModelState.AddModelError("","Bad Credential.");
                    return RedirectToAction("Login", "Authenticate");
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                //TempData["error"] = "User not found.";
                return RedirectToAction("Login", "Authenticate");
            }

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Login", "Authenticate");
        }
    }
}