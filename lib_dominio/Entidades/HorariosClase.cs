namespace lib_dominio.Entidades
{
    public class HorariosClase
    {
        public int IdHorarioClase { get; set; }
        public int IdClase { get; set; }
        public string? DiaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
    }
}
