using Google.Geolocation.Api;
using Hyk_WebApi.Models.AvailableTrips.LinqModels;
using Hyk_WebApi.Models.AvailableTrips.Models;
using Hyk_WebApi.Models.Entity_Framework_File;
using Hyk_WebApi.Models.Tools.Google_Geolocation;
using System;
using System.Collections;
using System.Collections.Generic;

public class AvailableTripsHandler
{
    private List<Geolocation> listOfRequestGeolocations;
    private List<LOCATION> listOfRequestLocations;

    public TripResponseList findTrips(TripRequestAddresses tripRequestAddress)
    {
        TripResponseList tripResponse = new TripResponseList();
        tripResponse.status = "OK";

        if (validateRequest(tripRequestAddress, tripResponse))
        {
            if (validateRequestAddressWithGoogleGeoApi(tripRequestAddress, tripResponse))
            {
                if (convertGeoloactionToLocationTableObject())
                {
                    string status = tripResponse.status; //To pass by ref
                    switch (tripRequestAddress.userType)
                    {
                        case 1: tripResponse.DriversFound = new AvailableDrivers().find(listOfRequestLocations,ref status); break; // Passenger looking for drivers
                        case 2: tripResponse.PassengersFound = new AvailablePassengers().find(listOfRequestLocations,ref status); break; //Driver looking for passengers
                        default:; break;
                    }
                    tripResponse.status = status;
                }
            }
        }
        return tripResponse;
    }

    private bool validateRequest(TripRequestAddresses tripRequestAddress, TripResponseList tripResponse)
    {
        if (tripRequestAddress == null)  //check the request
        {
            tripResponse.status = "BadRequest";
            return false;
        }

        if (tripRequestAddress.userType == 0)  //check user type
        {
            tripResponse.status = "NoUserType";
            return false;
        }

        if (tripRequestAddress.addresses.startLocation == null) //check the start location
        {
            tripResponse.status = "NoStartLocation";
            return false;
        }

        if (tripRequestAddress.addresses.endLocation == null) //check the end location
        {
            tripResponse.status = "NoEndLocation";
            return false;
        }
        return true;
    }

    private bool validateRequestAddressWithGoogleGeoApi(TripRequestAddresses tripRequestAddress, TripResponseList tripResponse)
    {

        string status = tripResponse.status; // to pass by ref
        listOfRequestGeolocations = new AddressStringToGeolocation().convert(tripRequestAddress.addresses, ref status);
        tripResponse.status = status;

        if (listOfRequestGeolocations == null) return false;
        return true;
    }

    private bool convertGeoloactionToLocationTableObject()
    {
        listOfRequestLocations = new List<LOCATION>();
        Geolocation[] tempArrayOfGeolocations = listOfRequestGeolocations.ToArray();

        for (int i = 0; i < tempArrayOfGeolocations.Length; i++)
        {
            LOCATION location = new GeolocationToDBLocation().convert(tempArrayOfGeolocations[i], i, tempArrayOfGeolocations.Length - 1); // fills in location information (e.g. province...)
            listOfRequestLocations.Add(location);
        }
        return true;
    }
}