﻿using Xunit;
using CarWorkshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace CarWorkshop.Domain.Entities.Tests
{
    public class CarWorkshopTests
    {
        [Fact()]
        public void EncodeNameTest()
        {
            //arrage
            var carWorkshop = new CarWorkshop();
            carWorkshop.Name = "Test Workshop";

            //act

            carWorkshop.EncodeName();

            //assert

            carWorkshop.EncodedName.Should().Be("test-workshop");
        }

        [Fact()]
        public void EncodeName_ShouldThrowException_WhenNameIsNull()
        {
            //arrage
            var carWorkshop = new CarWorkshop();

            //act

            Action action = () => carWorkshop.EncodeName();

            //assert

            action.Invoking(a => a.Invoke())
                .Should().Throw<NullReferenceException>();
        }
    }
}