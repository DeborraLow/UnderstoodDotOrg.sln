﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnderstoodDotOrg.Domain.Membership
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Membership : DbContext
    {
        public Membership()
            : base("name=Membership")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Child> Children { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}
