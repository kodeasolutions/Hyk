using Google.Geolocation.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Hyk_WebApi.Models.Tools.Google_Geolocation
{
    public class Google_Geolocation_Api
    {
        public Geolocation locate (string requestAddress)
        {
            string responseFromServer;

            try
            {
                WebRequest request = WebRequest.Create("https://maps.googleapis.com/maps/api/geocode/json?address=" + requestAddress + "&key=AIzaSyDIt9g9bq-1-VplhrYeyMzjeqwZ0S542mc");
                request.Credentials = CredentialCache.DefaultCredentials;
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
                Console.WriteLine(responseFromServer);
                reader.Close();
                response.Close();
                Console.ReadKey();

            }catch(Exception e)
            {
                return null;
            }
            
           return JsonConvert.DeserializeObject<Geolocation>(responseFromServer);
        }
    }

}