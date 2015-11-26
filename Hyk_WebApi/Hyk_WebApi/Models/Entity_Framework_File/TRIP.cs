//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hyk_WebApi.Models.Entity_Framework_File
{
    using System;
    using System.Collections.Generic;
    
    public partial class TRIP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRIP()
        {
            this.LOCATIONs = new HashSet<LOCATION>();
            this.TRIP_MATCH = new HashSet<TRIP_MATCH>();
            this.TRIP_MATCH1 = new HashSet<TRIP_MATCH>();
        }
    
        public int ID_ { get; set; }
        public System.DateTime DATE_CREATED_ { get; set; }
        public System.DateTime DATE_SCHEDULED_ { get; set; }
        public Nullable<int> PASSENGER_ID_ { get; set; }
        public Nullable<int> DRIVER_ID_ { get; set; }
        public string TICKET_NUMBER_ { get; set; }
        public int SEATS_ { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOCATION> LOCATIONs { get; set; }
        public virtual PASSENGER PASSENGER { get; set; }
        public virtual DRIVER DRIVER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRIP_MATCH> TRIP_MATCH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRIP_MATCH> TRIP_MATCH1 { get; set; }
    }
}