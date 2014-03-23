using System;
using System.IO;
using System.Net;

namespace TinamousApiExample.Demos
{
    public class DeviceNotificationSettingsDemo
    {
        private const string Endpoint = "/api/v1/Device/{0}/NotificationSettings";

        public static string GetNotificationSettings(Guid userId)
        {
            var request = Helpers.BuildRequest(string.Format(Endpoint, userId.ToString("N")));
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

        /// <summary>
        /// Gets the notification settings that are setup for the user userId
        /// to be notified by actions made by forUserId
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="forUserId"></param>
        /// <returns></returns>
        public static string GetNotificationSettings(Guid userId, Guid forUserId)
        {
            var request = Helpers.BuildRequest(string.Format(Endpoint + "/{1}",
                                                                userId.ToString("N"),
                                                                forUserId.ToString("N")));
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