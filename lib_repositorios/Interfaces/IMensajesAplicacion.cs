using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IMensajesAplicacion
    {
        void Configurar(string StringConexion);
        List<Mensajes> Filtro(Mensajes? entidad);
        List<Mensajes> Listar();
        Mensajes? Guardar(Mensajes? entidad);
        Mensajes? Modificar(Mensajes? entidad);
        Mensajes? Borrar(Mensajes? entidad);
    }
}