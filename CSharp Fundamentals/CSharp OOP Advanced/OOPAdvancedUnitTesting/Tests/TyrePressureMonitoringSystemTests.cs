using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TDDMicroExercises.TirePressureMonitoringSystem;
using TyrePressureMonitoringSystem.Interfaces;

namespace Tests
{
    public class TyrePressureMonitoringSystemTests
    {
        private Mock<ISensor> fakeSensor;
        private Alarm alarm;

        [SetUp]
        public void TestInit()
        {
            fakeSensor = new Mock<ISensor>();
        }

        [TestCase(19.9d)]
        [TestCase(17.0001d)]
        public void TestAlarmMethodWithNormalValue(double pressure)
        {
            //Arrange
            fakeSensor
                .Setup(s => s.PopNextPressurePsiValue())
                .Returns(() =>
                {
                    return pressure;
                });

            alarm = new Alarm(fakeSensor.Object);

            //Act

            alarm.Check();
            bool isTyrePressureOk = alarm.AlarmOn;

            //Assert
            Assert.IsFalse(isTyrePressureOk);
        }

        [TestCase(21.00001d)]
        [TestCase(29.9d)]
        public void TestAlarmMethodWithHigherValue(double pressure)
        {
            //Arrange
            fakeSensor
                .Setup(s => s.PopNextPressurePsiValue())
                .Returns(() =>
                {
                    return pressure;
                });

            alarm = new Alarm(fakeSensor.Object);

            //Act

            alarm.Check();
            bool isTyrePressureOk = alarm.AlarmOn;

            //Assert
            Assert.IsTrue(isTyrePressureOk);
        }

        [TestCase(8.9d)]
        [TestCase(16.99999d)]
        public void TestAlarmMethodWithLowerValue(double pressure)
        {
            //Arrange
            fakeSensor
                .Setup(s => s.PopNextPressurePsiValue())
                .Returns(() =>
                {
                    return pressure;
                });

            alarm = new Alarm(fakeSensor.Object);

            //Act

            alarm.Check();
            bool isTyrePressureOk = alarm.AlarmOn;

            //Assert
            Assert.IsTrue(isTyrePressureOk);
        }

        [TestCase(17.0d)]
        public void TestAlarmMethodWithThresholdLowerValue(double pressure)
        {
            //Arrange
            fakeSensor
                .Setup(s => s.PopNextPressurePsiValue())
                .Returns(() =>
                {
                    return pressure;
                });

            alarm = new Alarm(fakeSensor.Object);

            //Act

            alarm.Check();
            bool isTyrePressureOk = alarm.AlarmOn;

            //Assert
            Assert.IsFalse(isTyrePressureOk);
        }

        [TestCase(21.0d)]
        public void TestAlarmMethodWithThresholdUpperValue(double pressure)
        {
            //Arrange
            fakeSensor
                .Setup(s => s.PopNextPressurePsiValue())
                .Returns(() =>
                {
                    return pressure;
                });

            alarm = new Alarm(fakeSensor.Object);

            //Act

            alarm.Check();
            bool isTyrePressureOk = alarm.AlarmOn;

            //Assert
            Assert.IsFalse(isTyrePressureOk);
        }
    }
}
