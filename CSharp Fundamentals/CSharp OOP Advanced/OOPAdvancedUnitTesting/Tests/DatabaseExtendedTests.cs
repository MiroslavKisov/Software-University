using DatabaseExtended;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class DatabaseExtendedTests
    {
        private PersonDataBase personDataBase;

        [SetUp]
        public void PersonDatabaseInit()
        {
            this.personDataBase = new PersonDataBase();
        }

        [TearDown]
        public void ResetDataBase()
        {
            this.personDataBase.Database.Clear();
        }

        [Test]
        public void TestAddMethodWithNonExistentUserName()
        {
            //Arrange
            Person person = new Person("Pesho", 999);

            //Act
            personDataBase.Add(person);

            //Assert
            Assert.That(personDataBase.Database.Exists(x => x.UserName == "Pesho"));
        }

        [Test]
        public void TestAddMethodWithNonExistentId()
        {
            //Arrange
            Person person = new Person("Gosho", 999);

            //Act
            personDataBase.Add(person);

            //Assert
            Assert.That(personDataBase.Database.Exists(x => x.Id == 999));
        }

        [Test]
        public void TestAddMethodWithExistingUserName()
        {
            //Arrange
            Person person = new Person("Stamat", 0);
            Person person2 = new Person("Stamat", 12);

            //Act
            personDataBase.Add(person);

            //Assert
            Assert.Throws<InvalidOperationException>(() => personDataBase.Add(person2));
        }

        [Test]
        public void TestAddMethodWithExistingId()
        {
            //Arrange
            Person person = new Person("Rumen", 12);
            Person person2 = new Person("Iva", 12);

            //Act
            personDataBase.Add(person);

            //Assert
            Assert.Throws<InvalidOperationException>(() => personDataBase.Add(person2));
        }

        [Test]
        public void TestAddMethodWithUserNameEqualsToNull()
        {
            //Arrange
            string userName = null;
            Person person = new Person(userName, 1234);

            //Assert
            Assert.Throws<ArgumentNullException>(() => personDataBase.Add(person));
        }

        [Test]
        public void TestMethodWithNegativeId()
        {
            //Arrange
            long id = long.MinValue;
            Person person = new Person("Milen", id);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => personDataBase.Add(person));
        }

        [Test]
        public void TestRemoveByUserNameMethodWithExistingUserName()
        {
            //Arrange
            Person person = new Person("Ivan", long.MaxValue);

            //Act
            personDataBase.Add(person);
            personDataBase.RemoveByUserName("Ivan");

            //Assert
            Assert.IsEmpty(personDataBase.Database);
        }

        [Test]
        public void TestRemoveByIdMethodWithExistingId()
        {
            //Arrange
            Person person = new Person("Mariana", 435);

            //Act
            personDataBase.Add(person);
            personDataBase.RemoveById(435);

            //Assert
            Assert.IsEmpty(personDataBase.Database);
        }

        [Test]
        public void TestRemoveByUserNameMethodWithNonExistenUserName()
        {
            //Arrange
            Person person = new Person("Stanislava", 99999999);

            //Act
            personDataBase.Add(person);

            //Assert
            Assert.Throws<InvalidOperationException>(() => personDataBase.RemoveByUserName("Gabriela"));
        }

        [Test]
        public void TestRemoveByIdMethodWithNonExistenId()
        {
            //Arrange
            Person person = new Person("Irina", 1234567890);

            //Act
            personDataBase.Add(person);

            //Assert
            Assert.Throws<InvalidOperationException>(() => personDataBase.RemoveById(111));
        }

        [Test]
        public void TestRemoveByUserNameMethodWithUserNameEqualsToNull()
        {
            //Arrange
            string userName = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() => personDataBase.RemoveByUserName(userName));
        }

        [Test]
        public void TestRemoveByIdMethodWithNegativeValue()
        {
            //Arrange
            long id = long.MinValue;

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => personDataBase.RemoveById(id));
        }

        [Test]
        public void TestFindByIdMethodWithExistingId()
        {
            //Arrange
            long id = 123;
            Person person = new Person("Valentina", id);

            //Act
            personDataBase.Add(person);
            Person expectedPerson = personDataBase.FindById(id);

            //Assert
            Assert.AreEqual(expectedPerson, person);
        }

        [Test]
        public void TestFindByIdMethodWithNonExistenId()
        {
            //Arrange
            Person person = new Person("Mandarin", 123355466);

            //Act
            personDataBase.Add(person);

            //Assert
            Assert.Throws<InvalidOperationException>(() => personDataBase.FindById(435));
        }

        [Test]
        public void TestFindByIdMethodWithNegativeId()
        {
            //Arrange
            Person person = new Person("Hristo", 9050435);

            //Act
            personDataBase.Add(person);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => personDataBase.FindById(-100));
        }

        [Test]
        public void TestFindByUserMethodWithExistingUserName()
        {
            //Arrange
            string userName = "Andrey";
            Person person = new Person(userName, 548827674);

            //Act
            personDataBase.Add(person);
            Person expectedPerson = personDataBase.findByUserName(userName);

            //Assert
            Assert.AreEqual(expectedPerson, person);
        }

        [Test]
        public void TestFindByUserMethodWithNonExistenUserName()
        {
            //Arrange
            Person person = new Person("Ceco", 195845466);

            //Act
            personDataBase.Add(person);

            //Assert
            Assert.Throws<InvalidOperationException>(() => personDataBase.findByUserName("NonExisting"));
        }

        [Test]
        public void TestFindByUserMethodWithuserNameEqualsToNull()
        {
            //Arrange
            Person person = new Person("Reni", 90506363435);

            //Act
            personDataBase.Add(person);

            //Assert
            Assert.Throws<ArgumentNullException>(() => personDataBase.findByUserName(null));
        }
    }
}
