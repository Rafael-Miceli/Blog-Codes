using System;
using Xunit;
using api.Controllers;
using Domain;
using Moq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace tests
{
    public class FeederControllerTests
    {
        [Fact]
        public void Given_A_Feeder_With_Empty_Name_When_Creating_The_Feeder_Then_Returns_BadRequest()
        {
            //Arrange            
            var feederTest = new Feeder("");
            var sut = new FeederController(null);
            //Act
            var result = sut.Post(feederTest);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(400, (result as BadRequestObjectResult).StatusCode);
        }

        [Fact]
        public void Given_A_Feeder_With_Existent_Name_In_DB_When_Creating_The_Feeder_Then_Returns_BadRequest()
        {
            //Arrange       
            var feederTest = new Feeder("Feeder Teste");     
            var mockedRepository = new Mock<IFeederRepository>();
            mockedRepository.Setup(x => x.GetAll()).Returns(new List<Feeder>{ new Feeder("Feeder Teste")});
            var sut = new FeederController(new FeederService(mockedRepository.Object));
            //Act
            var result = sut.Post(feederTest);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(400, (result as BadRequestObjectResult).StatusCode);
        }

        [Fact]
        public void Given_A_Feeder_Valid_When_Creating_The_Feeder_Then_Returns_Created()
        {
            //Arrange       
            var feederTest = new Feeder("Feeder Teste 2");     
            var mockedRepository = new Mock<IFeederRepository>();
            mockedRepository.Setup(x => x.GetAll()).Returns(new List<Feeder>{ new Feeder("Feeder Teste")});
            var sut = new FeederController(new FeederService(mockedRepository.Object));
            //Act
            var result = sut.Post(feederTest);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(201, (result as CreatedResult).StatusCode);
        }
    }
}
