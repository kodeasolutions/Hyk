using Google.Geolocation.Api;
using Hyk_WebApi.Models.AvailableTrips.Models;
using Hyk_WebApi.Models.Tools.Google_Geolocation;
using System;
using System.Collections;

public class AvailableTripsHandler
{
    public ArrayList arrayGeolocations;

    public TripResponseList findTrips(TripRequestAddresses tripRequestAddress)
    {
        TripResponseList tripResponse = new TripResponseList();
        tripResponse.status = "";

        if (validateRequest(tripRequestAddress, tripResponse))
        {
            if (validateRequestAddressWithGoogle(tripRequestAddress, tripResponse))
            {

            }
        }

        return tripResponse;
    }

    public bool validateRequest(TripRequestAddresses tripRequestAddress, TripResponseList tripResponse)
    {
        if (tripRequestAddress == null)  //check the request
        {
            tripResponse.status = "No Request";
            return false;
        }

        if (tripRequestAddress.userType == 0)  //check user type
        {
            tripResponse.status = "No User type";
            return false;
        }

        if (tripRequestAddress.startLocation == null) //check the start location
        {
            tripResponse.status = "No Start Location";
            return false;
        }

        if (tripRequestAddress.endLocation == null) //check the end location
        {
            tripResponse.status = "No Start Location";
            return false;
        }
        return true;
    }

    public bool validateRequestAddressWithGoogle(TripRequestAddresses tripRequestAddress, TripResponseList tripResponse)
    {
        Google_Geolocation_Api google_geo_api = new Google_Geolocation_Api();
        arrayGeolocations = new ArrayList();
        Geolocation tempGeolocation;

        tempGeolocation = google_geo_api.locate(tripRequestAddress.startLocation); //get geoloaction of start from google
        if (!(validateGoogleApiResponse("StartLocation", tempGeolocation, tripResponse)))
        {
            return false;
        }
        arrayGeolocations.Add(tempGeolocation);

        if (tripRequestAddress.stopLocation != null) //get geolocation of stops from google
        {
            int index = 0;
            foreach (string requestAddress in tripRequestAddress.stopLocation)
            {
                index++;
                tempGeolocation = google_geo_api.locate(requestAddress);
                if (!(validateGoogleApiResponse("StopLocation" + index, tempGeolocation, tripResponse)))
                {
                    return false;
                }
                arrayGeolocations.Add(tempGeolocation);
            }
        }

        tempGeolocation = google_geo_api.locate(tripRequestAddress.endLocation); //get geoloaction of start from google
        if (!(validateGoogleApiResponse("EndLocation", tempGeolocation, tripResponse)))
        {
            return false;
        }
        arrayGeolocations.Add(tempGeolocation);

        return true;
    }

    public bool validateGoogleApiResponse(String message, Geolocation geoloaction, TripResponseList tripResponse)
    {
        if (geoloaction == null)
        {
            tripResponse.status = "GoogleGeoloactionUnavailable";
            return false;
        }

        if (geoloaction.status.Equals(""))
        {
            tripResponse.status = "Invalid" + message;
            return false;
        }
        return true;
    }
}