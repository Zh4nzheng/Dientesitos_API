using Dientesitos_API.Model;

namespace Dientesitos_API.Service.CCita
{
    public interface ICita
    {
        IEnumerable<CitaDental> GetAllCitas();
        CitaDental GetCita(int id);
        void add(CitaDental citaDental);
        void update(CitaDental citaDental);
        void delete(int id);
    }
}
