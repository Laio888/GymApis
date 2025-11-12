using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

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
        public DbSet<Auditorias>? Auditorias { get; set; }

    }
}
