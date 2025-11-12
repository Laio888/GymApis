using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class UsuariosAplicacion : IUsuariosAplicacion
    {
        private IConexion? IConexion = null;

        public UsuariosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Usuario? Borrar(Usuario? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdUsuario == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Usuarios!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Usuario? Guardar(Usuario? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdUsuario != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Usuarios!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Usuario> Listar()
        {
            return this.IConexion!.Usuarios!.Take(50).ToList();
        }

        public List<Usuario> Filtro(Usuario? entidad)
        {
            return this.IConexion!.Usuarios!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!) &&
                            x.Correo!.Contains(entidad!.Correo!))
                .Take(50)
                .ToList();
        }

        public Usuario? Modificar(Usuario? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdUsuario == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Usuario>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}