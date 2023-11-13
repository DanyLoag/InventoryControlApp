using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AlmacenSQLiteEntities;

namespace AlmacenDataContext;

public partial class Almacen : DbContext, IAlmacenDataContext
{
    public Almacen()
    {
    }

    public DbSet<Almacenista> Almacenistas { get; set; }

    public DbSet<Categoria> Categorias { get; set; }

    public DbSet<Coordinador> Coordinadores { get; set; }

    public DbSet<DescPedido> DescPedidos { get; set; }

    public DbSet<Docente> Docentes { get; set; }

    public DbSet<Estudiante> Estudiantes { get; set; }

    public DbSet<Grupo> Grupos { get; set; }

    public DbSet<Laboratorio> Laboratorios { get; set; }

    public DbSet<Mantenimiento> Mantenimientos { get; set; }

    public DbSet<Marca> Marcas { get; set; }

    public DbSet<Material> Materiales { get; set; }

    public DbSet<Modelo> Modelos { get; set; }

    public DbSet<Pedido> Pedidos { get; set; }

    public DbSet<Plantel> Planteles { get; set; }

    public DbSet<ReporteMantenimiento> ReporteMantenimientos { get; set; }

    public DbSet<Semestre> Semestres { get; set; }

    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = Path.Combine(Environment.CurrentDirectory, "..","Libraries", "AlmacenSQLiteEntities", "Almacen.db");
        string connection = $"Filename={path}";
        ConsoleColor backgroundColor = ForegroundColor;
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine($"Connection: {connection}");
        ForegroundColor = backgroundColor;
        optionsBuilder.UseSqlite(connection);
        //optionsBuilder.LogTo(WriteLine).EnableSensitiveDataLogging();

        // Using Lazy Loading
        optionsBuilder.UseLazyLoadingProxies();

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Almacenista>(entity =>
        {
            entity.Property(e => e.AlmacenistaId).ValueGeneratedNever();

            entity.HasOne(d => d.Plantel).WithMany(p => p.Almacenistas).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Almacenistas).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.Property(e => e.CategoriaId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Coordinador>(entity =>
        {
            entity.Property(e => e.CoordinadorId).ValueGeneratedNever();

            entity.HasOne(d => d.Plantel).WithMany(p => p.Coordinadores).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Coordinadores).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DescPedido>(entity =>
        {
            entity.Property(e => e.DescPedidoId).ValueGeneratedNever();

            entity.HasOne(d => d.Material).WithMany(p => p.DescPedidos).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Pedido).WithMany(p => p.DescPedidos).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Docente>(entity =>
        {
            entity.Property(e => e.DocenteId).ValueGeneratedNever();

            entity.HasOne(d => d.Plantel).WithMany(p => p.Docentes).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Docentes).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.Property(e => e.EstudianteId).ValueGeneratedNever();

            entity.HasOne(d => d.Grupo).WithMany(p => p.Estudiantes).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Plantel).WithMany(p => p.Estudiantes).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Semestre).WithMany(p => p.Estudiantes).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Estudiantes).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.Property(e => e.GrupoId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Laboratorio>(entity =>
        {
            entity.Property(e => e.LaboratorioId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Mantenimiento>(entity =>
        {
            entity.Property(e => e.MantenimientoId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.Property(e => e.MarcaId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.Property(e => e.MaterialId).ValueGeneratedNever();

            entity.HasOne(d => d.Categoria).WithMany(p => p.Materiales).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Marca).WithMany(p => p.Materiales).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Modelo).WithMany(p => p.Materiales).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Plantel).WithMany(p => p.Materiales).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.Property(e => e.ModeloId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.Property(e => e.PedidoId).ValueGeneratedNever();

            entity.HasOne(d => d.Docente).WithMany(p => p.Pedidos).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Estudiante).WithMany(p => p.Pedidos).OnDelete(DeleteBehavior.ClientSetNull);
            entity.HasOne(d => d.Coordinador).WithMany(p => p.Pedidos).OnDelete(DeleteBehavior.ClientSetNull);
            entity.HasOne(d => d.Laboratorio).WithMany(p => p.Pedidos).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Plantel>(entity =>
        {
            entity.Property(e => e.PlantelId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ReporteMantenimiento>(entity =>
        {
            entity.Property(e => e.ReporteMantenimientoId).ValueGeneratedNever();

            entity.HasOne(d => d.Mantenimiento).WithMany(p => p.ReporteMantenimientos).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Material).WithMany(p => p.ReporteMantenimientos).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Semestre>(entity =>
        {
            entity.Property(e => e.SemestreId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.UsuarioId).ValueGeneratedNever();
        });
    }

}

public interface IAlmacenDataContext:IDisposable

{
   DbSet<Usuario> Usuarios { get; }
    DbSet<Docente> Docentes { get; }
    DbSet<Estudiante> Estudiantes { get; }
    DbSet<Almacenista> Almacenistas { get; }
    DbSet<Coordinador> Coordinadores { get; }
    DbSet<Categoria> Categorias { get; }
    DbSet<DescPedido> DescPedidos { get; }
    DbSet<Grupo> Grupos { get; }
    DbSet<Laboratorio> Laboratorios { get; }
    DbSet<Mantenimiento> Mantenimientos { get; }
    DbSet<Marca> Marcas { get; }
    DbSet<Material> Materiales { get; }
    DbSet<Modelo> Modelos { get; }
    DbSet<Pedido> Pedidos { get; }
    DbSet<Plantel> Planteles { get; }
    DbSet<ReporteMantenimiento> ReporteMantenimientos { get; }
    DbSet<Semestre> Semestres { get; }
    int SaveChanges();
}

