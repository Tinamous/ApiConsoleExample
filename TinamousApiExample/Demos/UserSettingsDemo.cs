using System;
using System.IO;
using System.Net;

namespace TinamousApiExample.Demos
{
    /// <summary>
    /// Demonstrates how to get the current user settings.
    /// </summary>
    public class UserSettingsDemo
    {
        private const string Endpoint = "/api/v1/UserSettings";

        public static string GetUserSettings()
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