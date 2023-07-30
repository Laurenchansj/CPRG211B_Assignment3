using Assignment3;
using Assignment3.Utility;
using NUnit.Framework;

namespace Assignment3.Tests
{
	/// <summary>
	/// Linked Lists, Serialization and Testing
	/// </summary>
	/// <remarks>Author: Jiyeon Heo, Sarah Tenebro, Tze-chi Chan</remarks>
	/// <remarks>Date: July 28, 2023</remarks>

	[TestFixture]
	public class SLLTesting
	{
		private ILinkedListADT users;
		private SLL userSLL; //Used in ReversedLinkedListTest method
		
		[SetUp]
		public void Setup()
		{
			this.users = new SLL();
			users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
			users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
			users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
			users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

		}

		/// <summary>
		/// Test for the AddFirst method of the linked list.
		/// It verifies that the AddFirst method correctly adds a new User object to the beginning of the list.
		/// </summary>
		[Test]
		public void TestAddFirst()
		{
			// add a new user to the beginning.
			users.AddFirst(new User(0, "Jiyeon Heo", "jiyeon.heo@gmail.com", "123456"));
			// get the name of the first user in the list
			string expectedName = users.GetValue(0).Name;
			// check that the name of the first user matches the expected name
			Assert.AreEqual("Jiyeon Heo", expectedName);

		}

		/// <summary>
		/// Test for the AddLast method of the linked list.
		/// It verifies that the AddLast method correctly adds a new User object to the end of the list.
		/// </summary>
		[Test]
		public void TestAddLast()
		{
			// add a new user to the end.
			users.AddLast(new User(30, "Tze-chi Chan", "tze-chi@yahoo.com", "963852"));
			// get the name of the last user in the list
			string expectedName = users.GetValue(4).Name;
			// check that the name of the last user matches the expected name
			Assert.That(expectedName, Is.EqualTo("Tze-chi Chan"));
		}

		/// <summary>
		/// Test for the Add method.
		/// It verifies that the Add method correctly add a new User object to the specified index in the list.
		/// </summary>
		[Test]
		public void TestAdd()
		{
			// add a new user to the index 2
			users.Add(new User(10, "Sarah Tenebro", "sarah@sait.com", "98765400"), 2);
			// get the name of the index 2 in the list
			string expectedName = users.GetValue(2).Name;
			// check that the name of the index 2 matches the expected name
			Assert.That(expectedName, Is.EqualTo("Sarah Tenebro"));
		}

		/// <summary>
		/// Test for the removeFirst method
		/// </summary>
		[Test]
		public void TestRemoveFirst()
		{
			// remove the first user
			users.RemoveFirst();
			// get the name of the first(index 0) user object in the list
			string expectedName = users.GetValue(0).Name;
			// check that the name of the first user object matches the expected name
			Assert.That(expectedName, Is.EqualTo("Joe Schmoe"));
		}

		/// <summary>
		/// Test for the removeLast method
		/// </summary>
		[Test]
		public void TestRemoveLast()
		{
			// remove the last user
			users.RemoveLast();
			// get the name of the last(index 2) user object in the list
			string expectedName = users.GetValue(2).Name;
			// get the list size
			int expectedSize = users.Count();

			// check the name of the last user object matches the expected name
			Assert.That(expectedName, Is.EqualTo("Colonel Sanders"));
			// check the size of the list matched the expected size
			Assert.That(expectedSize, Is.EqualTo(3));
		}

		/// <summary>
		/// Test for the remove method
		/// </summary>
		[Test]
		public void TestRemove()
		{
			// remove the index 2 user
			users.Remove(2);
			// get the id of the User object at index 2 in the list after remove
			int expectedNumber = users.GetValue(2).Id;
			// check the id of the User object at index 2 matches the expected id after remove
			Assert.That(expectedNumber, Is.EqualTo(4));
		}

