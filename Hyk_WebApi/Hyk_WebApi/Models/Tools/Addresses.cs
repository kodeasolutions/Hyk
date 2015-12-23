using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hyk_WebApi.Models.Tools
{
    public class Addresses
    {
        public string startLocation { get; set; } //start loaction
        public List<string> stopLocation { get; set; } //stop location
        public string endLocation { get; set; } //end location
    }
}