using Dientesitos_API.Model;

namespace Dientesitos_API.Service.CTratamiento
{
    public class TratamientoRepository : ITratamiento
    {
        private DientesC conexion = new DientesC();
        public void add(Tratamiento tratamiento)
        {
            conexion.Tratamientos.Add(tratamiento);
            conexion.SaveChanges();
        }

        public void delete(int id)
        {
            var ObjEncontrado = (from ttra in conexion.Tratamientos
                                 where ttra.Idtratamiento == id
                                 select ttra).Single();
            conexion.Remove(ObjEncontrado);
            conexion.SaveChanges();
        }

        public IEnumerable<Tratamiento> GetAllTratamientos()
        {
            return conexion.Tratamientos;
        }

        public Tratamiento GetTratamiento(int id)
        {
            var ObjTratamiento = (from ttra in conexion.Tratamientos
                           where ttra.Idtratamiento == id
                           select ttra).FirstOrDefault();
            return ObjTratamiento;
        }

        public void update(Tratamiento tratamiento)
        {
            var objUpdate = GetTratamiento(tratamiento.Idtratamiento);
            objUpdate.Nombre = tratamiento.Nombre;
            objUpdate.Descripcion = tratamiento.Descripcion;
            objUpdate.Duracion = tratamiento.Duracion;
            objUpdate.Precio=tratamiento.Precio;
        }
    }
}