		/// <summary>
		/// Test for the SLLToArray method
		/// </summary>
		[Test]
		public void TestSLLToArray()
		{
			// create an array with the expected User objects
			User[] expectedArray = new User[]
			{
				new User(1, "Joe Blow", "jblow@gmail.com", "password"),
				new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"),
				new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"),
				new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999")
			};

			// convert the linked list to an array
			User[] actualArray = ((SLL)users).SLLToArray();
			// check the converted array matches the expected array
			CollectionAssert.AreEqual(actualArray, expectedArray);

		}

		[Test]
		public void TestDivided()
		{
			User user1 = new User(1, "Joe Blow", "jblow@gmail.com", "password");
			User user2 = new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef");
			User user3 = new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555");
			User user4 = new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999");
            		SLL users1 = new SLL();
			users1.AddLast(user1);
			users1.AddLast(user2);
			users1.AddLast(user3);
			users1.AddLast(user4);
            		SLL users2 = new SLL();
            		users2.AddLast(user1);
            		users2.AddLast(user2);
            		users2.AddLast(user3);
            		users2.AddLast(user4);
            		SLL users3 = new SLL();
            		users3.AddLast(user1);
            		users3.AddLast(user2);
            		users3.AddLast(user3);
            		users3.AddLast(user4);
            		//Test 1: divide from the middle
            		SLL newUsers1 = new SLL();
			newUsers1 = users1.Divided(2); // newusers starts from index 1 (position 2)

			int actualID1 = newUsers1.GetValue(1).Id;
			int expectedID1 = 4;

			//Test 2: divide from the beginning
			SLL newUsers2 = new SLL();
			newUsers2 = users2.Divided(1); // newUsers starts from index 0 (position 1)

			int actualID2 = newUsers2.GetValue(0).Id;
			int expectedID2 = 2;

			//Test 3: divide at the end
			SLL newUsers3 = new SLL();
			newUsers3 = users3.Divided(3); // newUsers starts from index 3 (position 4)
			
			int actualID3 = users3.GetValue(2).Id;
			int expectedID3 = 3;

            		// Testing 1
            		Assert.That(users1.Size, Is.EqualTo(2));// confirm the original SLL size
            		Assert.That(newUsers1.Size, Is.EqualTo(2));// confirm the new SLL size
            		Assert.That(expectedID1, Is.EqualTo(actualID1));
            		// Testing 2
            		Assert.That(users2.Size, Is.EqualTo(1));
            		Assert.That(newUsers2.Size, Is.EqualTo(3));
            		Assert.That(expectedID2, Is.EqualTo(actualID2));
            		// Testing 3
            		Assert.That(users3.Size, Is.EqualTo(3));
            		Assert.That(newUsers3.Size, Is.EqualTo(1));
            		Assert.That(expectedID3, Is.EqualTo(actualID3));
		}

		[Test]
		public void IsEmptyTest()
		{
			Assert.IsFalse(users.IsEmpty());
		}

		[Test]
		public void ReplaceTest()
		{
			//Arrange and Act
			users.Replace(new User(9, "Eugene Krabs", "goldpile@hotmail.com", "moneymoney"), 2);
			string expected = "Eugene Krabs";
			string outputted = users.GetValue(2).Name;

			//Assert
			Assert.AreEqual(expected, outputted);
		}

		[Test]
		public void ReverseLinkedListTest()
		{
			//Arrange and Act
			userSLL = new SLL();
			userSLL.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            		userSLL.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            		userSLL.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            		userSLL.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

			Node<User> reversedList = userSLL.ReverseLinkedList();
			userSLL.Head = reversedList;

			int expected1 = 4;
			int expected2 = 3;
			int expected3 = 2;
			int expected4 = 1;

			int outputted1 = userSLL.GetValue(0).Id;
            		int outputted2 = userSLL.GetValue(1).Id;
            		int outputted3 = userSLL.GetValue(2).Id;
            		int outputted4 = userSLL.GetValue(3).Id;

			//Assert
			Assert.AreEqual(expected1, outputted1);
           		Assert.AreEqual(expected2, outputted2);
            		Assert.AreEqual(expected3, outputted3);
            		Assert.AreEqual(expected4, outputted4);
		}
	}
}
