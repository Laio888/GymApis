namespace lib_dominio.Entidades
{
    public class Membresias
    {
        public int IdMembresia { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int DuracionDias { get; set; }
        public bool Estado { get; set; }
    }
}
