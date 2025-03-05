using CarWorkshop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarWorkshop.Infrastructure.Seeders
{
    public class CarWrokshopSeeder
    {
        private readonly CarWrokshopDbContext _context;
        public CarWrokshopSeeder(CarWrokshopDbContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if (await _context.Database.CanConnectAsync()) 
            {
                if (!_context.carWorkshops.Any()) 
                {
                    var mazdaASO = new Domain.Entities.CarWorkshop()
                    {
                        Name = "ASO Mazada",
                        Description = "Autoryzowany serwis Mazda",
                        ContactDetails = new()
                        {
                            City = "Kraków",
                            PhoneNumber = "543 123 974",
                            PostalCode = "32-763",
                            Street = "Opolska"
                        }
                    };
                    mazdaASO.EncodeName();                    

                    var SerwisMercedes = new Domain.Entities.CarWorkshop()
                    {
                        Name = " Serwis Mercedes-Benz",
                        Description = "Autoryzowany serwis Mercedes",
                        ContactDetails = new()
                        {
                            City = "Kraków",
                            PhoneNumber = "123 432 231",
                            PostalCode = "32-263",
                            Street = "Armii Krajowej"
                        }
                    };
                    SerwisMercedes.EncodeName();

                    _context.carWorkshops.Add(mazdaASO);
                    _context.carWorkshops.Add(SerwisMercedes);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
