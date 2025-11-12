using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class MensajesAplicacion : IMensajesAplicacion
    {
        private IConexion? IConexion = null;

        public MensajesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Mensajes? Borrar(Mensajes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdMensaje == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Mensajes!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Mensajes? Guardar(Mensajes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdMensaje != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Mensajes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Mensajes> Listar()
        {
            return this.IConexion!.Mensajes!.Take(50).ToList();
        }

        public List<Mensajes> Filtro(Mensajes? entidad)
        {
            return this.IConexion!.Mensajes!
                .Where(x => x.FechaEnvio == entidad!.FechaEnvio &&
                            x.Contenido!.Contains(entidad!.Contenido!))
                .Take(50)
                .ToList();
        }

        public Mensajes? Modificar(Mensajes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdMensaje == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Mensajes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}