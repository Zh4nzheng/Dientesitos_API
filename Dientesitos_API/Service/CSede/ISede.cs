using Dientesitos_API.Model;

namespace Dientesitos_API.Service.CSede
{
    public interface ISede
    {
        IEnumerable<Sede> GetAllSedes();
        Sede GetSede(int id);
        void add(Sede sede);
        void update(Sede sede);
        void delete(int id);
    }
}
