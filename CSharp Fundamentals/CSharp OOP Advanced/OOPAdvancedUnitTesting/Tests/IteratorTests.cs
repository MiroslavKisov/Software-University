using Iterator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class IteratorTests
    {
        [Test]
        public void TestListIteratorConstructorWithNullValue()
        {
            //Arrange
            List<string> inputElements = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() => new ListIterator(inputElements));
        }

        [Test]
        public void TestListIteratorConstructorWithSomeValue()
        {
            //Arrange
            List<string> inputElements = new List<string>();

            //Act
            ListIterator listIterator = new ListIterator(inputElements);

            //Assert
            Assert.Pass();
        }

        [Test]
        public void TestMoveMethodFromZeroIndex()
        {
            //Arrange
            List<string> inputElements = new List<string> { "Bla", "Bla", "Bla" };
            ListIterator listIterator = new ListIterator(inputElements);

            //Act
            bool hasMoved = listIterator.Move();

            //Assert
            Assert.True(hasMoved);
        }

        [Test]
        public void TestMoveMethodFromZeroToLastIndex()
        {
            //Arrange
            List<string> inputElements = new List<string> { "Bla", "Bla", "Bla" };
            ListIterator listIterator = new ListIterator(inputElements);
            bool hasMoved = false;

            //Act
            for (int i = 0; i < inputElements.Count - 1; i++)
            {
                hasMoved = listIterator.Move();
            }

            //Assert
            Assert.IsTrue(hasMoved);
        }

        [Test]
        public void TestMOveMethodForZeroToBeyondLastIndex()
        {
            //Arrange
            List<string> inputElements = new List<string> { "Bla", "Bla", "Bla" };
            ListIterator listIterator = new ListIterator(inputElements);
            bool hasMoved = true;

            //Act
            for (int i = 0; i < inputElements.Count; i++)
            {
                hasMoved = listIterator.Move();
            }

            //Assert
            Assert.IsFalse(hasMoved);
        }

        [Test]
        public void TestHasNextMethodFromZeroIndex()
        {
            //Arrange
            List<string> inputElements = new List<string> { "Bla", "Bla", "Bla" };
            ListIterator listIterator = new ListIterator(inputElements);

            //Act
            listIterator.Move();

            //Assert
            Assert.IsTrue(listIterator.HasNext());
        }

        [Test]
        public void TestHasNextMethodFromLastIndex()
        {
            //Arrange
            List<string> inputElements = new List<string> { "Bla", "Bla", "Bla" };
            ListIterator listIterator = new ListIterator(inputElements);

            //Act
            for (int i = 0; i < inputElements.Count; i++)
            {
                listIterator.Move();
            }

            //Assert
            Assert.False(listIterator.HasNext());
        }

        [Test]
        public void TestPrintElement()
        {
            //Arrange
            List<string> inputElements = new List<string> { "PrintTarget", "Bla", "Bla" };
            ListIterator listIterator = new ListIterator(inputElements);

            //Act
            string expectedElement = listIterator.PrintElement();

            //Assert
            Assert.AreEqual(expectedElement, inputElements[0]);
        }
    }
}
