using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public partial class UserAccountsData
    {
        public int IdAccount { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccountEmail { get; set; }
        public string RoleUserAccount { get; set; }
        public string Ipaddress { get; set; }
        public DateTime? LastLogin { get; set; }
        public string PhoneNumber { get; set; }
        public int? BasketId { get; set; }
        public DateTime? DateBasketInit { get; set; }
        public string UsserAddresAcc { get; set; }
        public string ZipCode { get; set; }
        public string UserCountryDest { get; set; }
    }
}
