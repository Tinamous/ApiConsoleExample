using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace TinamousApiExample
{
    public static class Helpers
    {
        private static readonly Uri BaseUri;
        private static readonly string Username = "";
        private static readonly string Password = "";

        static Helpers()
        {
            BaseUri = Configuration.GetUri();
            Trace.WriteLine("BaseUri: " + BaseUri);

            Username = Configuration.GetUserName();
            Password = Configuration.GetPassword();
        }

        public static HttpWebRequest BuildRequest(string apiUri)
        {
            var uri = new Uri(BaseUri, apiUri);
            Trace.WriteLine("Using Api Uri: " + uri);
            return (HttpWebRequest)HttpWebRequest.Create(uri);
        }

        public static string ReadResponseStream(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException("stream");

            using (TextReader reader = new StreamReader(stream))
            {
                string read = reader.ReadToEnd();
                Console.WriteLine(read);
                Debug.WriteLine(read);
                return read;
            }
        }

        public static void AddAuthenticationHeaders(HttpWebRequest request)
        {
            var auth = GetAuthHeaderValue(Username, Password);
            request.Headers.Add("Authorization", auth);
        }

        private static string GetAuthHeaderValue(string user, string password)
        {
            string userPassword = user + ":" + password;
            var encoding = Encoding.GetEncoding("iso-8859-1");
            byte[] bytes = encoding.GetBytes(userPassword);
            return "Basic " + Convert.ToBase64String(bytes);
        }
    }
}