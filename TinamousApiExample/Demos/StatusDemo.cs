using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace TinamousApiExample.Demos
{
    public class StatusDemo
    {
        public static string PostNewStatus()
        {
            const string postContent = "{ \"Message\" : \"simple test message from the .Net TinamousApiExample\"}";

            byte[] bytes = Encoding.UTF8.GetBytes(postContent);

            var request = Helpers.BuildRequest("/api/v1/Status");
            Helpers.AddAuthenticationHeaders(request);

            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }

            var response = request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                return Helpers.ReadResponseStream(stream);
            }
        }

        /// <summary>
        /// By setting the Lite flag the response will not include the 
        /// model object as saved by the POST, only the header will be set to the location
        /// </summary>
        /// <returns></returns>
        public static string PostNewStatusWithLiteFlagSet()
        {
            const string postContent = "{ \"Message\" : \"simple test message from the .Net TinamousApiExample\", \"Lite\":\"true\"}";

            byte[] bytes = Encoding.UTF8.GetBytes(postContent);

            var request = Helpers.BuildRequest("/api/v1/Status");
            Helpers.AddAuthenticationHeaders(request);

            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }

            var response = request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                return Helpers.ReadResponseStream(stream);
            }
        }

        public static string GetStatusPosts()
        {
            string startDate = "2013-10-10T21:51:30";
            startDate = HttpUtility.UrlEncode(startDate);

            var request = Helpers.BuildRequest("/api/v1/Status?startDate=" + startDate);
            Helpers.AddAuthenticationHeaders(request);

            try
            {
                var response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    return Helpers.ReadResponseStream(stream);
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
                throw;
            }
        }
    }
}