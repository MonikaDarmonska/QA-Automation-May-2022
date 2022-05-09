using Collections;
using NUnit.Framework;
using System;
using System.Linq;

namespace Collections.Tests
{
    public class CollectionTests
    {
      
        [Test]
        public void Test_Collection_EmptyConstructor()
        {
            //Arrange
            var nums = new Collection<int>();

            //Act
            //Assert
            Assert.AreEqual(0, nums.Count);
            Assert.AreEqual(16, nums.Capacity);
            Assert.That(nums.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {           
            var nums = new Collection<int>(5);
            Assert.That(nums.ToString(), Is.EqualTo("[5]"));
        }

        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {
            var nums = new Collection<int>(5, 10, 15);

            Assert.That(nums.ToString(), Is.EqualTo("[5, 10, 15]"));
        }

        [Test]
        public void Test_Collections_Add()
        {
            var nums = new Collection<int>(5);
            nums.Add(6);
            nums.Add(7);

            Assert.That(nums.ToString(), Is.EqualTo("[5, 6, 7]"));
        }   
        
        [Test]
        public void Test_Collection_AddRangeWithGrow()
        {
            var nums = new Collection<int>();
            int oldCapacity = nums.Capacity;
            var newNums = Enumerable.Range(1000, 2000).ToArray();

            nums.AddRange(newNums);

            string expectedNums = "[" + string.Join(", ", newNums) + "]";
            Assert.That(nums.ToString(), Is.EqualTo(@expectedNums));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }

        [Test]
        public void Test_Collection_GetByIndex()
        {
            var names = new Collection<string>("Monika", "Ivan", "Maria"); //Arrange

            var firstIndex = names[0]; //Act
            var secondIndex = names[1];

            Assert.That(firstIndex, Is.EqualTo("Monika")); //Assert
            Assert.That(secondIndex, Is.EqualTo("Ivan"));
        }

        [Test]
        public void Test_Collection_GetByInvalidIndex()
        {
            var names = new Collection<string>("John", "Peter");

            Assert.That(() => { var name = names[-1]; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(() => { var name = names[2]; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(() => { var name = names[500]; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());

            Assert.That(names.ToString(), Is.EqualTo("[John, Peter]"));
        }

        [Test]
        public void Test_Collection_SetByIndex()
        {
            var names = new Collection<string>("John", "Peter");
            names[0] = "Maria";
            names[1] = "Anna";

            Assert.That(names.ToString(), Is.EqualTo("[Maria, Anna]"));
        }

        [Test]
        public void Test_Collection_SetByInvalidIndex()
        {
            var names = new Collection<string>("John", "Peter");           

             Assert.That(() => { var name = names[-1]; },
            Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]

        public void Test_Collection_InsertAtStart() 
        {
             var nums = new Collection<int>(1, 2, 2, 4, 5, 6);
            nums.InsertAt(0, 66);

            Assert.That(nums.ToString(), Is.EqualTo("[66, 1, 2, 2, 4, 5, 6]"));              
        }

        [Test]
        public void Test_Collection_InsertAtEnd()
        {
            var nums = new Collection<int>(1, 2, 3, 4, 5, 6);
            
            nums.InsertAt(nums.Count, 100);

            Assert.That(nums.ToString(), Is.EqualTo("[1, 2, 3, 4, 5, 6, 100]"));
        }

        [Test]
        public void Test_Collection_InsertAtMiddle()
        {
            var nums = new Collection<int>(1, 2, 3, 4, 5, 6, 7);
            nums.InsertAt(nums.Count / 2, 100);

            Assert.That(nums.ToString(), Is.EqualTo("[1, 2, 3, 100, 4, 5, 6, 7]"));
        }

        [Test]
        public void Test_Collection_InsertAtWithGrow()
        {
            var nums = new Collection<int>(1, 2, 3, 4, 5, 6);
            nums.InsertAt(nums.Count, 7);

            Assert.That(nums.ToString(), Is.EqualTo("[1, 2, 3, 4, 5, 6, 7]"));
        }

        [Test]
        public void Test_Collection_InsertAtInvalidIndex()
        {
            var names = new Collection<string>("John", "Peter");      

            Assert.That(() => { names.InsertAt(-1, "Maria"); },
          Throws.InstanceOf<ArgumentOutOfRangeException>());

        }

        [Test]
        public void Test_Collection_ExchangeMiddle()
        {
            var nums = new Collection<int>(1, 2, 3, 4);
            nums.Exchange(0, 1);

            Assert.That(nums.ToString(), Is.EqualTo("[2, 1, 3, 4]"));
        }

        [Test]
        public void Test_Collection_ExchangeFirstLast()
        {
            var nums = new Collection<int>(1, 2, 3, 4);
            nums.Exchange(0, nums.Count -1);

            Assert.That(nums.ToString(), Is.EqualTo("[4, 2, 3, 1]"));
        }

        [Test]
        public void Test_Collection_ExchangeInvalidIndexes()
        {
            var names = new Collection<string>("John", "Peter");

            Assert.That(() => { names.Exchange(-1, 3); },
         Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_RemoveAtStart()
        {
            var nums = new Collection<int>(1, 2, 3, 4);
            nums.RemoveAt(0);

            Assert.That(nums.ToString(), Is.EqualTo("[2, 3, 4]"));
        }

        [Test]
        public void Test_Collection_RemoveAtEnd()
        {
            var nums = new Collection<int>(1, 2, 3, 4);
            nums.RemoveAt(nums.Count-1);

            Assert.That(nums.ToString(), Is.EqualTo("[1, 2, 3]"));
        }

        [Test]
        public void Test_Collection_RemoveAtMiddle()
        {
            var nums = new Collection<int>(1, 2, 3, 4);
            nums.RemoveAt(nums.Count /2);

            Assert.That(nums.ToString(), Is.EqualTo("[1, 2, 4]"));
        }

        [Test]
        public void Test_Collection_RemoveAtInvalidIndex()
        {
            var names = new Collection<string>("John", "Peter");

            Assert.That(() => { names.RemoveAt(-1); },
         Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_RemoveAll()
        {
            var nums = new Collection<int>(1, 2, 3, 4);

            Assert.That(() => { nums.RemoveAt(nums.Count); },
        Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Test_Collection_Clear()
        {
            var nums = new Collection<int>(1, 2, 3, 4);
            nums.Clear();
           
            Assert.That(nums.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collection_CountAndCapacity()
        {
            var nums = new Collection<int>(1, 2, 3, 4, 5, 6, 7, 8);
            int expectedCount = nums.Count;
            int actualCount = 8;
            Assert.AreEqual(expectedCount, actualCount);

            int expectedCapacityt = nums.Count * 2;
            int actualCapacity = 16;
            Assert.AreEqual(expectedCapacityt, actualCapacity);
        }

        [Test]
        public void Test_Collection_ToStringEmpty()
        {
            var nums = new Collection<int>();

            Assert.That(nums.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void Test_Collection_ToStringSingle()
        {
            var nums = new Collection<int>(1);

            Assert.That(nums.ToString(), Is.EqualTo("[1]"));
        }

        [Test]
        public void Test_Collection_ToStringMultiple()
        {
            var nums = new Collection<int>(1, 3, 5, 7, 9);

            Assert.That(nums.ToString(), Is.EqualTo("[1, 3, 5, 7, 9]"));
        }

        [Test]
        public void Test_Collection_ToStringNestedCollections()
        {
            var names = new Collection<string>("Teddy", "Gerry");
            var nums = new Collection<int>(10, 20);
            var dates = new Collection<DateTime>();
            var nested = new Collection<object>(names, nums, dates);
            string nestedToString = nested.ToString();

            Assert.That(nestedToString,
              Is.EqualTo("[[Teddy, Gerry], [10, 20], []]"));

        }

        [Test]
        public void Test_Collection_1MillionItems()
        {
            const int itemsCount = 1000000;
            var nums = new Collection<int>();
            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());

            Assert.That(nums.Count == itemsCount);
            Assert.That(nums.Capacity >= nums.Count);
            for (int i = itemsCount - 1; i >= 0; i--)
                nums.RemoveAt(i);
            Assert.That(nums.ToString() == "[]");
            Assert.That(nums.Capacity >= nums.Count);

        }
    }
}