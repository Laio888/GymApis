namespace lib_dominio.Entidades
{
    public class EvaluacionesFisicas
    {
        public int IdEvaluacion { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaEvaluacion { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }
        public decimal IMC { get; set; }
        public string? Observaciones { get; set; }
    }

}
