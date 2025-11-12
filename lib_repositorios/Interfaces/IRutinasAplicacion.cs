using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IRutinasAplicacion
    {
        void Configurar(string StringConexion);
        List<Rutinas> Filtro(Rutinas? entidad);
        List<Rutinas> Listar();
        Rutinas? Guardar(Rutinas? entidad);
        Rutinas? Modificar(Rutinas? entidad);
        Rutinas? Borrar(Rutinas? entidad);
    }
}