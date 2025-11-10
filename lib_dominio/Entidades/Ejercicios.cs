namespace lib_dominio.Entidades
{
    public class Ejercicios
    {
        public int IdEjercicio { get; set; }
        public string? Nombre { get; set; }
        public string? GrupoMuscular { get; set; }
        public string? Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
