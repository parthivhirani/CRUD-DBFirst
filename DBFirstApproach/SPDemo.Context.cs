﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBFirstApproach
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SampleDBEntities3 : DbContext
    {
        public SampleDBEntities3()
            : base("name=SampleDBEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<string> addTwoNumbers(Nullable<int> no1, Nullable<int> no2)
        {
            var no1Parameter = no1.HasValue ?
                new ObjectParameter("no1", no1) :
                new ObjectParameter("no1", typeof(int));
    
            var no2Parameter = no2.HasValue ?
                new ObjectParameter("no2", no2) :
                new ObjectParameter("no2", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("addTwoNumbers", no1Parameter, no2Parameter);
        }
    
        public virtual ObjectResult<getGetEmployee_Result> getGetEmployee()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getGetEmployee_Result>("getGetEmployee");
        }
    }
}
