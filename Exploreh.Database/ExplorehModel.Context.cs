﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Exploreh.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ExplorehEntities : DbContext
    {
        public ExplorehEntities()
            : base("name=ExplorehEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<ClienteContato> ClienteContato { get; set; }
        public virtual DbSet<ClienteTelefone> ClienteTelefone { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<PerfilTela> PerfilTela { get; set; }
        public virtual DbSet<TblBairro> TblBairro { get; set; }
        public virtual DbSet<TblCidade> TblCidade { get; set; }
        public virtual DbSet<TblLogradouro> TblLogradouro { get; set; }
        public virtual DbSet<TblPais> TblPais { get; set; }
        public virtual DbSet<TblUnidadeFederacao> TblUnidadeFederacao { get; set; }
        public virtual DbSet<Tela> Tela { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<ClienteEndereco> ClienteEndereco { get; set; }
    }
}
