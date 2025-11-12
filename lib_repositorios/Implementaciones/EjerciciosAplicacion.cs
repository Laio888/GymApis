using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class EjerciciosAplicacion : IEjerciciosAplicacion
    {
        private IConexion? IConexion = null;

        public EjerciciosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Ejercicios? Borrar(Ejercicios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdEjercicio == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Ejercicios!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Ejercicios? Guardar(Ejercicios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdEjercicio != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Ejercicios!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Ejercicios> Listar()
        {
            return this.IConexion!.Ejercicios!.Take(50).ToList();
        }

        public List<Ejercicios> Filtro(Ejercicios? entidad)
        {
            return this.IConexion!.Ejercicios!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!) &&
                            x.GrupoMuscular!.Contains(entidad!.GrupoMuscular!))
                .Take(50)
                .ToList();
        }

        public Ejercicios? Modificar(Ejercicios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdEjercicio == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Ejercicios>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}