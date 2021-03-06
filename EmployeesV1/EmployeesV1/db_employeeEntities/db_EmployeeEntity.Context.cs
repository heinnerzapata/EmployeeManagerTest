﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace db_employeeEntities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DB_A162E1_zemogatestEntities : DbContext
    {
        public DB_A162E1_zemogatestEntities()
            : base("name=DB_A162E1_zemogatestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
    
        public virtual int EmployeeCRUD(string oP, string emploId, string emploPicture, string emploName, string emploPosition, string emploProj)
        {
            var oPParameter = oP != null ?
                new ObjectParameter("OP", oP) :
                new ObjectParameter("OP", typeof(string));
    
            var emploIdParameter = emploId != null ?
                new ObjectParameter("EmploId", emploId) :
                new ObjectParameter("EmploId", typeof(string));
    
            var emploPictureParameter = emploPicture != null ?
                new ObjectParameter("EmploPicture", emploPicture) :
                new ObjectParameter("EmploPicture", typeof(string));
    
            var emploNameParameter = emploName != null ?
                new ObjectParameter("EmploName", emploName) :
                new ObjectParameter("EmploName", typeof(string));
    
            var emploPositionParameter = emploPosition != null ?
                new ObjectParameter("EmploPosition", emploPosition) :
                new ObjectParameter("EmploPosition", typeof(string));
    
            var emploProjParameter = emploProj != null ?
                new ObjectParameter("EmploProj", emploProj) :
                new ObjectParameter("EmploProj", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EmployeeCRUD", oPParameter, emploIdParameter, emploPictureParameter, emploNameParameter, emploPositionParameter, emploProjParameter);
        }
    
        public virtual ObjectResult<getPositions_Result> getPositions()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getPositions_Result>("getPositions");
        }
    
        public virtual ObjectResult<getProjects_Result> getProjects()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getProjects_Result>("getProjects");
        }
    }
}
