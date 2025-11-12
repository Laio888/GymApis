using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class InscripcionClaseAplicacion : IInscripcionClaseAplicacion
    {
        private IConexion? IConexion = null;

        public InscripcionClaseAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public InscripcionClase? Borrar(InscripcionClase? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdInscripcion == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.InscripcionesClase!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public InscripcionClase? Guardar(InscripcionClase? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdInscripcion != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.InscripcionesClase!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<InscripcionClase> Listar()
        {
            return this.IConexion!.InscripcionesClase!.Take(50).ToList();
        }

        public List<InscripcionClase> Filtro(InscripcionClase? entidad)
        {
            return this.IConexion!.InscripcionesClase!
                .Where(x => x.FechaInscripcion == entidad!.FechaInscripcion &&
                       x.IdInscripcion == entidad.IdInscripcion)
                .Take(50)
                .ToList();
        }

        public InscripcionClase? Modificar(InscripcionClase? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdInscripcion == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<InscripcionClase>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}