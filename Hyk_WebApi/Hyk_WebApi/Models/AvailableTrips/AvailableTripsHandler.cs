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
                    switch(tripRequestAddress.userType){
                        case 1: tripResponse.DriversFound = new AvailableDrivers().find(listOfRequestLocations, tripResponse.status); break; // Passenger looking for drivers
                        case 2: tripResponse.PassengersFound = new AvailablePassengers().find(listOfRequestLocations,tripResponse.status); break; //Driver looking for passengers
                        default:; break;
                    }                  
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

        if (tripRequestAddress.startLocation == null) //check the start location
        {
            tripResponse.status = "NoStartLocation";
            return false;
        }

        if (tripRequestAddress.endLocation == null) //check the end location
        {
            tripResponse.status = "NoEndLocation";
            return false;
        }
        return true;
    }

    private bool validateRequestAddressWithGoogleGeoApi(TripRequestAddresses tripRequestAddress, TripResponseList tripResponse) //works with next method
    {
        Google_Geolocation_Api google_geo_api = new Google_Geolocation_Api();
        listOfRequestGeolocations = new List<Geolocation>();
        Geolocation tempGeolocation;

        tempGeolocation = google_geo_api.locate(tripRequestAddress.startLocation); //get geoloaction of start from google
        if (!(validateGoogleApiResponse("StartLocation", tempGeolocation, tripResponse)))
        {
            return false;
        }
        listOfRequestGeolocations.Add(tempGeolocation);

        if (tripRequestAddress.userType == 2) // if looking for passengers
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
                listOfRequestGeolocations.Add(tempGeolocation);
            }
        }
        
        tempGeolocation = google_geo_api.locate(tripRequestAddress.endLocation); //get geoloaction of end from google
        if (!(validateGoogleApiResponse("EndLocation", tempGeolocation, tripResponse)))
        {
            return false;
        }
        listOfRequestGeolocations.Add(tempGeolocation);

        return true;
    }

    private bool validateGoogleApiResponse(String message, Geolocation geoloaction, TripResponseList tripResponse)
    {
        if (geoloaction == null)
        {
            tripResponse.status = "GoogleGeoloactionUnavailable";
            return false;
        }

        if (!(geoloaction.status.Equals("OK")))
        {
            tripResponse.status = "Invalid" + message;
            return false;
        }
        return true;
    }

    private bool convertGeoloactionToLocationTableObject()
    {
        listOfRequestLocations = new List<LOCATION>();
        LOCATION location;
        Geolocation[] tempArrayOfGeolocations = listOfRequestGeolocations.ToArray();

        
        for(int i = 0; i < tempArrayOfGeolocations.Length; i++)
        {
            location = new LOCATION();
            location.ID_ = 0;
            location.SEQUENCE_ = i;
            location.NEIGHBOURHOOD_ = findCorrespondingLocationAttribute("sublocality_level_1", tempArrayOfGeolocations[i]);
            location.CITY_= findCorrespondingLocationAttribute("locality", tempArrayOfGeolocations[i]);
            location.DISTRICT_ = findCorrespondingLocationAttribute("administrative_area_level_2", tempArrayOfGeolocations[i]);
            location.PROVINCE_ = findCorrespondingLocationAttribute("administrative_area_level_1", tempArrayOfGeolocations[i]);

            if (i == 0)
            {
                location.TYPE_ = "S";
            }else if(i == tempArrayOfGeolocations.Length - 1){
                location.TYPE_ = "E";
            } else{
                location.TYPE_ = "O";
            }

            listOfRequestLocations.Add(location);
        }
        return true;
    }//works with next method

    private string findCorrespondingLocationAttribute(string nameOfAttribute, Geolocation geolocation)
    {
        foreach(AddressComponent addressComponent  in geolocation.results[0].address_components)
        {
            foreach(string type in addressComponent.types)
            {
                if (nameOfAttribute.Equals(type))
                {
                    return addressComponent.long_name;
                }
            }
        }

        return null;
    }
}