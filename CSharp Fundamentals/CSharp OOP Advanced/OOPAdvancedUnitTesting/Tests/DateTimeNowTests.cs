using DateTimeNow.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class DateTimeNowTests
    {
        private Mock<IDateTime> fakeDateTime;
        private DateTime realDateTime;

        [SetUp]
        public void TestInit()
        {
            this.fakeDateTime = new Mock<IDateTime>();
        }

        [TestCase(1)]
        public void TestAddDaysMethod(int days)
        {
            //Arrange
            this.fakeDateTime
                .Setup(d => d.AddDays(It.IsAny<int>()))
                .Returns(DateTime.Now.AddDays(days));
            realDateTime = DateTime.Now;

            //Act
            string actual = fakeDateTime.Object.AddDays(days).ToShortDateString();
            string expected = realDateTime.AddDays(days).ToShortDateString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1)]
        public void TestAddDaysMethodToFeb28InALeapYear(int days)
        {
            //Arrange
            this.fakeDateTime
                .Setup(d => d.AddDays(It.IsAny<int>()))
                .Returns(() =>
                {
                    DateTime dt = new DateTime(2008, 2, 28);
                    return dt.AddDays(days);
                });

            realDateTime = new DateTime(2008, 2, 28);

            //Act
            string actual = fakeDateTime.Object.AddDays(days).ToShortDateString();
            string expected = realDateTime.AddDays(days).ToShortDateString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1)]
        public void TesdAddDaysMethodWithToFeb28InANonLeapYear(int days)
        {
            //Arrange
            this.fakeDateTime
                .Setup(d => d.AddDays(It.IsAny<int>()))
                .Returns(() =>
                {
                    DateTime dt = new DateTime(1900, 2, 28);
                    return dt.AddDays(days);
                });

            realDateTime = new DateTime(1900, 2, 28);

            //Act
            string actual = fakeDateTime.Object.AddDays(days).ToShortDateString();
            string expected = realDateTime.AddDays(days).ToShortDateString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1)]
        public void TesdAddDaysMethodWithOnANewYear(int days)
        {
            //Arrange
            this.fakeDateTime
                .Setup(d => d.AddDays(It.IsAny<int>()))
                .Returns(() =>
                {
                    DateTime dt = new DateTime(1999, 12, 31);
                    return dt.AddDays(days);
                });

            realDateTime = new DateTime(1999, 12, 31);

            //Act
            string actual = fakeDateTime.Object.AddDays(days).ToShortDateString();
            string expected = realDateTime.AddDays(days).ToShortDateString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(-5)]
        public void TestAddDaysMethodWithNegativeValue(int days)
        {
            //Arrange
            this.fakeDateTime
                .Setup(d => d.AddDays(It.IsAny<int>()))
                .Returns(DateTime.Now.AddDays(days));
            realDateTime = DateTime.Now;

            //Act
            string actual = fakeDateTime.Object.AddDays(days).ToShortDateString();
            string expected = realDateTime.AddDays(days).ToShortDateString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1)]
        public void TestAddDaysMethodByAddingADayToDateTimeMaxValue(int days)
        {
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                this.fakeDateTime
                .Setup(d => d.AddDays(It.IsAny<int>()))
                .Returns(DateTime.MaxValue.AddDays(days))
            );
        }

        [TestCase(-1)]
        public void TestAddDaysMethodBySubstractingADayToDateTimeMaxValue(int days)
        {
            this.fakeDateTime
                .Setup(d => d.AddDays(It.IsAny<int>()))
                .Returns(DateTime.MaxValue.AddDays(days));
            realDateTime = DateTime.MaxValue;

            //Act
            string actual = fakeDateTime.Object.AddDays(days).ToShortDateString();
            string expected = realDateTime.AddDays(days).ToShortDateString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1)]
        public void TestAddDaysMethodByAddingADayToDateTimeMinValue(int days)
        {
            this.fakeDateTime
                .Setup(d => d.AddDays(It.IsAny<int>()))
                .Returns(DateTime.MinValue.AddDays(days));
            realDateTime = DateTime.MinValue;

            //Act
            string actual = fakeDateTime.Object.AddDays(days).ToShortDateString();
            string expected = realDateTime.AddDays(days).ToShortDateString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1)]
        public void TestAddDaysMethodBySubstractingADayToDateTimeMinValue(int days)
        {
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            this.fakeDateTime
                .Setup(d => d.AddDays(It.IsAny<int>()))
                .Returns(DateTime.MinValue.AddDays(days)));
        }
    }
}
