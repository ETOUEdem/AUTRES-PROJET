using EmployeeApp.Models;
using EmployeeApp.Repositories;
using EmployeeApp.Services;
using Moq;
using NUnit.Framework;
using System;

namespace TestEmployeeApp
{
    [TestFixture]
    public class EmployeeServiceUnitTest
    {
        private IEmployeeService _service;
        private Mock<IEmployeeRepository> _mockRepository;
        private Mock<ITaxService> _mockTaxService;


        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IEmployeeRepository>(MockBehavior.Strict);
            _mockTaxService = new Mock<ITaxService>(MockBehavior.Strict);
            _service = new EmployeeService(_mockTaxService.Object,_mockRepository.Object);
        }

        [Test]
        public void CalculateTax_withSampleEmplyee_ShouldCalculateTax()
        {

            //Arrange
            _mockRepository.Setup(r => r.Get(1)).Returns(new Employee {
            Name ="John",
            Id=1,
            JoiningDate = DateTime.Parse("1/1/2018"),
            Salary =5000
            
            });

            _mockTaxService.Setup(t => t.GetTaxeRate()).Returns(0.10);

            //Act
            var actual = _service.CalculateTax(1, DateTime.Parse("4/30/2018"));
            //Assert
            var expected = 2000;
            Assert.Equals(expected,actual);
        }
    }
}