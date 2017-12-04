using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace QuanLyThueXe.Helpers
{
    public class Helper
    {
        public static decimal ParseDecimal(string input)
        {
            return decimal.Parse(Regex.Replace(input, @"[.]", ""));
        }
    }
}