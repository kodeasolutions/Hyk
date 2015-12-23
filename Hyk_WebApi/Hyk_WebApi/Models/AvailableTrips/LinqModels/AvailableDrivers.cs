using Hyk_WebApi.Models.AvailableTrips.Models;
using Hyk_WebApi.Models.Entity_Framework_File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hyk_WebApi.Models.AvailableTrips.LinqModels
{
    public class AvailableDrivers
    {
        public List<AvailableDriverList> find(List<LOCATION> listOfRequestLocations, ref string status)
        {
            if (listOfRequestLocations == null) return null;

            LOCATION requestedStartLocation = findLocationType(listOfRequestLocations, "S");
            LOCATION requestedEndLocation = findLocationType(listOfRequestLocations, "E");
            DateTime todayDate = DateTime.Today;
            List<LOCATION> matchingLocationsFromDB;
            List<AvailableDriverList> CurrespondingUserTripFromDB;

            if ((requestedStartLocation != null) && (requestedEndLocation != null))
            {
                matchingLocationsFromDB = lookupMatchingLocationsInDB(requestedStartLocation.CITY_, requestedStartLocation.PROVINCE_, requestedEndLocation.CITY_, requestedEndLocation.PROVINCE_);

                if(matchingLocationsFromDB != null)
                {
                    CurrespondingUserTripFromDB = lookupCurrespondingUserTripInDB(matchingLocationsFromDB);
                    return CurrespondingUserTripFromDB;
                }

                if (matchingLocationsFromDB == null) //update status
                {
                    status = "NoMatchFound";
                }
            }
            return null;
        }

        private List<LOCATION> lookupMatchingLocationsInDB(string startCity, string startProvince, string endCity, string endProvince)
        {

            using (Hyk_Database_ModelContainer context = new Hyk_Database_ModelContainer())
            {
                context.Configuration.ProxyCreationEnabled = false;
                context.Configuration.LazyLoadingEnabled = false;

                List<LOCATION> resultStartLocations = (from locations in context.LOCATIONs                                                    
                                                       where locations.CITY_ == startCity
                                                       where locations.PROVINCE_ == startProvince
                                                       select locations).ToList();

                if (resultStartLocations.Any())
                {
                    List<LOCATION> resultEndStopLocations = (from locations in context.LOCATIONs
                                                             where locations.CITY_ == endCity
                                                             where locations.PROVINCE_ == endProvince
                                                             select locations).ToList();

                    if (resultEndStopLocations.Any())
                    {
                        List<LOCATION> resultMatch = (from startLocations in resultStartLocations
                                                      from endLocations in resultEndStopLocations
                                                      where startLocations.TRIPID_ == endLocations.TRIPID_
                                                      where startLocations.SEQUENCE_ <= endLocations.SEQUENCE_                                                    
                                                      select startLocations).ToList();

                        if (resultMatch.Any())
                        {
                            return resultMatch;
                        }
                    }
                }
                return null;
            }
        }

        private List<AvailableDriverList> lookupCurrespondingUserTripInDB(List<LOCATION> locations)
        {
            List<AvailableDriverList> listDriverTripInfo = new List<AvailableDriverList>();

            using (Hyk_Database_ModelContainer context = new Hyk_Database_ModelContainer())
            {
                context.Configuration.ProxyCreationEnabled = false;
                context.Configuration.LazyLoadingEnabled = false;

                foreach (LOCATION location in locations)
                {
                    List<AvailableDriverList> results = (from trips in context.TRIPs
                                                         where trips.ID_ == location.TRIPID_
                                                         where trips.DRIVER_ID_ != null
                                                         join driver in context.DRIVERs on trips.DRIVER_ID_ equals driver.ID_
                                                         select new AvailableDriverList()
                                                         {
                                                             userProfilePicture = driver.USER.PICTURE_,
                                                             userFirstName = driver.USER.FIRSTNAME_,
                                                             userPreference = driver.USER.PREFERENCE,
                                                             dateScheduled = trips.DATE_SCHEDULED_,
                                                             availableSeats = trips.SEATS_, // need to figure out a way to calculate seats
                                                             tripId = trips.ID_,
                                                         }).ToList();

                    listDriverTripInfo.AddRange(results);
                }
            }
            return listDriverTripInfo;
        }

        //gets the specified location from a request collection of location
        private LOCATION findLocationType(List<LOCATION> listOfRequestLocations, string type)
        {
            foreach (LOCATION location in listOfRequestLocations)
            {
                if (location.TYPE_.Equals(type))
                {
                    return location;
                }
            }
            return null;
        }
    }
}