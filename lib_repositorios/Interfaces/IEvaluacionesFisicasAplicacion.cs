using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IEvaluacionesFisicasAplicacion
    {
        void Configurar(string StringConexion);
        List<EvaluacionesFisicas> Filtro(EvaluacionesFisicas? entidad);
        List<EvaluacionesFisicas> Listar();
        EvaluacionesFisicas? Guardar(EvaluacionesFisicas? entidad);
        EvaluacionesFisicas? Modificar(EvaluacionesFisicas? entidad);
        EvaluacionesFisicas? Borrar(EvaluacionesFisicas? entidad);
    }
}