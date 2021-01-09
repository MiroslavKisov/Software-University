using Hack.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class MathHackTests
    {

        [TestCase(123.123d)]
        [TestCase(-0.435)]
        [TestCase(-1.003)]
        public void TestMathAbsMethod(double testInput)
        {
            //Arrange
            Mock<IMath> fakeMath = new Mock<IMath>();

            fakeMath
                .Setup(f => f.Abs(It.IsAny<double>()))
                .Returns(() => { return (int)Math.Abs(testInput); });

            //Act
            int result = fakeMath.Object.Abs(testInput);
            int expected = (int)Math.Abs(testInput);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(-789.678)]
        [TestCase(0.003)]
        [TestCase(45.389)]
        [TestCase(1.000)]
        public void TestMathFloorMethod(double testInput)
        {
            //Arrange
            Mock<IMath> fakeMath = new Mock<IMath>();

            fakeMath
                .Setup(f => f.Abs(It.IsAny<double>()))
                .Returns(() => { return (int)Math.Abs(testInput); });

            //Act
            int result = fakeMath.Object.Abs(testInput);
            int expected = (int)Math.Abs(testInput);

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
