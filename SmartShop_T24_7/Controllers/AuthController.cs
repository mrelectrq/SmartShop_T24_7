using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Data_Model;
using BusinessLayer.Interfaces;
using DataLayer.Responses;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartShop_T24_7.Models;

namespace SmartShop_T24_7.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogging _status;

        public AuthController()
        {
            var bl = new BusinessManager();
            _status = bl.GetLogging();

        }
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(RegModel data)
        {

            if (ModelState.IsValid)
            {
                var dataBL = new UserRegModel();
                dataBL.Username = data.Username;
                dataBL.Password = data.Password;
                dataBL.AccountEmail = data.Email;
                dataBL.IpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                dataBL.PhoneNumber = data.Phone_number;
                dataBL.DateReg = DateTime.Now;
                dataBL.RoleUserAccount = "UserLevel1";


                RegistrationResponse response = _status.UserRegistrationAction(dataBL);

                if (response.Request_status)
                {

                    var cookie = _status.SetCookie(data.Username, data.Password);
                    Response.Cookies.Append("_credential", cookie);



                    Authenticate(data.Username);

                    var user = User.Identity.Name;
                    var state = User.Identity.IsAuthenticated;

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", response.Request_message);
                    return View();
                }
            }
            else
            {

                return View(data);
            }
        }
        public IActionResult Authorize()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(LogModel model)
        {
            if (ModelState.IsValid)
            {
                var data = new UserLogModel();
                data.Username = model.Username;
                data.Password = model.Password;
                data.LoginIp = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                data.LoginData = DateTime.Now;

                var response = _status.UserLoginAction(data);

                if (response.RequestStatus == false)
                {

                    ModelState.AddModelError("", response.RequestMessage);
                    return View();
                    //return PartialView("~/Views/Shared/_AuthorizePartial.cshtml");
                }
                else
                {
                    Authenticate(model.Username);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {

                return View();
            }

        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();

            //ControllerContext.HttpContext.Response.Cookies.Clear();
            return RedirectToAction("Index", "Home");
        }

        [NonAction]
        private async Task Authenticate(string username)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, username)
               
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));

        }
    }

}