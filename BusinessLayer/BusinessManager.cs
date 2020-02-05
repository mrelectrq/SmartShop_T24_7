using BusinessLayer.Interfaces;
using BusinessLayer.Level;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class BusinessManager
    {
        public ILogging GetLogging()
        {
            return new UserBL();
        }
    }
}
