using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MVC5Course.Models
{
    internal class 產品名稱至少包含一個大寫字元Attribute : DataTypeAttribute
    {
        public 產品名稱至少包含一個大寫字元Attribute() : base(DataType.Text)
        {

        }
        public override bool IsValid(object data)
        {
            string str = (string)data;
            Regex regex = new Regex("^.*[A-Z]");

            return regex.IsMatch(str);
        }
    }
}