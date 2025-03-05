using CarWorkshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Domain.Interfaces
{
    public interface ICarWorkshopRepository
    {
        Task Create(CarWorkshop.Domain.Entities.CarWorkshop carWorkshop);
        Task<CarWorkshop.Domain.Entities.CarWorkshop?> GetByName(string name);
        Task<IEnumerable<CarWorkshop.Domain.Entities.CarWorkshop>> GetAll();
        Task<CarWorkshop.Domain.Entities.CarWorkshop> GetByEncodedName(string encodedName);
        Task Edit(CarWorkshop.Domain.Entities.CarWorkshop carWorkshop, string encodedName);
        Task Commit();
    }
}
