using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IEntrenadoresAplicacion
    {
        void Configurar(string StringConexion);
        List<Entrenadores> Filtro(Entrenadores? entidad);
        List<Entrenadores> Listar();
        Entrenadores? Guardar(Entrenadores? entidad);
        Entrenadores? Modificar(Entrenadores? entidad);
        Entrenadores? Borrar(Entrenadores? entidad);
    }
}