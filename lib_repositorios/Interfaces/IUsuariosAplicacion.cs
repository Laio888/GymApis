using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IUsuariosAplicacion
    {
        void Configurar(string StringConexion);
        List<Usuario> Filtro(Usuario? entidad);
        List<Usuario> Listar();
        Usuario? Guardar(Usuario? entidad);
        Usuario? Modificar(Usuario? entidad);
        Usuario? Borrar(Usuario? entidad);
    }
}