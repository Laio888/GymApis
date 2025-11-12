using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IVentaProductosAplicacion
    {
        void Configurar(string StringConexion);
        List<VentaProducto> Filtro(VentaProducto? entidad);
        List<VentaProducto> Listar();
        VentaProducto? Guardar(VentaProducto? entidad);
        VentaProducto? Modificar(VentaProducto? entidad);
        VentaProducto? Borrar(VentaProducto? entidad);
    }
}