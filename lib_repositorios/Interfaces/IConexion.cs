using Azure;
using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.Metrics;

namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Entrenadores>? Entrenadores { get; set; }
        public DbSet<Membresias>? Membresias { get; set; }
        public DbSet<Pagos>? Pagos { get; set; }
        public DbSet<Rutinas>? Rutinas { get; set; }
        public DbSet<Ejercicios>? Ejercicios { get; set; }
        public DbSet<RutinaEjercicio>? RutinaEjercicios { get; set; }
        public DbSet<Asistencia>? Asistencias { get; set; }
        public DbSet<Clases>? Clases { get; set; }
        public DbSet<HorariosClase>? HorariosClase { get; set; }
        public DbSet<InscripcionClase>? InscripcionesClase { get; set; }
        public DbSet<EvaluacionesFisicas>? EvaluacionesFisicas { get; set; }
        public DbSet<Mensajes>? Mensajes { get; set; }
        public DbSet<Productos>? Productos { get; set; }
        public DbSet<VentaProducto>? VentasProducto { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
