using System;
using System.IO;
using System.Net;
using System.Text;

namespace TinamousApiExample.Demos
{
    public class MeasurementsDemo
    {
        public static string PostNewMeasurement()
        {
            const string postContent = "{ \"field1\" : \"21.8\", \"field2\": \"64.9\"}";

            byte[] bytes = Encoding.UTF8.GetBytes(postContent);

            var request = Helpers.BuildRequest("/api/v1/Measurements");
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

        public static string PostNewMeasurementWithMetaData()
        {
            const string postContent = "{ \"Field1\" : \"22.8\", " +
                                       "\"Tags\": \"Tag1,Tag2\", " +
                                       "\"SampleId\": \"Sample1\", " +
                                       "\"Latitude\": \"12.34\", " +
                                       "\"Longitude\": \"56.78\", " +
                                       "\"Elevation\": \"90.12\" " +
                                       "}";

            byte[] bytes = Encoding.UTF8.GetBytes(postContent);

            var request = Helpers.BuildRequest("/api/v1/Measurements");
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

        public static string ReadMeasurements()
        {
            var request = Helpers.BuildRequest("/api/v1/Measurements");
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

        public static string ReadMeasurement(string id)
        {
            var request = Helpers.BuildRequest("/api/v1/Measurements/" + id);
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