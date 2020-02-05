using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Data_Model
{
    public class UserLogModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public DateTime LoginData { get; set; }

        public string LoginIp { get; set; }
    }
}
