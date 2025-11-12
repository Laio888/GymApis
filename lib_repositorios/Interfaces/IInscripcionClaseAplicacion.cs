using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IInscripcionClaseAplicacion
    {
        void Configurar(string StringConexion);
        List<InscripcionClase> Filtro(InscripcionClase? entidad);
        List<InscripcionClase> Listar();
        InscripcionClase? Guardar(InscripcionClase? entidad);
        InscripcionClase? Modificar(InscripcionClase? entidad);
        InscripcionClase? Borrar(InscripcionClase? entidad);
    }
}