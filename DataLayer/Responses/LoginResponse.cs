using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Responses
{
    public class LoginResponse
    {
        public string RequestMessage { get; set; }
        public bool RequestStatus { get; set; }

        public string Cookie_string { get; set; }
    }
}
