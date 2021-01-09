namespace WebServer.Server.Common
{
    using System;

    public static class CoreValidator
    {
        public static void ThrowIfNull(object obj, string name)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        public static void ThrowIfNullOrEmpty(string value, string name)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException($"{name} cannot be null or empty.");
            }
        }
    }
}
