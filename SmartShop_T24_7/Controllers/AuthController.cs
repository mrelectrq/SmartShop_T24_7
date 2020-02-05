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



            var dataBL = new UserRegData();
            dataBL.Username = data.Username;
            dataBL.Password = data.Password;
            dataBL.AccountEmail = data.Email;
            dataBL.IpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            dataBL.PhoneNumber = data.Phone_number;
            dataBL.DateReg = DateTime.Now;
            dataBL.RoleUserAccount = "UserLevel1";


            RegistrationResponse response = _status.UserRegistration(dataBL);

            if (response.Request_status)
            {
                Response.Cookies.Append("_credential", "");
            }
            return View();
        }
    }
}