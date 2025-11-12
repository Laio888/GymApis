using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class AsistenciaAplicacion : IAsistenciaAplicacion
    {
        private IConexion? IConexion = null;

        public AsistenciaAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Asistencia? Borrar(Asistencia? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdAsistencia == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Asistencias!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Asistencia? Guardar(Asistencia? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdAsistencia != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Asistencias!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Asistencia> Listar()
        {
            return this.IConexion!.Asistencias!.Take(50).ToList();
        }

        public List<Asistencia> Filtro(Asistencia? entidad)
        {
            return this.IConexion!.Asistencias!
                .Where(x => x.Fecha == entidad!.Fecha &&
                            x.HoraEntrada == entidad!.HoraEntrada)
                .Take(50)
                .ToList();
        }

        public Asistencia? Modificar(Asistencia? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdAsistencia == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Asistencia>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}