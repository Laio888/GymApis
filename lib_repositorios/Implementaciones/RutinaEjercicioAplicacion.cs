using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class RutinaEjercicioAplicacion : IRutinaEjercicioAplicacion
    {
        private IConexion? IConexion = null;

        public RutinaEjercicioAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public RutinaEjercicio? Borrar(RutinaEjercicio? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdRutinaEjercicio == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.RutinaEjercicios!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public RutinaEjercicio? Guardar(RutinaEjercicio? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdRutinaEjercicio != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.RutinaEjercicios!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<RutinaEjercicio> Listar()
        {
            return this.IConexion!.RutinaEjercicios!.Take(50).ToList();
        }

        public List<RutinaEjercicio> Filtro(RutinaEjercicio? entidad)
        {
            return this.IConexion!.RutinaEjercicios!
                .Where(x => x.Series == entidad!.Series &&
                       x.Repeticiones == entidad.Repeticiones)
                .Take(50)
                .ToList();
        }

        public RutinaEjercicio? Modificar(RutinaEjercicio? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdRutinaEjercicio == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<RutinaEjercicio>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}