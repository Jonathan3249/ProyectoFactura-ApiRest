using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProyectoFactura.Models;

namespace ProyectoFactura.Context;

public partial class FacturasContext : DbContext
{
    public FacturasContext()
    {
    }

    public FacturasContext(DbContextOptions<FacturasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Observacione> Observaciones { get; set; }

    public virtual DbSet<Tarifa> Tarifas { get; set; }

    public virtual DbSet<TipoCliente> TipoClientes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.Property(e => e.NombreCompleto).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(50);
            entity.Property(e => e.NumeroContador).HasMaxLength(50);
            entity.Property(e => e.Correo).HasMaxLength(50);

            entity.HasOne(d => d.IdTipoClienteNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdTipoCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clientes_TipoCliente");
        });

        modelBuilder.Entity<Historial>(entity =>
        {
            entity.HasKey(e => e.IdHistorial);

            entity.Property(e => e.Cantidad);
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura);

            entity.ToTable("Factura");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_Clientes");

            entity.HasOne(d => d.IdObservacionesNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdObservaciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_Observaciones");

            entity.HasOne(d => d.IdTarifaNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdTarifa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_Tarifas");
        });

        modelBuilder.Entity<Observacione>(entity =>
        {
            entity.HasKey(e => e.IdObservaciones);
        });

        modelBuilder.Entity<Tarifa>(entity =>
        {
            entity.HasKey(e => e.IdTarifa);

            entity.Property(e => e.TipoTarifa).HasMaxLength(50);
        });

        modelBuilder.Entity<TipoCliente>(entity =>
        {
            entity.HasKey(e => e.IdTipoCliente);

            entity.ToTable("TipoCliente");

            entity.Property(e => e.DescripcionTipo).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
