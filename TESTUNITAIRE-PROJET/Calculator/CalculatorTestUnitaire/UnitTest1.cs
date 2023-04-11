using Calculator;
using Moq;
using NUnit.Framework;

namespace CalculatorTestUnitaire
{
    [TestFixture]
    public class Tests
    {
        private Mock<IOperation> _operationMock;
        private  IOperation _operation;
        [SetUp]
        public void Setup()
        {
            _operationMock = new Mock<IOperation>();
            _operation = new Operation();
        }

        [Test]
        public void MultiplicationTest()
        {
            //AAA
            //Arrange
            //Act
        int actual=   _operation.Multiplication(2,6);

            int expect = 12;
            //Assert
            Assert.AreEqual(actual,expect);
        }


        [Test]
        public void SumTest()
        {
            //AAA
            //Arrange
            //Act
            int actual = _operation.Sum(2, 6);

            int expect = 8;
            //Assert
            Assert.AreEqual(actual, expect);
        }
     

    




    }
}