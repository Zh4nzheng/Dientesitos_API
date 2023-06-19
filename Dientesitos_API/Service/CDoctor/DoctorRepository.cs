using Dientesitos_API.Model;


namespace Dientesitos_API.Service.CDoctor
{
    public class DoctorRepository : IDoctor
    {
        private DientesC conexion = new DientesC();
        public void add(Doctor doctor)
        {
            conexion.Doctors.Add(doctor);
            conexion.SaveChanges();
        }

        public void delete(int id)
        {
            var ObjEncontrado = (from tdoc in conexion.Doctors
                                 where tdoc.Iddoctor == id
                                 select tdoc).Single();
            conexion.Remove(ObjEncontrado);
            conexion.SaveChanges();
        }

        public IEnumerable<Doctor> GetAllDoctores()
        {
            return conexion.Doctors;
        }

        public Doctor GetDoctor(int id)
        {
            var ObjDoctor = (from tdoc in conexion.Doctors
                             where tdoc.Iddoctor == id
                             select tdoc).Single();
            return ObjDoctor;
        }

        public void update(Doctor doctor)
        {
            var objUpdate = GetDoctor(doctor.Iddoctor);
            objUpdate.Dni = doctor.Dni;
            objUpdate.Especialidad = doctor.Especialidad;
            objUpdate.Nombre = doctor.Nombre;
            objUpdate.ApellidoPaterno = doctor.ApellidoPaterno;
            objUpdate.ApellidoMaterno = doctor.ApellidoMaterno;
            objUpdate.NumeroColegioMedico = doctor.NumeroColegioMedico;
            objUpdate.Constrasena = doctor.Constrasena;
        }
    }
}
