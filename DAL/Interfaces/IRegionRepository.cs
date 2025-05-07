using DAL.Models;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRegionRepository
    {
        IEnumerable<Region> GetAll();
        Region GetById(int id);
    }
}
