using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackAgendaDeContactos.Models;

public partial class AgendaDeContactosContext : DbContext
{
    public AgendaDeContactosContext()
    {
    }

    public AgendaDeContactosContext(DbContextOptions<AgendaDeContactosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contacto> Contactos { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.IdContacto).HasName("PK__Contacto__A4D6BBFABE1CB09D");

            entity.ToTable("Contacto");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdGrupoNavigation).WithMany(p => p.Contactos)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("FK__Contacto__IdGrup__34C8D9D1");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.IdGrupo).HasName("PK__Grupo__303F6FD915523FEF");

            entity.ToTable("Grupo");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
