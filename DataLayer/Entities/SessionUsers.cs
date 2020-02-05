using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class SessionUsers
    {
        public int IdSession { get; set; }
        public string Username { get; set; }
        public string CookieString { get; set; }
        public DateTime? ExpiredTime { get; set; }
    }
}
