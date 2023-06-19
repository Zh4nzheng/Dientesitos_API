using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dientesitos_API.Model;

public partial class DientesC : DbContext
{
    public DientesC()
    {
    }

    public DientesC(DbContextOptions<DientesC> options)
        : base(options)
    {
    }

    public virtual DbSet<CitaDental> CitaDentals { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<HistorialMedico> HistorialMedicos { get; set; }

    public virtual DbSet<MaterialMedico> MaterialMedicos { get; set; }

    public virtual DbSet<MaterialTratamiento> MaterialTratamientos { get; set; }

    public virtual DbSet<Medicamento> Medicamentos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Recetum> Receta { get; set; }

    public virtual DbSet<Sede> Sedes { get; set; }

    public virtual DbSet<Tratamiento> Tratamientos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-PGHFFJAF\\SQLEXPRESS;Initial Catalog=DB_Dientesitos;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CitaDental>(entity =>
        {
            entity.HasKey(e => e.Idcita).HasName("PK__CitaDent__36D350AB83F8E07A");

            entity.ToTable("CitaDental");

            entity.Property(e => e.Idcita).HasColumnName("IDCita");
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Hora).HasPrecision(0);
            entity.Property(e => e.Iddoctor).HasColumnName("IDDoctor");
            entity.Property(e => e.Idpaciente).HasColumnName("IDPaciente");
            entity.Property(e => e.Idsede).HasColumnName("IDSede");
            entity.Property(e => e.Idtratamiento).HasColumnName("IDTratamiento");
            entity.Property(e => e.ImportePagar).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.IddoctorNavigation).WithMany(p => p.CitaDentals)
                .HasForeignKey(d => d.Iddoctor)
                .HasConstraintName("FK__CitaDenta__IDDoc__48CFD27E");

            entity.HasOne(d => d.IdpacienteNavigation).WithMany(p => p.CitaDentals)
                .HasForeignKey(d => d.Idpaciente)
                .HasConstraintName("fk_cita_paciente");

            entity.HasOne(d => d.IdsedeNavigation).WithMany(p => p.CitaDentals)
                .HasForeignKey(d => d.Idsede)
                .HasConstraintName("FK__CitaDenta__IDSed__4AB81AF0");

            entity.HasOne(d => d.IdtratamientoNavigation).WithMany(p => p.CitaDentals)
                .HasForeignKey(d => d.Idtratamiento)
                .HasConstraintName("FK__CitaDenta__IDTra__4BAC3F29");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Iddoctor).HasName("PK__Doctor__A4F7F9ECF19732E9");

            entity.ToTable("Doctor");

            entity.Property(e => e.Iddoctor).HasColumnName("IDDoctor");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Constrasena)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Dni)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Especialidad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroColegioMedico)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Idfactura).HasName("PK__Factura__492FE93925A9ACE6");

            entity.ToTable("Factura");

            entity.Property(e => e.Idfactura).HasColumnName("IDFactura");
            entity.Property(e => e.Idcita).HasColumnName("IDCita");
            entity.Property(e => e.Igv).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TotalPagar).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.IdcitaNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.Idcita)
                .HasConstraintName("FK__Factura__IDCita__4CA06362");
        });

        modelBuilder.Entity<HistorialMedico>(entity =>
        {
            entity.HasKey(e => e.Idhistorial).HasName("PK__Historia__C4BEFB698C374841");

            entity.ToTable("HistorialMedico");

            entity.Property(e => e.Idhistorial).HasColumnName("IDHistorial");
            entity.Property(e => e.Alergias)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Detalles)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Idpaciente).HasColumnName("IDPaciente");
            entity.Property(e => e.Resultado)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdpacienteNavigation).WithMany(p => p.HistorialMedicos)
                .HasForeignKey(d => d.Idpaciente)
                .HasConstraintName("fk_historia_paciente");
        });

        modelBuilder.Entity<MaterialMedico>(entity =>
        {
            entity.HasKey(e => e.Idmaterial).HasName("PK__Material__C343DC5DC0E353EC");

            entity.ToTable("MaterialMedico");

            entity.Property(e => e.Idmaterial).HasColumnName("IDMaterial");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MaterialTratamiento>(entity =>
        {
            entity.HasKey(e => new { e.Idmaterial, e.Idtratamiento });

            entity.ToTable("MaterialTratamiento");

            entity.Property(e => e.Idmaterial).HasColumnName("IDMaterial");
            entity.Property(e => e.Idtratamiento).HasColumnName("IDTratamiento");

            entity.HasOne(d => d.IdmaterialNavigation).WithMany(p => p.MaterialTratamientos)
                .HasForeignKey(d => d.Idmaterial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaterialDetall");

            entity.HasOne(d => d.IdtratamientoNavigation).WithMany(p => p.MaterialTratamientos)
                .HasForeignKey(d => d.Idtratamiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TratamientoDetall");
        });

        modelBuilder.Entity<Medicamento>(entity =>
        {
            entity.HasKey(e => e.Idmedicamento).HasName("PK__Medicame__9228C2E4E7E05659");

            entity.ToTable("Medicamento");

            entity.Property(e => e.Idmedicamento).HasColumnName("IDMedicamento");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UnidadMedida)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Idpaciente).HasName("PK__Paciente__94DF170F00EDE54D");

            entity.ToTable("Paciente");

            entity.Property(e => e.Idpaciente).HasColumnName("IDPaciente");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Constrasena)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Documento)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Edad)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Recetum>(entity =>
        {
            entity.HasKey(e => new { e.Idcita, e.Idmedicamento });

            entity.Property(e => e.Idcita).HasColumnName("IDCita");
            entity.Property(e => e.Idmedicamento).HasColumnName("IDMedicamento");
            entity.Property(e => e.Dosis)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.IdcitaNavigation).WithMany(p => p.Receta)
                .HasForeignKey(d => d.Idcita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Receta_Cita");

            entity.HasOne(d => d.IdmedicamentoNavigation).WithMany(p => p.Receta)
                .HasForeignKey(d => d.Idmedicamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Receta_Medicamen");
        });

        modelBuilder.Entity<Sede>(entity =>
        {
            entity.HasKey(e => e.Idsede).HasName("PK__Sede__C5E3ECDE027A7F28");

            entity.ToTable("Sede");

            entity.Property(e => e.Idsede).HasColumnName("IDSede");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gerente)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tratamiento>(entity =>
        {
            entity.HasKey(e => e.Idtratamiento).HasName("PK__Tratamie__EA6000B46FA041BE");

            entity.ToTable("Tratamiento");

            entity.Property(e => e.Idtratamiento).HasColumnName("IDTratamiento");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(5, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
