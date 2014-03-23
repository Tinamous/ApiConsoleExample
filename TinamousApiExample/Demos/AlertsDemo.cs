using System;
using System.IO;
using System.Net;
using System.Text;

namespace TinamousApiExample.Demos
{
    public class AlertsDemo
    {
        private const string Endpoint = "/api/v1/Alerts";

        public static string RaiseAlert()
        {
            const string postContent = "{ \"Message\" : \"Simple Alert!\", " +
                                       "\"Level\" : \"Critical\", " +
                                       "\"Distribution\" : \"All\", " +
                                       "\"ActionRequired\":\"true\"}";

            byte[] bytes = Encoding.UTF8.GetBytes(postContent);

            var request = Helpers.BuildRequest(Endpoint);
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

        public static string GetAlerts()
        {
            var request = Helpers.BuildRequest(Endpoint);
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


        public static string GetAlert(string alertId)
        {
            var request = Helpers.BuildRequest(Endpoint + "/" + alertId);
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

        public static string ClearAlert(string alertId)
        {
            string postContent = "{ \"Cleared\" : \"true\", " +
                                 "\"ActionRequired\":\"false\"}";

            postContent += "\n\r";
            postContent += "\n\r";

            byte[] bytes = Encoding.UTF8.GetBytes(postContent);

            var request = Helpers.BuildRequest(Endpoint + "/" + alertId);
            Helpers.AddAuthenticationHeaders(request);

            request.Method = "PUT";
            request.ContentType = "application/json";
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }

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