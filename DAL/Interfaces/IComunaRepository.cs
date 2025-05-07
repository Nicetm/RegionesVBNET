using DAL.Models;

namespace DAL.Interfaces
{
    public interface IComunaRepository
    {
        IEnumerable<Comuna> GetByRegion(int idRegion);
        Comuna GetById(int idRegion, int idComuna);
        void Merge(Comuna comuna, int idRegion);
    }
}