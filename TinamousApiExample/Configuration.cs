using System;
using System.Configuration;

namespace TinamousApiExample
{
    public static class Configuration
    {
        public static Uri GetUri()
        {
            string scheme = GetScheme();
            string accountName = GetAccountName();
            string domain = GetDomain();

            Uri uri = new Uri(scheme + accountName + domain);
            return uri;
        }

        /// <summary>
        /// Gets the Tinamous.com account name, this is the account name given 
        /// at registration time and the subdomain used to access your Tinamous.com 
        /// account (e.g. for https://demo.tinamous.com the accout name is demo.
        /// </summary>
        /// <returns></returns>
        private static string GetAccountName()
        {
            return ConfigurationManager.AppSettings["Tinamous.AccountName"];
        }

        /// <summary>
        /// This defaults to .Tinamous.com and is only here for easy of testing
        /// Tinamous.com and this project development on localhost.
        /// </summary>
        /// <returns></returns>
        private static string GetDomain()
        {
            return ConfigurationManager.AppSettings["Tinamous.Domain"] ?? ".Tinamous.com";
        }

        /// <summary>
        /// Defaults to https but Tinamous.com api will accept http, but be aware it
        /// is a very bad idea to use just http, however some microcontrollers will
        /// not handle https. You should lock down any account that is used for 
        /// devices working using only http to be as restrictive as possible.
        /// </summary>
        /// <returns></returns>
        private static string GetScheme()
        {
            if (ConfigurationManager.AppSettings["Tinamous.UseHttps"] != null)
            {
                if (!Convert.ToBoolean(ConfigurationManager.AppSettings["Tinamous.UseHttps"]))
                {
                    return "http://";
                }
            }
            return "https://";
        }

        public static string GetUserName()
        {
            return ConfigurationManager.AppSettings["Tinamous.UserName"];
        }

        public static string GetPassword()
        {
            return ConfigurationManager.AppSettings["Tinamous.Password"];
        }
    }
}