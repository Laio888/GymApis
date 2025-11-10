namespace lib_dominio.Entidades
{
    public class Entrenadores
    {
        public int IdEntrenador { get; set; }
        public string? Nombre { get; set; }
        public string? Especialidad { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public bool Estado { get; set; }
    }
}