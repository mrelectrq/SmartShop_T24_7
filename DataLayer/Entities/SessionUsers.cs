using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class SessionUsers
    {
        public long SessionId { get; set; }
        public string Username { get; set; }
        public string CookieString { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}
