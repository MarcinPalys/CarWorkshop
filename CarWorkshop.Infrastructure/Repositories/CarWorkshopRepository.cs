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
    internal class CarWorkshopRepository : ICarWorkshopRepository
    {
        CarWrokshopDbContext _context;
        public CarWorkshopRepository(CarWrokshopDbContext context)
        {
            _context = context;
        }

        public Task Commit()
        => _context.SaveChangesAsync();

        public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
        {
            carWorkshop.EncodeName();
            _context.Add(carWorkshop);
            await _context.SaveChangesAsync();
        }

        public Task Edit(Domain.Entities.CarWorkshop carWorkshop, string encodedName)
        {
            var findCarWorkshop = GetByEncodedName(encodedName);

            return findCarWorkshop;
        }

        public async Task<IEnumerable<Domain.Entities.CarWorkshop>> GetAll()
        => await _context.carWorkshops.ToListAsync();

        public async Task<Domain.Entities.CarWorkshop> GetByEncodedName(string encodedName)
        => await _context.carWorkshops.FirstAsync(x => x.EncodedName == encodedName);

        public Task<Domain.Entities.CarWorkshop?> GetByName(string name)
        => _context.carWorkshops.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
    }
}
