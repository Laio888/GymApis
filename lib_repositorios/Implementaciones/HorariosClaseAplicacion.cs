using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class HorariosClaseAplicacion : IHorariosClaseAplicacion
    {
        private IConexion? IConexion = null;

        public HorariosClaseAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public HorariosClase? Borrar(HorariosClase? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdHorarioClase == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.HorariosClase!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public HorariosClase? Guardar(HorariosClase? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdHorarioClase != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.HorariosClase!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<HorariosClase> Listar()
        {
            return this.IConexion!.HorariosClase!.Take(50).ToList();
        }

        public List<HorariosClase> Filtro(HorariosClase? entidad)
        {
            return this.IConexion!.HorariosClase!
                .Where(x => entidad!.DiaSemana != null &&
                       x.DiaSemana == entidad.DiaSemana &&
                       x.HoraInicio == entidad.HoraInicio)
                .Take(50)
                .ToList();
        }

        public HorariosClase? Modificar(HorariosClase? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdHorarioClase == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<HorariosClase>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}