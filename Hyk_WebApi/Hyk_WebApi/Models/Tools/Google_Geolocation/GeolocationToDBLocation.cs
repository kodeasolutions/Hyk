using Google.Geolocation.Api;
using Hyk_WebApi.Models.Entity_Framework_File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hyk_WebApi.Models.Tools.Google_Geolocation
{


    public class GeolocationToDBLocation
    { 
        public LOCATION convert(Geolocation RequestGeolocations, int sequenceNumber = 0, int sequenceNumberOflastLocation = 1)
        {
            LOCATION location = new LOCATION();

            location.ID_ = 0;
            location.NEIGHBOURHOOD_ = findCorrespondingLocationAttribute("sublocality_level_1", RequestGeolocations);
            location.CITY_ = findCorrespondingLocationAttribute("locality", RequestGeolocations);
            location.DISTRICT_ = findCorrespondingLocationAttribute("administrative_area_level_2", RequestGeolocations);
            location.PROVINCE_ = findCorrespondingLocationAttribute("administrative_area_level_1", RequestGeolocations);
            location.SEQUENCE_ = sequenceNumber;

            if (location.SEQUENCE_ == 0)
            {
                location.TYPE_ = "S";
            }
            else if (location.SEQUENCE_ == sequenceNumberOflastLocation)
            {
                location.TYPE_ = "E";
            }
            else
            {
                location.TYPE_ = "O";
            }

            return location;
        }

        private string findCorrespondingLocationAttribute(string nameOfAttribute, Geolocation geolocation)
        {
            foreach (AddressComponent addressComponent in geolocation.results[0].address_components)
            {
                foreach (string type in addressComponent.types)
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
}