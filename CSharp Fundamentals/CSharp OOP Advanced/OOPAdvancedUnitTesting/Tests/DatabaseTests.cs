using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class DatabaseTest
    {
        [Test]
        public void TestDatabaseConstructorWithLongerInputArrayLength()
        {
            //Arrange
            int[] inputNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            //Assert
            Assert.Throws<InvalidOperationException>(() => new NumberDatabase(inputNumbers));
        }

        [Test]
        public void TestDatabaseConstructorWithShorterInputArrayLength()
        {
            //Arrange
            int[] inputNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            NumberDatabase database = new NumberDatabase(inputNumbers);

            //Assert
            Assert.Pass();
        }

        [Test]
        public void TestDatabaseConstructorWithExactInputArrayLength()
        {
            //Arrange
            int[] inputNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            NumberDatabase database = new NumberDatabase(inputNumbers);

            //Assert
            Assert.Pass();
        }

        [Test]
        public void TestFetchMethod()
        {
            //Arrange
            int[] inputNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            NumberDatabase database = new NumberDatabase(inputNumbers);

            //Act
            int[] expected = database.Fetch();

            //Assert
            Assert.AreEqual(expected, inputNumbers);
        }

        [Test]
        public void TestAddIntegerMethodWithFullDatabase()
        {
            //Arrange
            int[] inputNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            NumberDatabase database = new NumberDatabase(inputNumbers);

            //Assert
            Assert.Throws<InvalidOperationException>(() => database.AddInteger(12));
        }

        [Test]
        public void TestAddIntegerMethodWithEmptyDatabase()
        {
            //Arrange
            int[] inputNumbers = new int[0];
            NumberDatabase database = new NumberDatabase(inputNumbers);

            //Act
            database.AddInteger(27);
            inputNumbers = database.Fetch();

            //Assert
            Assert.AreEqual(27, inputNumbers[0]);
        }

        [Test]
        public void TestAddIntegerMethodWithSomeNumbersInIt()
        {
            //Arrange
            int[] inputNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            //Act
            NumberDatabase database = new NumberDatabase(inputNumbers);
            database.AddInteger(12);

            Assert.AreEqual(12, inputNumbers[inputNumbers.Length - 1]);
        }

        [Test]
        public void TestRemoveItemMethodWithEmptyDatabase()
        {
            //Arrange
            int[] inputNumbers = { };
            NumberDatabase database = new NumberDatabase(inputNumbers);

            //Assert
            Assert.Throws<InvalidOperationException>(() => database.RemoveItem());
        }

        [Test]
        public void TestRemoveItemMethodWithFullDatabase()
        {
            //Arrange
            int[] inputNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            NumberDatabase database = new NumberDatabase(inputNumbers);

            //Act
            database.RemoveItem();
            int[] expected = database.Fetch();

            //Assert
            Assert.AreEqual(15, expected[expected.Length - 1]);
        }

        [Test]
        public void TestRemoveItemMethodWithSomeValueInDatabase()
        {
            //Arrange
            int[] inputNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            NumberDatabase database = new NumberDatabase(inputNumbers);

            //Act
            database.RemoveItem();
            int[] expected = database.Fetch();

            //Assert
            Assert.AreEqual(11, expected[expected.Length - 1]);
        }
    }
}
