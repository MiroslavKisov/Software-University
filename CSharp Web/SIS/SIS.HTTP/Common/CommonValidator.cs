namespace SIS.HTTP.Common
{
    using System;

    public static class CommonValidator
    {
        public static void ValidateObject(object obj, string nameOfObject)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(string.Format(Messages.NotValidObject), nameOfObject);
            }
        }

        public static void ValidateString(string str, string nameOfString)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException(string.Format(Messages.NotValidString), nameOfString);
            }
        }
    }
}
