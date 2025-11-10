namespace lib_dominio.Entidades
{
    public class Mensajes
    {
        public int IdMensaje { get; set; }
        public int IdUsuario { get; set; }
        public int IdEntrenador { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string? Contenido { get; set; }
    }
}
