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
        private IUserRepo _user;
        public AuthenticateController(IUserRepo user)
        {
            _user = user;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Login");
            }
            //Check the user name and password  
            //Here can be implemented checking logic from the database  
            ClaimsIdentity identity = null;
            bool isAuthenticated = false;

            if (_user.GetUserByUserName(username,password) !=null)
            {
                //Create the identity for the user  
                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "Admin")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthenticated = true;
            }

            //if (_user.GetUserByUserName(username, password) != null)
            //{
            //    //Create the identity for the user  
            //    identity = new ClaimsIdentity(new[] {
            //        new Claim(ClaimTypes.Name, username),
            //        new Claim(ClaimTypes.Role, "User")
            //    }, CookieAuthenticationDefaults.AuthenticationScheme);
            //    isAuthenticated = true;
            //}

            if (isAuthenticated)
            {
                HttpContext.Session.SetString("username", username);
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Remove("username");
            return RedirectToAction("Login","Authenticate");
        }
    }
}