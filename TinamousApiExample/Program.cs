using System;
using System.Diagnostics;
using System.Threading;
using TinamousApiExample.Demos;

namespace TinamousApiExample
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                ExerciseApi();

                Console.WriteLine("Press enter try again");
                Console.ReadLine();

            } while (true);
        }

        private static void ExerciseApi()
        {
            try
            {
                //DateTimeDemo.GetDate();
                //DateTimeDemo.GetTimeZones();
                //DateTimeDemo.GetDateForTimeZone("Eastern Standard Time");

                //MeasurementsDemo.PostNewMeasurement();
                //MeasurementsDemo.PostNewMeasurementWithMetaData();
                //MeasurementsDemo.ReadMeasurements();
                //const string measurementId = "bdd8191c-0ef5-4f6c-90e3-993a7f4a218b";
                //MeasurementsDemo.ReadMeasurement(measurementId);

                StatusDemo.PostNewStatus();
                //StatusDemo.PostNewStatusWithLiteFlagSet();
                //StatusDemo.GetStatusPosts();
                
                //AlertsDemo.RaiseAlert();
                //AlertsDemo.GetAlerts();
                //// TODO: Use the id of the alert here.

                //const string alertId = "b46fddb5-a315-4682-9ba5-56ea643982b4";
                //AlertsDemo.GetAlert(alertId);
                ////AlertsDemo.ClearAlert(alertId);

                //DevicesDemo.GetDevices();

                //UserSettingsDemo.GetUserSettings();
                // TODO: Pull out the user.Id for the current user from their settings.

                //// This should be the user Id of the current user, or 
                //// if the current user is an admin, another user on the site.
                //var userId = new Guid("9087FED2-A39C-485A-9C2D-5777A671362A");

                //// Replace the forUserId Guid with the guid for a known user/device/bot
                //// to get the notification settings for the current user when the forUserId
                //// performs an action
                //var forUserId = new Guid("A95ED7E6-B48F-4927-A4E0-3F6262C1676D");

                //UserNotificationSettingsDemo.GetNotificationSettings(userId);

                //UserNotificationSettingsDemo.GetNotificationSettings(userId, userId);

                //var deviceId = new Guid("A95ED7E6-B48F-4927-A4E0-3F6262C1676D");
                //DeviceNotificationSettingsDemo.GetNotificationSettings(deviceId);
                //DeviceNotificationSettingsDemo.GetNotificationSettings(deviceId, userId);

                Thread.Sleep(10000);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
