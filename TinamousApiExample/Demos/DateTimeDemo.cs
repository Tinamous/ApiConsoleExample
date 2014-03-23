using System;
using System.IO;
using System.Net;

namespace TinamousApiExample.Demos
{
    public class DateTimeDemo
    {
        public static string GetDate()
        {
            var request = Helpers.BuildRequest("/api/v1/DateTime");

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

        public static string GetTimeZones()
        {
            var request = Helpers.BuildRequest("/api/v1/DateTime/zones");

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

        public static string GetDateForTimeZone(string timeZoneId)
        {
            var request = Helpers.BuildRequest("/api/v1/DateTime/zones/" + timeZoneId);

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