//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hyk_WebApi.Models.Enityt_Framework_File
{
    using System;
    using System.Collections.Generic;
    
    public partial class LOCATION
    {
        public int ID_ { get; set; }
        public string PROVINCE_ { get; set; }
        public string CITY_ { get; set; }
        public string DISTRICT_ { get; set; }
        public string NEIGHBOURHOOD_ { get; set; }
        public string TYPE_ { get; set; }
        public int TRIPID_ { get; set; }
    
        public virtual TRIP TRIP { get; set; }
    }
}
