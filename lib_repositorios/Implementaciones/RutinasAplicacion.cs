using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class RutinasAplicacion : IRutinasAplicacion
    {
        private IConexion? IConexion = null;

        public RutinasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Rutinas? Borrar(Rutinas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdRutina == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Rutinas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Rutinas? Guardar(Rutinas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdRutina != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Rutinas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Rutinas> Listar()
        {
            return this.IConexion!.Rutinas!.Take(50).ToList();
        }
        
        public List<Rutinas> Filtro(Rutinas? entidad)
        {
            return this.IConexion!.Rutinas!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!) &&
                            x.Objetivo!.Contains(entidad!.Objetivo!))
                .Take(50)
                .ToList();
        }

        public Rutinas? Modificar(Rutinas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdRutina == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Rutinas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}