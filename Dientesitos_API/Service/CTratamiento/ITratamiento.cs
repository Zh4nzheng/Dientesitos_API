using Dientesitos_API.Model;

namespace Dientesitos_API.Service.CTratamiento
{
    public interface ITratamiento
    {
        IEnumerable<Tratamiento> GetAllTratamientos();
        Tratamiento GetTratamiento(int id);
        void add(Tratamiento tratamiento);
        void update(Tratamiento tratamiento);
        void delete(int id);
    }
}
