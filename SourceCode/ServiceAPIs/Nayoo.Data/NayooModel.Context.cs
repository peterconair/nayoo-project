﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nayoo.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NayooDbEntities : DbContext
    {
        public NayooDbEntities()
            : base("name=NayooDbEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<house_member> house_member { get; set; }
        public virtual DbSet<med_image> med_image { get; set; }
        public virtual DbSet<med_video> med_video { get; set; }
        public virtual DbSet<mst_contact> mst_contact { get; set; }
        public virtual DbSet<mst_document> mst_document { get; set; }
        public virtual DbSet<mst_house> mst_house { get; set; }
        public virtual DbSet<mst_layout> mst_layout { get; set; }
        public virtual DbSet<mst_location> mst_location { get; set; }
        public virtual DbSet<mst_map> mst_map { get; set; }
        public virtual DbSet<mst_organization> mst_organization { get; set; }
        public virtual DbSet<mst_spec> mst_spec { get; set; }
        public virtual DbSet<mst_user> mst_user { get; set; }
        public virtual DbSet<mst_village> mst_village { get; set; }
        public virtual DbSet<opt_guest_record> opt_guest_record { get; set; }
        public virtual DbSet<opt_inbox_message> opt_inbox_message { get; set; }
        public virtual DbSet<opt_taxi_call> opt_taxi_call { get; set; }
    }
}
