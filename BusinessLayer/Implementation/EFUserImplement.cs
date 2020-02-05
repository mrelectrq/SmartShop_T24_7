using BusinessLayer.Data_Model;
using DataLayer.Entities;
using DataLayer.Responses;
using Smart_Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BusinessLayer.Implementation
{
    public class EFUserImplement
    {
        internal RegistrationResponse RegistrationAction(UserRegModel data)
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
                dataLayer.Ipaddress = data.IpAddress;
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


        internal string CookieGen(string username, string password)
        {

            var cookie = CookieGenerator.Create(username + ":" + password);
            using (var _context = new Lake_ShopContext())
            {
                SessionUsers session = new SessionUsers();

                session.Username = username;
                session.CookieString = cookie;
                session.ExpiredTime = DateTime.Now.AddDays(1);
                _context.SessionUsers.Add(session);
            }

            return cookie;
        }

        internal LoginResponse LoginAction(UserLogModel data)
        {

            UserAccountsData user = new UserAccountsData();


            var validate = new EmailAddressAttribute();

            if (validate.IsValid(data.Username))
            {

                using (var _context = new Lake_ShopContext())
                {
                    user = _context.UserAccountsData.FirstOrDefault(m => m.AccountEmail == data.Username && m.Password == EncryptString.HashGen(data.Password));

                }

                if (user == null)
                {
                    return new LoginResponse { RequestStatus = false, RequestMessage = "Email sau Password introdus incorect" };
                }
                else
                {
                    using (var _context = new Lake_ShopContext())
                    {

                        user.LastLogin = data.LoginData;
                        user.Ipaddress = data.LoginIp;

                        _context.UserAccountsData.Update(user);

                        SessionUsers session = new SessionUsers();

                        session.CookieString = CookieGenerator.Create(user.Username + ":" + user.Password);
                        session.Username = user.Username;
                        session.ExpiredTime = DateTime.Now.AddDays(1);
                        _context.SessionUsers.AddAsync(session);

                        return new LoginResponse { RequestStatus = true, Cookie_string = session.CookieString };
                    }
                }

            }
            else
            {
                using (var _context = new Lake_ShopContext())
                {
                    user = _context.UserAccountsData.FirstOrDefault(m => m.Username == data.Username && m.Password == EncryptString.HashGen(data.Password));

                }

                if (user == null)
                {
                    return new LoginResponse { RequestStatus = false, RequestMessage = "Username sau Password introdus incorect" };
                }
                else
                {
                    using (var _context = new Lake_ShopContext())
                    {

                        user.LastLogin = data.LoginData;
                        user.Ipaddress = data.LoginIp;

                        _context.UserAccountsData.Update(user);

                        SessionUsers session = new SessionUsers();

                        session.CookieString = CookieGenerator.Create(user.Username + ":" + user.Password);
                        session.Username = user.Username;
                        session.ExpiredTime = DateTime.Now.AddDays(1);
                        _context.SessionUsers.AddAsync(session);

                        return new LoginResponse { RequestStatus = true, Cookie_string = session.CookieString };
                    }
                }


            }

        }
    }


}



