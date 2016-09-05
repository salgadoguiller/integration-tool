﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IntegrationTool.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IntegrationToolEntities : DbContext
    {
        public IntegrationToolEntities()
            : base("name=IntegrationToolEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<ActiveDirectoryParameter> ActiveDirectoryParameters { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<DatabaseParameter> DatabaseParameters { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<FlatFileParameter> FlatFileParameters { get; set; }
        public DbSet<Header> Headers { get; set; }
        public DbSet<HeadersQueryType> HeadersQueryTypes { get; set; }
        public DbSet<IntegrationLog> IntegrationLogs { get; set; }
        public DbSet<Integration> Integrations { get; set; }
        public DbSet<IntegrationsType> IntegrationsTypes { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Query> Queries { get; set; }
        public DbSet<QueriesType> QueriesTypes { get; set; }
        public DbSet<Recurrence> Recurrences { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ServerSMTPParameter> ServerSMTPParameters { get; set; }
        public DbSet<SystemLog> SystemLogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UsersType> UsersTypes { get; set; }
        public DbSet<WebService> WebServices { get; set; }
    }
}
