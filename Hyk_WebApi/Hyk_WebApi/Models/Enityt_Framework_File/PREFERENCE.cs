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
    
    public partial class PREFERENCE
    {
        public int ID_ { get; set; }
        public bool SMOKING_ { get; set; }
        public bool FOOD_ { get; set; }
        public bool PETS_ { get; set; }
    
        public virtual USER USER { get; set; }
    }
}
