using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarWorkshop.Application.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using CarWorkshop.Application.ApplicationUser;
using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using FluentAssertions;

namespace CarWorkshop.Application.Mappings.Tests
{
    [TestClass()]
    public class CarWorkshopMappingProfileTests
    {
        [TestMethod()]
        public void MappingProfile_ShouldMapWorkshopDtoToCarWorkshop()
        {
            // arrange

            var userContextMock = new Mock<IUserContext>();
            userContextMock
                .Setup(c => c.GetCurrentUser())
                .Returns(new CurrentUser("1", "test@example.com", new[] { "Moderator" }));

            var configuration = new MapperConfiguration(cfg =>
            cfg.AddProfile(new CarWorkshopMappingProfile(userContextMock.Object)));

            var mapper = configuration.CreateMapper();

            var dto = new CarWorkshopDto
            {
                City = "City",
                PhoneNumber = "1234567890",
                PostalCode = "12345",
                Street = "Street"
            };

            // act

            var result = mapper.Map<Domain.Entities.CarWorkshop>(dto);

            // assert

            result.Should().NotBeNull();
            result.ContactDetails.Should().NotBeNull();
            result.ContactDetails.City.Should().Be(dto.City);
            result.ContactDetails.PhoneNumber.Should().Be(dto.PhoneNumber);
            result.ContactDetails.Street.Should().Be(dto.Street);
            result.ContactDetails.PostalCode.Should().Be(dto.PostalCode);
            
        }

        [TestMethod()]
        public void MappingProfile_ShouldMapWorkshopToCarWorkshopDto()
        {
            // arrange

            var userContextMock = new Mock<IUserContext>();
            userContextMock
                .Setup(c => c.GetCurrentUser())
                .Returns(new CurrentUser("1", "test@example.com", new[] { "Moderator" }));

            var configuration = new MapperConfiguration(cfg =>
            cfg.AddProfile(new CarWorkshopMappingProfile(userContextMock.Object)));

            var mapper = configuration.CreateMapper();

            var carWorkshop = new Domain.Entities.CarWorkshop
            {
                Id = 1,
                CreatedById = "1",
                ContactDetails = new Domain.Entities.CarWorkshopContactDetails
                {
                    City = "City",
                    PhoneNumber = "1234567890",
                    PostalCode = "12345",
                    Street = "Street"
                }               
            };

            // act

            var result = mapper.Map<CarWorkshopDto>(carWorkshop);

            // assert

            result.Should().NotBeNull();
            result.Should().NotBeNull();
            result.IsEditable.Should().BeTrue();
            result.City.Should().Be(carWorkshop.ContactDetails.City);
            result.PhoneNumber.Should().Be(carWorkshop.ContactDetails.PhoneNumber);
            result.Street.Should().Be(carWorkshop.ContactDetails.Street);
            result.PostalCode.Should().Be(carWorkshop.ContactDetails.PostalCode);

        }
    }
}