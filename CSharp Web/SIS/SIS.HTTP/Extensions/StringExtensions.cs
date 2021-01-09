namespace SIS.HTTP.Extensions
{
    using System;

    public static class StringExtensions
    {
        public static string Capitalize(this string str)
        {
            return Char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }
    }
}
