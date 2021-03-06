﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace FashionShop.Common
{
    public class MaHoaMD5
    {
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            try
            {
                byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

                for (int i = 0; i < bytes.Length; i++)
                {
                    hash.Append(bytes[i].ToString("x2"));
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return hash.ToString();
        }
    }
}