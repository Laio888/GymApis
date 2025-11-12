using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IHorariosClaseAplicacion
    {
        void Configurar(string StringConexion);
        List<HorariosClase> Filtro(HorariosClase? entidad);
        List<HorariosClase> Listar();
        HorariosClase? Guardar(HorariosClase? entidad);
        HorariosClase? Modificar(HorariosClase? entidad);
        HorariosClase? Borrar(HorariosClase? entidad);
    }
}