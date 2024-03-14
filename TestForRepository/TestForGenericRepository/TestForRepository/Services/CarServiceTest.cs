using AutoSalon.Application.Abstractions.IRepositories;
using AutoSalon.Application.IServices;
using AutoSalon.Application.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForRepository.Services
{
    public partial class CarServiceTest
    {
        private readonly ICarService _carService;
        private readonly Mock<ICarRepository> _mockCarService;
        public CarServiceTest()
        {
            _mockCarService = new Mock<ICarRepository>();
            _carService = new CarService(_mockCarService.Object);
        }
    }
}
