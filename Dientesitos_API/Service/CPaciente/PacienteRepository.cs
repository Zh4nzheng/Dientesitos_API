using Dientesitos_API.Model;

namespace Dientesitos_API.Service.CPaciente
{
    public class PacienteRepository : IPaciente
    {
        private DientesC conexion = new DientesC();
        public void add(Paciente paciente)
        {
            conexion.Pacientes.Add(paciente);
            conexion.SaveChanges();
        }

        public void delete(int id)
        {
            var ObjEncontrado =(from tpac in conexion.Pacientes
                                where tpac.Idpaciente==id
                                select tpac).Single();
            conexion.Remove(ObjEncontrado);
            conexion.SaveChanges();
        }

        public IEnumerable<Paciente> GetAllPacientes()
        {
            return conexion.Pacientes;
        }

        public Paciente GetPaciente(int id)
        {
            var ObjPaciente=(from tpac in conexion.Pacientes
                             where tpac.Idpaciente ==id
                             select tpac).Single();
            return ObjPaciente;
        }

        public void update(Paciente paciente)
        {
            var objUpdate = GetPaciente(paciente.Idpaciente);
            objUpdate.Documento = paciente.Documento;
            objUpdate.Nombre = paciente.Nombre;
            objUpdate.ApellidoPaterno = paciente.ApellidoPaterno;
            objUpdate.ApellidoMaterno = paciente.ApellidoMaterno;
            objUpdate.Direccion = paciente.Direccion;
            objUpdate.Constrasena = paciente.Constrasena;
            objUpdate.Telefono = paciente.Telefono;
            objUpdate.Edad= paciente.Edad;
            objUpdate.Estado = paciente.Estado;
        }
    }
}
