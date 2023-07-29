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

		
	}
}
