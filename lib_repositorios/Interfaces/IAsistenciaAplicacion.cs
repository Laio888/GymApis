using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IAsistenciaAplicacion
    {
        void Configurar(string StringConexion);
        List<Asistencia> Filtro(Asistencia? entidad);
        List<Asistencia> Listar();
        Asistencia? Guardar(Asistencia? entidad);
        Asistencia? Modificar(Asistencia? entidad);
        Asistencia? Borrar(Asistencia? entidad);
    }
}