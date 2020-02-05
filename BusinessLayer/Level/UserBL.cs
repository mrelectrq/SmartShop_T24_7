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
        public RegistrationResponse UserRegistration(UserRegData data)
        {
            return Registration_data(data);
        }

        
    }
}
