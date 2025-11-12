using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class VentaProductoAplicacion : IVentaProductosAplicacion
    {
        private IConexion? IConexion = null;

        public VentaProductoAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public VentaProducto? Borrar(VentaProducto? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdVenta == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.VentasProducto!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public VentaProducto? Guardar(VentaProducto? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdVenta != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.VentasProducto!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<VentaProducto> Listar()
        {
            return this.IConexion!.VentasProducto!.Take(50).ToList();
        }

        public List<VentaProducto> Filtro(VentaProducto? entidad)
        {
            return this.IConexion!.VentasProducto!
                .Where(x => x.FechaVenta == entidad!.FechaVenta &&
                       x.Cantidad == entidad.Cantidad)

                .Take(50)   
                .ToList();
        }

        public VentaProducto? Modificar(VentaProducto? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdVenta == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<VentaProducto>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}