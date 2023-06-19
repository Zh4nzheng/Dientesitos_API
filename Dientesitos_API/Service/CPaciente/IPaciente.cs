using Dientesitos_API.Model;

namespace Dientesitos_API.Service.CPaciente
{
    public interface IPaciente
    {
        IEnumerable<Paciente> GetAllPacientes();
        Paciente GetPaciente(int id);
        void add(Paciente paciente);
        void update(Paciente paciente);
        void delete(int id);
    }
}
