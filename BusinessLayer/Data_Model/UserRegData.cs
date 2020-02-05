using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Data_Model
{
    public class UserRegModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccountEmail { get; set; }
        public string RoleUserAccount { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateReg { get; set; }
        public string IpAddress { get; set; }
    }
}
