﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Hyk_Database_ModelContainer : DbContext
    {
        public Hyk_Database_ModelContainer()
            : base("name=Hyk_Database_ModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<USER> USERs { get; set; }
        public virtual DbSet<CAR> CARs { get; set; }
        public virtual DbSet<CARD> CARDs { get; set; }
        public virtual DbSet<RATING> RATINGs { get; set; }
        public virtual DbSet<LOCATION> LOCATIONs { get; set; }
        public virtual DbSet<PASSENGER> PASSENGERs { get; set; }
        public virtual DbSet<DRIVER> DRIVERs { get; set; }
        public virtual DbSet<TRIP> TRIPs { get; set; }
        public virtual DbSet<PREFERENCE> PREFERENCEs { get; set; }
        public virtual DbSet<TRIP_MATCH> TRIP_MATCH { get; set; }
    }
}