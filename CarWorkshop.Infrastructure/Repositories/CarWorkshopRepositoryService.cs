using CarWorkshop.Domain.Entities;
using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Repositories
{
    public class CarWorkshopRepositoryService : ICarWorkshopServiceRepository
    {
        private readonly CarWrokshopDbContext dbContext;
        public CarWorkshopRepositoryService(CarWrokshopDbContext carWrokshopDbContext)
        {
            dbContext = carWrokshopDbContext;
        }

        public async Task Create(CarWorkshopService carWorkshopService)
        {
            dbContext.services.Add(carWorkshopService);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CarWorkshopService>> GetAllByEncodedName(string encodedName)
        => await dbContext.services.Where(s => s.CarWorkshop.EncodedName == encodedName).ToListAsync();
    }
}
