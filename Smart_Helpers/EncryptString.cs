﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Smart_Helpers
{
    public class EncryptString
    {
        public static string HashGen(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            var originalBytes = Encoding.Default.GetBytes(password + "shopDataT14");
            var encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes).Replace("-", "").ToLower();


        }
    }
}
