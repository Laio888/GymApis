namespace lib_dominio.Entidades
{
    public class InscripcionClase
    {
        public int IdInscripcion { get; set; }
        public int IdUsuario { get; set; }
        public int IdHorarioClase { get; set; }
        public DateTime FechaInscripcion { get; set; }
    }
}
