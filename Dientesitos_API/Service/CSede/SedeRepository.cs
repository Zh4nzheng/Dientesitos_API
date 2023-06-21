using Dientesitos_API.Model;

namespace Dientesitos_API.Service.CSede
{
    public class SedeRepository : ISede
    {
        private DientesC conexion = new DientesC();
        public void add(Sede sede)
        {
            conexion.Sedes.Add(sede);
            conexion.SaveChanges();
        }

        public void delete(int id)
        {
            var ObjEncontrado = (from tsed in conexion.Sedes
                                 where tsed.Idsede == id
                                 select tsed).Single();
            conexion.Remove(ObjEncontrado);
            conexion.SaveChanges();
        }

        public IEnumerable<Sede> GetAllSedes()
        {
           return conexion.Sedes;
        }

        public Sede GetSede(int id)
        {
            var ObjSede = (from tsed in conexion.Sedes
                             where tsed.Idsede == id
                             select tsed).FirstOrDefault();
            return ObjSede;
        }

        public void update(Sede sede)
        {
            var objUpdate = GetSede(sede.Idsede);
            objUpdate.Direccion = sede.Direccion;
            objUpdate.Telefono = sede.Telefono;
            objUpdate.Gerente = sede.Gerente;
        }
    }
}
