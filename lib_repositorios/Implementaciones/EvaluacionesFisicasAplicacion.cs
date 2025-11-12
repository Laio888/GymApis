using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class EvaluacionesFisicasAplicacion : IEvaluacionesFisicasAplicacion
    {
        private IConexion? IConexion = null;

        public EvaluacionesFisicasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public EvaluacionesFisicas? Borrar(EvaluacionesFisicas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdEvaluacion == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.EvaluacionesFisicas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public EvaluacionesFisicas? Guardar(EvaluacionesFisicas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdEvaluacion != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.EvaluacionesFisicas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<EvaluacionesFisicas> Listar()
        {
            return this.IConexion!.EvaluacionesFisicas!.Take(50).ToList();
        }

        public List<EvaluacionesFisicas> Filtro(EvaluacionesFisicas? entidad)
        {
            return this.IConexion!.EvaluacionesFisicas!
                .Where(x => x.Peso == entidad!.Peso &&
                            x.IMC == entidad!.IMC)
                .Take(50)
                .ToList();
        }

        public EvaluacionesFisicas? Modificar(EvaluacionesFisicas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdEvaluacion == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<EvaluacionesFisicas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}