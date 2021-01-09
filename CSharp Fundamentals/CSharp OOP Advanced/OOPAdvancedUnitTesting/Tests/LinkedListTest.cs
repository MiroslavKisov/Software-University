using CustomLinkedList;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class LinkedListTest
    {

        [TestCase("Pesho")]
        [TestCase("Gosho")]
        [TestCase("Ivan")]
        [TestCase("Stanimir")]
        [TestCase("Mila")]
        public void TestAddMethodWithString(string testValue)
        {
            //Arrange
            DynamicList<string> dynamicList = new DynamicList<string>();
            int expectedNumberOfelements = 1;

            //Act
            dynamicList.Add(testValue);

            //Assert
            Assert.AreEqual(expectedNumberOfelements, dynamicList.Count);
        }

        [TestCase(1234)]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        [TestCase(0)]
        [TestCase(-1234)]
        public void TestAddMethodWithInt(int testValue)
        {
            //Arrange
            DynamicList<int> dynamicList = new DynamicList<int>();
            int expectedNumberOfelements = 1;

            //Act
            dynamicList.Add(testValue);

            //Assert
            Assert.AreEqual(expectedNumberOfelements, dynamicList.Count);
        }

        [TestCase(0.1234d)]
        [TestCase(double.MaxValue)]
        [TestCase(double.MinValue)]
        [TestCase(0)]
        [TestCase(-0.1234d)]

        public void TestAddMethodWithDouble(double testValue)
        {
            //Arrange
            DynamicList<double> dynamicList = new DynamicList<double>();
            int expectedNumberOfelements = 1;

            //Act
            dynamicList.Add(testValue);

            //Assert
            Assert.AreEqual(expectedNumberOfelements, dynamicList.Count);
        }

        [Test]
        public void TestAddMethodWithWithMultipleValues()
        {
            //Arrange
            DynamicList<object> dynamicList = new DynamicList<object>();
            object[] items = { 1, "one", 123.234d, -0.241434m, "two", long.MaxValue, int.MinValue };
            int expectedNumberOfelements = items.Length;

            //Act
            AddItemsToCollection(dynamicList, items);

            //Assert
            Assert.AreEqual(expectedNumberOfelements, dynamicList.Count);
        }

        [Test]
        public void TestRemoveMethodWithExistingItem()
        {
            //Arrange
            DynamicList<object> dynamicList = new DynamicList<object>();
            object[] items = { 1, "one", 123.234d, -0.241434m, "two", long.MaxValue, int.MinValue };

            //Act
            AddItemsToCollection(dynamicList, items);
            int expectedIndexOfRemovedElement = dynamicList.IndexOf("one");
            int indexOfRemovedElement = dynamicList.Remove("one");

            //Assert
            Assert.AreEqual(expectedIndexOfRemovedElement, indexOfRemovedElement);

        }

        [Test]
        public void TestRemoveElementWithUnexistingItem()
        {
            //Arrange
            DynamicList<object> dynamicList = new DynamicList<object>();
            object[] items = { 1, "one", 123.234d, -0.241434m, "two", long.MaxValue, int.MinValue };

            //Act
            AddItemsToCollection(dynamicList, items);
            int expectedIndexOfRemovedElement = dynamicList.IndexOf("notExisting");
            int indexOfRemovedElement = dynamicList.Remove("notExisting");

            //Assert
            Assert.AreEqual(expectedIndexOfRemovedElement, indexOfRemovedElement);
        }

        [Test]
        public void TestRemoveAtMethodWithValidIndex()
        {
            //Arrange
            DynamicList<object> dynamicList = new DynamicList<object>();
            object[] items = { 1, "one", 123.234d, -0.241434m, "two", long.MaxValue, int.MinValue };

            //Act
            AddItemsToCollection(dynamicList, items);
            var expectedItem = "two";
            var removedItem = dynamicList.RemoveAt(4);

            //Assert
            Assert.AreEqual(expectedItem, removedItem);
        }

        [Test]
        public void TestRemoveAtMethodWithWithNegativeIndex()
        {
            //Arrange
            DynamicList<object> dynamicList = new DynamicList<object>();
            object[] items = { 1, "one", 123.234d, -0.241434m, "two", long.MaxValue, int.MinValue };
            int index = -1;

            //Act
            AddItemsToCollection(dynamicList, items);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => dynamicList.RemoveAt(index));
        }

        [Test]
        public void TestRemoveAtMethodWithLargerThanLengthIndex()
        {
            //Arrange
            DynamicList<object> dynamicList = new DynamicList<object>();
            object[] items = { 1, "one", 123.234d, -0.241434m, "two", long.MaxValue, int.MinValue };
            int index = 200;

            //Act
            AddItemsToCollection(dynamicList, items);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => dynamicList.RemoveAt(index));
        }

        [Test]
        public void TestIndexOfMethodWithExistingIndex()
        {
            //Arrange
            DynamicList<object> dynamicList = new DynamicList<object>();
            object[] items = { 1, "one", 123.234d, -0.241434m, "two", long.MaxValue, int.MinValue };
            int expectedIndex = 2;

            //Act
            AddItemsToCollection(dynamicList, items);
            int testIndex = dynamicList.IndexOf(123.234d);

            //Assert
            Assert.AreEqual(expectedIndex, testIndex);
        }

        [Test]
        public void TestIndexOfMethodWithNullValue()
        {
            //Arrange
            DynamicList<object> dynamicList = new DynamicList<object>();
            object[] items = { 1, "one", 123.234d, -0.241434m, "two", long.MaxValue, int.MinValue };
            int expectedIndex = -1;

            //Act
            AddItemsToCollection(dynamicList, items);
            int testIndex = dynamicList.IndexOf(null);

            //Assert
            Assert.AreEqual(expectedIndex, testIndex);
        }

        [Test]
        public void TestIndexOfMethodWithNonExistentValue()
        {
            //Arrange
            DynamicList<object> dynamicList = new DynamicList<object>();
            object[] items = { 1, "one", 123.234d, -0.241434m, "two", long.MaxValue, int.MinValue };
            int expectedIndex = -1;

            //Act
            AddItemsToCollection(dynamicList, items);
            int testIndex = dynamicList.IndexOf(500);

            //Assert
            Assert.AreEqual(expectedIndex, testIndex);
        }

        [Test]
        public void TestContainsMethodWithExistingItem()
        {
            //Arrange
            DynamicList<object> dynamicList = new DynamicList<object>();
            object[] items = { 1, "one", 123.234d, -0.241434m, "two", long.MaxValue, int.MinValue };

            //Act
            AddItemsToCollection(dynamicList, items);

            //Assert
            Assert.IsTrue(dynamicList.Contains(long.MaxValue));
        }

        [Test]
        public void TestContainsMethodWithNonExistentItem()
        {
            //Arrange
            DynamicList<object> dynamicList = new DynamicList<object>();
            object[] items = { 1, "one", 123.234d, -0.241434m, "two", long.MaxValue, int.MinValue };

            //Act
            AddItemsToCollection(dynamicList, items);

            //Assert
            Assert.IsFalse(dynamicList.Contains("Pesho"));
        }

        public void AddItemsToCollection(DynamicList<object> dynamicList, object[] items)
        {
            foreach (var item in items)
            {
                dynamicList.Add(item);
            }
        }
    }
}
