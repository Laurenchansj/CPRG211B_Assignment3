using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
	/// <summary>
	/// Linked Lists, Serialization and Testing
	/// </summary>
	/// <remarks>Author: Jiyeon Heo, Sarah Tenebro, Tze-chi Chan</remarks>
	/// <remarks>Date: July 28, 2023</remarks>

	//For serialization, adding [DataContract] and [DataMember]
	[DataContract] 
	public class SLL : ILinkedListADT
	{
		[DataMember]
		public Node<User> Head {  get; set; }

		[DataMember]
		public Node<User> Tail { get; set; }

		[DataMember]
		public int Size { get; set; }

		public SLL()
		{
			Head = Tail = null; 
		}

		/// <summary>
		/// Adds a new element at a specific position.
		/// </summary>
		/// <param name="value">Value that element is to contain.</param>
		/// <param name="index">Index to add new element at.</param>
		/// <exception cref="IndexOutOfRangeException">Thrown if index is negative or past the size of the list.</exception>
		public void Add(User value, int index)
		{
			throw new NotImplementedException();

		}

		/// <summary>
		/// Prepends (adds to beginning) value to the list.
		/// </summary>
		/// <param name="value">Value to store inside element.</param>
		public void AddFirst(User value)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Adds to the end of the list.
		/// </summary>
		/// <param name="value">Value to append.</param>
		public void AddLast(User value)
		{
			throw new NotImplementedException();

		}

		/// <summary>
		/// Clears the list.
		/// </summary>
		public void Clear()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Go through nodes and check if one has value.
		/// </summary>
		/// <param name="value">Value to find index of.</param>
		/// <returns>True if element exists with value.</returns>
		public bool Contains(User value)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the number of elements in the list.
		/// </summary>
		/// <returns>Size of list (0 meaning empty)</returns>
		public int Count()
		{
			throw new NotImplementedException ();
		}

		/// <summary>
		/// Gets the value at the specified index.
		/// </summary>
		/// <param name="index">Index of element to get.</param>
		/// <returns>Value of node at index</returns>
		/// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list.</exception>
		public User GetValue(int index)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the node at the specified index.
		/// </summary>
		/// <param name="index">Index of element to get.</param>
		/// <returns>The node at the specified index.</returns>
		public Node<User> FindNode(int index)   //for finding
		{
			Node<User> node = Head; 
			for(int i=0; i < index ; i++)
			{
				node = node.Next;
			}
			return node;
		}

		/// <summary>
		/// Gets the first index of element containing value.
		/// </summary>
		/// <param name="value">Value to find index of.</param>
		/// <returns>First of index of node with matching value or -1 if not found.</returns>
		public int IndexOf(User value)
		{
			throw new NotImplementedException();

		}

		/// <summary>
		/// Checks if the list is empty.
		/// </summary>
		/// <returns>True if it is empty.</returns>
		public bool IsEmpty()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Removes element at index from list, reducing the size.
		/// </summary>
		/// <param name="index">Index of element to remove.</param>
		/// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list.</exception>
		public void Remove(int index)
		{
			int returnSize = Count();

			if (index < 0 || index > returnSize - 1)
			{
				throw new IndexOutOfRangeException("Index is negative or larger than list size.");
			}
			else
			{
				if(index == 0)
				{
					RemoveFirst();
				}
				else
				{
					Node<User> current = FindNode(index - 1);
					
					current.Next = current.Next.Next;
					Size--;
				}
								
			}
					
		}

		/// <summary>
		/// Removes first element from list
		/// </summary>
		/// <exception cref="CannotRemoveException">Thrown if list is empty.</exception>
		public void RemoveFirst()

		{
			if(Head == null)
			{
				throw new CannotRemoveException("The list is empty");
			}
			else
			{
				Head = Head.Next;
				Size--;
			}
			
		}

		/// <summary>
		/// Removes last element from list
		/// </summary>
		/// <exception cref="CannotRemoveException">Thrown if list is empty.</exception>
		public void RemoveLast()
		{
			if(Head == null)
			{
				throw new CannotRemoveException("The list is empty");

			}
			else
			{
				Node<User> current = FindNode(Size-1);
				
				current.Next = null;
				Tail = current;
				Size--;
			}

		}

		/// <summary>
		/// Replaces the value  at index.
		/// </summary>
		/// <param name="value">Value to replace.</param>
		/// <param name="index">Index of element to replace.</param>
		/// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list.</exception>
		public void Replace(User value, int index)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Copy the values of the linked list nodes into an array.
		/// </summary>
		/// <returns>An array containing the values of the linked list nodes.</returns>
		public User[] SLLToArray()
		{
			Node<User> toArray = Head;
			User[] array = new User[Size];

			for(int i = 0; i < Size; i++)
			{
				array[i] = toArray.Data;
				toArray = toArray.Next;
			}

			return array;
		}

		
		/// <summary>
		/// Represents an exception that is thrown when an element cannot be removed from the list.
		/// </summary>
		public class CannotRemoveException : Exception
		{

			public CannotRemoveException(string message) : base(message) { }

		}
	}
		
}
