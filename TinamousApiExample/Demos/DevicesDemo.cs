using System;
using System.IO;
using System.Net;

namespace TinamousApiExample.Demos
{
    public class DevicesDemo
    {
        private const string Endpoint = "/api/v1/Devices";

        /// <summary>
        /// Demonstrates how to get a list of devices associated with the Tinamous account
        /// </summary>
        public static string GetDevices()
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
    }
}