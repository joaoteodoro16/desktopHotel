﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DesktopHotel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bd_hotelariaEntities : DbContext
    {
        public bd_hotelariaEntities()
            : base("name=bd_hotelariaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<FUNCIONARIO> FUNCIONARIO { get; set; }
        public virtual DbSet<HOTEIS> HOTEIS { get; set; }
        public virtual DbSet<LOGIN> LOGIN { get; set; }
        public virtual DbSet<PRODUTOS> PRODUTOS { get; set; }
        public virtual DbSet<QUARTOS> QUARTOS { get; set; }
        public virtual DbSet<VISTORIA> VISTORIA { get; set; }
    }
}
