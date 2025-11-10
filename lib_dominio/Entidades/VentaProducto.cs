namespace lib_dominio.Entidades
{
    public class VentaProducto
    {
        public int IdVenta { get; set; }
        public int IdUsuario { get; set; }
        public int IdProducto { get; set; }
        public DateTime FechaVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
