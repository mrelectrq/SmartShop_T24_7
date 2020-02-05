using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Data_Model;
using BusinessLayer.Interfaces;
using DataLayer.Responses;
using Microsoft.AspNetCore.Mvc;
using SmartShop_T24_7.Models;

namespace SmartShop_T24_7.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogging _status;
        public AuthController()
        {
            var bl= new BusinessManager();
            _status = bl.GetLogging();
        }
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegModel data)
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

            }
            return View();
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
                return View();
            }
            else
            {
                Response.Cookies.Append("_credential", response.Cookie_string);
            }
            return View();
        }
    }
}