﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCLOGIN2.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class sisEntities : DbContext
    {
        public sisEntities()
            : base("name=sisEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<admin> admins { get; set; }
        public virtual DbSet<annoucement> annoucements { get; set; }
        public virtual DbSet<cours> courses { get; set; }
        public virtual DbSet<department> departments { get; set; }
        public virtual DbSet<faculty> faculties { get; set; }
        public virtual DbSet<forum> fora { get; set; }
        public virtual DbSet<given> givens { get; set; }
        public virtual DbSet<grade> grades { get; set; }
        public virtual DbSet<instructor> instructors { get; set; }
        public virtual DbSet<message> messages { get; set; }
        public virtual DbSet<student> students { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<take> takes { get; set; }
    }
}
