using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IClasesAplicacion
    {
        void Configurar(string StringConexion);
        List<Clases> Filtro(Clases? entidad);
        List<Clases> Listar();
        Clases? Guardar(Clases? entidad);
        Clases? Modificar(Clases? entidad);
        Clases? Borrar(Clases? entidad);
    }
}