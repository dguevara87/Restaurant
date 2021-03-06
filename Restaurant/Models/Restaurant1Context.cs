﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Restaurant.Models
{
    public partial class Restaurant1Context : DbContext
    {
        public Restaurant1Context()
        {
        }

        public Restaurant1Context(DbContextOptions<Restaurant1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<CentrosElaboracion> CentrosElaboracion { get; set; }
        public virtual DbSet<ClasificacionIngrediente> ClasificacionIngrediente { get; set; }
        public virtual DbSet<ClasificacionClientes> ClasificacionClientes { get; set; }
        public virtual DbSet<ClasificacionProducto> ClasificacionProducto { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<EstadoMesa> EstadoMesa { get; set; }
        public virtual DbSet<EstadoOrden> EstadoOrden { get; set; }
        public virtual DbSet<EstadoOrdenProducto> EstadoOrdenProducto { get; set; }
        public virtual DbSet<Ingrediente> Ingrediente { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<Mesas> Mesas { get; set; }
        public virtual DbSet<Orden> Orden { get; set; }
        public virtual DbSet<OrdenProducto> OrdenProducto { get; set; }
        public virtual DbSet<PreciosAreas> PreciosAreas { get; set; }
        public virtual DbSet<ProductoMenu> ProductoMenu { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Reservas> Reservas { get; set; }
        public virtual DbSet<Ubicacion> Ubicacion { get; set; }
        public virtual DbSet<UnidadesMedidas> UnidadesMedidas { get; set; }
        
        public DbSet<Restaurant.Models.AreaCentroElab> AreaCentroElab { get; set; }

        public DbSet<Restaurant.Models.EstadoProducto> EstadoProducto { get; set; }

        public DbSet<Restaurant.Models.IngredienteProducto> IngredienteProducto { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //***Area***
        //    modelBuilder.Entity<Area>(entity =>
        //       {
        //           entity.HasMany(d => d.AreaCentroElab);
        //           entity.HasMany(d => d.Menus);
        //           entity.HasMany(d => d.Mesas);
        //           //.WithOne(p=>p.Area).HasForeignKey(p=>p.AreaId);
        //           //entity.HasMany(d => d.Mesas)
        //           //.


        //       });

        //    //***AreaCentroElab***
        //    modelBuilder.Entity<AreaCentroElab>(entity =>
        //    {
        //        entity.HasOne(d => d.Area);
        //        entity.HasOne(d => d.CentrosElaboracion);
        //    });

        //    //***CentrosElaboracion***
        //    modelBuilder.Entity<CentrosElaboracion>(entity => 
        //    {
        //        entity.HasMany(d => d.AreaCentroElab)
        //        .WithOne(p => p.CentrosElaboracion)
        //        .HasForeignKey(p => p.CentroElaboracionId);

        //        entity.HasMany(d => d.OrdenesProductos)
        //        .WithOne(p => p.CentrosElaboracion)
        //        .HasForeignKey(p => p.CentroElaboracionId);
        //    });

        //    //***ClasificacionIngrediente***

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
