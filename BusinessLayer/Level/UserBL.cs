using BusinessLayer.Data_Model;
using BusinessLayer.Implementation;
using BusinessLayer.Interfaces;
using DataLayer.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Level
{
    public class UserBL :  EFUserImplement, ILogging
    {
        public RegistrationResponse UserRegistrationAction(UserRegModel data)
        {
            return RegistrationAction(data);
        }

        public string SetCookie(string username, string password)
        {
            return null;
        }

        public LoginResponse UserLoginAction (UserLogModel data)
        {
            return LoginAction(data);
        }
    }
}
