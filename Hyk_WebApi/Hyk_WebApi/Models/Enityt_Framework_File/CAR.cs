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
    
    public partial class CAR
    {
        public string NUMBER_PLATE_ { get; set; }
        public string MAKE_ { get; set; }
        public string MODEL_ { get; set; }
        public string COLOUR_ { get; set; }
        public string PICTURE_ { get; set; }
        public int MAX_SEATS_ { get; set; }
        public string PROVINCIAL_MARK_ { get; set; }
        public string PROVINCE_ { get; set; }
        public int DRIVER_ID_ { get; set; }
        public System.DateTime DATE_ADDED_ { get; set; }
        public int ID_ { get; set; }
    
        public virtual DRIVER DRIVER { get; set; }
    }
}
