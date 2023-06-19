using Dientesitos_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Dientesitos_API.Service.CCita
{
    public class CitaRepository : ICita
    {
        private DientesC conexion = new DientesC();
        public void add(CitaDental citaDental)
        {
            conexion.CitaDentals.Add(citaDental);
            conexion.SaveChanges();
        }

        public void delete(int id)
        {
            var ObjEncontrado = (from tcit in conexion.CitaDentals
                                 where tcit.Idcita == id
                                 select tcit).Single();
            conexion.Remove(ObjEncontrado);
            conexion.SaveChanges();
        }

        public IEnumerable<CitaDental> GetAllCitas()
        {
            return conexion.CitaDentals;
        }

        public CitaDental GetCita(int id)
        {
            var ObjCita = (from tcit in conexion.CitaDentals
                            where tcit.Idcita == id
                            select tcit).Single();
            return ObjCita;
        }

        public void update(CitaDental citaDental)
        {
            var objUpdate = GetCita(citaDental.Idcita);
            objUpdate.Idtratamiento = citaDental.Idtratamiento;
            objUpdate.Iddoctor = citaDental.Iddoctor;
            objUpdate.Idpaciente = citaDental.Idpaciente;
            objUpdate.Idsede = citaDental.Idsede;
            objUpdate.Fecha = citaDental.Fecha;
            objUpdate.Hora = citaDental.Hora;
            objUpdate.Duracion = citaDental.Duracion;
            objUpdate.ImportePagar = citaDental.ImportePagar;
            objUpdate.Estado = citaDental.Estado;
        }
    }
}
