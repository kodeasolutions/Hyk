using Hyk_WebApi.Models.AvailableTrips.Models;
using Hyk_WebApi.Models.Entity_Framework_File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hyk_WebApi.Models.AvailableTrips.LinqModels
{
    public class AvailablePassengers
    {
        List<List<LOCATION>> resultOfLocationsFromDB = new List<List<LOCATION>>();
        List<LOCATION> matchingLocationsFromDB = new List<LOCATION>();
        List<AvailablePassengersList> CurrespondingUserTripFromDB = new List<AvailablePassengersList>();


        public List<AvailablePassengersList> find(List<LOCATION> listOfRequestLocations, ref string status)
        {
            if (listOfRequestLocations == null) return null;

            matchingLocationsFromDB = lookupMatchingLocationsInDB(listOfRequestLocations);

            if (matchingLocationsFromDB != null) //continue with operation
            {
                CurrespondingUserTripFromDB = lookupCurrespondingUserTripInDB(matchingLocationsFromDB);
                return CurrespondingUserTripFromDB;
            }

            if (matchingLocationsFromDB == null) //update status
            {
                status = "NoMatchFound";
            }
            
            return null;
        }

        private List<LOCATION> lookupMatchingLocationsInDB(List<LOCATION> listOfRequestLocations)
        {
            List<LOCATION> tempMatch = new List<LOCATION>();

            using (Hyk_Database_ModelContainer context = new Hyk_Database_ModelContainer())
            {
                context.Configuration.ProxyCreationEnabled = false;
                context.Configuration.LazyLoadingEnabled = false;

                foreach (LOCATION requestedlocation in listOfRequestLocations)
                {
                    List<LOCATION> locationsFromDB = (from dbLocations in context.LOCATIONs
                                                      where dbLocations.CITY_ == requestedlocation.CITY_
                                                      where dbLocations.PROVINCE_ == requestedlocation.PROVINCE_
                                                      select dbLocations).ToList();
                    if (locationsFromDB.Any())
                    {
                        resultOfLocationsFromDB.Add(locationsFromDB);
                    }
                }

                if (resultOfLocationsFromDB.Count > 1)
                {
                    LOCATION[][] arraysLocation = resultOfLocationsFromDB.Select(a => a.ToArray()).ToArray();

                    for (int a = 0; a < arraysLocation.Length - 1; a++)
                    {
                        for (int b = a + 1; b < arraysLocation.Length; b++)
                        {
                            List<LOCATION> resultMatch = (from startLocations in arraysLocation[a]
                                                          from endLocations in arraysLocation[b]
                                                          where startLocations.TRIPID_ == endLocations.TRIPID_
                                                          where startLocations.SEQUENCE_ <= endLocations.SEQUENCE_
                                                          select startLocations).ToList();

                            if (resultMatch.Any())
                            {
                                tempMatch.AddRange(resultMatch);
                            }
                        }
                    }
                    if(tempMatch.Any())return tempMatch;
                }
            }     
            return null;
        }

        private List<AvailablePassengersList> lookupCurrespondingUserTripInDB(List<LOCATION> locations)
        {
            List<AvailablePassengersList> listDriverTripInfo = new List<AvailablePassengersList>();
            using (Hyk_Database_ModelContainer context = new Hyk_Database_ModelContainer())
            {
                context.Configuration.ProxyCreationEnabled = false;
                context.Configuration.LazyLoadingEnabled = false;

                foreach (LOCATION location in locations)
                {
                    List<AvailablePassengersList> results = (from trips in context.TRIPs
                                                             where trips.ID_ == location.TRIPID_
                                                             where trips.PASSENGER_ID_ != null
                                                             join passengers in context.PASSENGERs on trips.PASSENGER_ID_ equals passengers.ID_
                                                             select new AvailablePassengersList()
                                                             {
                                                                 userProfilePicture = passengers.USER.PICTURE_,
                                                                 userFirstName = passengers.USER.FIRSTNAME_,
                                                                 userPreference = passengers.USER.PREFERENCE,
                                                                 dateScheduled = trips.DATE_SCHEDULED_,
                                                                 availableSeats = trips.SEATS_, // need to figure out a way to calculate seats
                                                                 tripId = trips.ID_,
                                                             }).ToList();

                    listDriverTripInfo.AddRange(results);
                }
            }
            return listDriverTripInfo;
        }
    }
}
