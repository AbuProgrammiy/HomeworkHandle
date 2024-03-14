using AutoSalon.Domain.Entities.DTOs;
using AutoSalon.Domain.Entities.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestForRepository.Services
{
    public partial class CarServiceTest
    {
//Create uchun
        [Fact]
        public async Task ShoulCreateCar()
        {
            // Arrange
                // Manda Service carDTO va Repository esa Car ni property sifatida qabul qiladi
                    // (shuning uchun ikkita model tayyorlab oldim)
            CarDTO carDTO = new CarDTO()
            {
                BrandName = "Chevralet",
                CarName = "Monza",
                Price = 21000,
                Rating = 7.5
            };

            Car car = new Car()
            {
                BrandName = carDTO.BrandName,
                CarName = carDTO.CarName,
                Price = carDTO.Price,
                Rating = carDTO.Rating
            };

                    // ManiRepositoriym string qaytaradi-de, shunga aybga buyumisiz Model qaytarmagani uchun)
            string expectedResult = "Create amalga oshdi!";

            _mockCarService.Setup(x => x.Create(It.IsAny<Car>()))
                .Returns(expectedResult);

            // Act
            string actualResult = _carService.Create(carDTO);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

//GetAll uchun
        [Fact]
        public async Task ShouldGetAllCar()
        {
            // Arrange
            IEnumerable<Car> expectedResult = [
            new Car
            {
                Id = 1,
                CarName="Matiz",
                BrandName="Daewoo",
                Price=3500,
                Rating=3.4
            },
            
            new Car
            {
                Id = 2,
                CarName = "Jiguli",
                BrandName = "Lada",
                Price = 1000,
                Rating = 2.1
            }];

            _mockCarService.Setup(x => x.GetAll())
                .Returns(expectedResult);

            // Act
            IEnumerable<Car> actualResult = _carService.GetAll();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

//GetByName uchun
        [Fact]
        public async Task ShouldGetByNameCar()
        {
            // Arrange
            string inputData = "Spark";
            Car expectedResult = new Car()
            {
                Id = 1,
                CarName = "Spark",
                BrandName = "Chevrolet",
                Price = 8.500,
                Rating = 7.5
            };

            _mockCarService.Setup(x => x.GetByAny(x=>x.CarName==inputData))
                .Returns(expectedResult);

            // Act
            Car actualResult = _carService.GetByName(inputData);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

//Update uchun
        [Fact]
        public async Task ShouldUpdateCar()
        {
            // Arrange
            Car inputData = new Car()
            {
                Id=1,
                CarName = "Spark",
                BrandName = "Chevrolet",
                Price = 8.500,
                Rating = 7.5
            };

            CarDTO carDTO = new CarDTO()
            {
                CarName = "Spark",
                BrandName = "Chevrolet",
                Price = 8.500,
                Rating = 7.5
            };
            int id = 1;
            string expectedResult = "Update amalga oshdi!";

            //Think wisely!)
            _mockCarService.Setup(x => x.GetByAny(x => x.Id == id))
                .Returns(new Car());

            _mockCarService.Setup(x => x.Update(It.IsAny<Car>()))
                .Returns(expectedResult);

            // Act
            string actualResult = _carService.Update(id,carDTO);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

//Delete uchun
        [Fact]
        public async Task ShouldDeleteCar()
        {
            // Arrange
            int inputData = 1;

            string expectedResult = "Delete amalga oshdi!";

            _mockCarService.Setup(x => x.Delete(x=>x.Id==inputData))
                .Returns(expectedResult);

            // Act
            string actualResult = _carService.Delete(inputData);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
