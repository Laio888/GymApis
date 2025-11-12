namespace lib_dominio.Entidades
{
    public class Auditorias
    {
        public int IdAuditoria { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
        public string Accion { get; set; }
        public string Tabla { get; set; }
        public int IdRegistro { get; set; }
    }
}