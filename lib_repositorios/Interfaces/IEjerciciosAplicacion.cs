using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IEjerciciosAplicacion
    {
        void Configurar(string StringConexion);
        List<Ejercicios> Filtro(Ejercicios? entidad);
        List<Ejercicios> Listar();
        Ejercicios? Guardar(Ejercicios? entidad);
        Ejercicios? Modificar(Ejercicios? entidad);
        Ejercicios? Borrar(Ejercicios? entidad);
    }
}