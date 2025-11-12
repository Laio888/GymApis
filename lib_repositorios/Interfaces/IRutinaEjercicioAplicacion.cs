using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IRutinaEjercicioAplicacion
    {
        void Configurar(string StringConexion);
        List<RutinaEjercicio> Filtro(RutinaEjercicio? entidad);
        List<RutinaEjercicio> Listar();
        RutinaEjercicio? Guardar(RutinaEjercicio? entidad);
        RutinaEjercicio? Modificar(RutinaEjercicio? entidad);
        RutinaEjercicio? Borrar(RutinaEjercicio? entidad);
    }
}