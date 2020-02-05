using BusinessLayer.Data_Model;
using DataLayer.Entities;
using DataLayer.Responses;
using Smart_Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Implementation
{
    public class EFUserImplement
    {
        internal RegistrationResponse Registration_data(UserRegData data)
        {
            var response = new RegistrationResponse();
            response.Request_status = true;

            using (var _context = new Lake_ShopContext())
            {
                var username = _context.UserAccountsData.FirstOrDefault(m => m.Username == data.Username);
                if (username != null)
                {
                    response.Request_status = false;
                    response.Request_message = "Username or Email arleady in use";
                    return response;
                }
                var email = _context.UserAccountsData.FirstOrDefault(m => m.AccountEmail == data.AccountEmail);
                if (email != null)
                {
                    response.Request_status = false;
                    response.Request_message = "Username or Email arleady in use";
                    return response;
                }
            }
            if (response.Request_status)
            {
                var dataLayer = new UserAccountsData();
                dataLayer.Username = data.Username;
                dataLayer.Password = EncryptString.HashGen(data.Password);
                dataLayer.PhoneNumber = data.PhoneNumber;
                dataLayer.IpAddress = data.IpAddress;
                dataLayer.RoleUserAccount = data.RoleUserAccount;
                dataLayer.DateBasketInit = data.DateReg;
                using (var _context = new Lake_ShopContext())
                {
                    _context.UserAccountsData.Add(dataLayer);
                    //_context.BagApp.Add(m => m.)
                    return new RegistrationResponse { Request_status = true, Request_message = "Account a fost creat cu succes" };
                }
            }
            else return new RegistrationResponse { Request_status = false, Request_message = "Eroare de inregistrare account, apelati suport tehnic" };
            
            }
        }


    }


