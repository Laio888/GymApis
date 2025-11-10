namespace lib_dominio.Entidades
{
    public class Pagos
    {
        public int IdPago { get; set; }
        public int IdUsuario { get; set; }
        public int IdMembresia { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string? MetodoPago { get; set; }
    }
}
