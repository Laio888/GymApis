using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ClasesAplicacion : IClasesAplicacion
    {
        private IConexion? IConexion = null;

        public ClasesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Clases? Borrar(Clases? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdClase == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Clases!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Clases? Guardar(Clases? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdClase != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Clases!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Clases> Listar()
        {
            return this.IConexion!.Clases!.Take(50).ToList();
        }

        public List<Clases> Filtro(Clases? entidad)
        {
            return this.IConexion!.Clases!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!) &&
                            x.Descripcion!.Contains(entidad!.Descripcion!))
                .Take(50)
                .ToList();
        }

        public Clases? Modificar(Clases? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdClase == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Clases>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}