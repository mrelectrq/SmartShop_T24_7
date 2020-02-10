using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Providers.Entities;
using BusinessLayer;
using BusinessLayer.Data_Model;
using BusinessLayer.Interfaces;
using DataLayer.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartShop_T24_7.Models;

namespace SmartShop_T24_7.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogging _status;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            var bl = new BusinessManager();
            _status = bl.GetLogging();
            _userManager = userManager;
            _signInManager = signInManager;
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
                    User user = new User { UserName = data.Username };

                    _userManager.CreateAsync(user);
                    _userManager.AddToRoleAsync(user, "User");
                    
    
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

        [HttpPost]
        public ActionResult Authentification(LogModel model)
        {
            var data = new UserLogModel();
            data.Username = model.Username;
            data.Password = model.Password;
            data.LoginIp = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            data.LoginData = DateTime.Now;

            var response = _status.UserLoginAction(data);

            if (response.RequestStatus == false)
            {

                return View(model);
            }
            else
            {

                return View();
            }

        }
    }
}