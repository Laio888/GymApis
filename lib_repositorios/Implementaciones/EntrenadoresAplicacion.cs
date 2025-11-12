using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class EntrenadoresAplicacion : IEntrenadoresAplicacion
    {
        private IConexion? IConexion = null;

        public EntrenadoresAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Entrenadores? Borrar(Entrenadores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdEntrenador == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Entrenadores!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Entrenadores? Guardar(Entrenadores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdEntrenador != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Entrenadores!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Entrenadores> Listar()
        {
            return this.IConexion!.Entrenadores!.Take(50).ToList();
        }

        public List<Entrenadores> Filtro(Entrenadores? entidad)
        {
            return this.IConexion!.Entrenadores!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!) &&
                            x.Especialidad!.Contains(entidad!.Especialidad!))
                .Take(50)
                .ToList();
        }

        public Entrenadores? Modificar(Entrenadores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdEntrenador == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Entrenadores>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}