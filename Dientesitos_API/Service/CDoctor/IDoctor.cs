using Dientesitos_API.Model;

namespace Dientesitos_API.Service.CDoctor
{
    public interface IDoctor
    {
        IEnumerable<Doctor> GetAllDoctores();
        Doctor GetDoctor(int id);
        void add(Doctor doctor);
        void update(Doctor doctor);
        void delete(int id);
    }
}
