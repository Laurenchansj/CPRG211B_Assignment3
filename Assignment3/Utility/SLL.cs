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
			
			int returnSize = Count();
			

			if(index < 0 || index > returnSize - 1)
			{
				new IndexOutOfRangeException("Index is negative or larger than list size.");
			
			}else if( index == 0)
			{
				AddFirst(value);
			}
			else
			{
				Node<User> temp1 = FindNode(index - 1);

				Node<User> temp2 = temp1.Next; //temp1 pointer target temp2 or set index node as temp2
				Node<User> insertedNode = new Node<User>(value); // make new node with value

				temp1.Next = insertedNode; //pointing temp1.next to inserted node
				insertedNode.Next = temp2; //pointing inseted node to temp2

				Size++;

				if(insertedNode.Next == null)
				{
					Tail = insertedNode;
				}
			}

		}

		/// <summary>
		/// Prepends (adds to beginning) value to the list.
		/// </summary>
		/// <param name="value">Value to store inside element.</param>
		public void AddFirst(User value)
		{
			Node<User> newHead = new Node<User>(value);
			newHead.Next = Head; //move pointer(next) to previous head
			Head = newHead; //set newHead as the Head
			
			if (Head.Next == null)
			{
				Tail = Head;
			}
			
			Size++;
		}

		/// <summary>
		/// Adds to the end of the list.
		/// </summary>
		/// <param name="value">Value to append.</param>
		public void AddLast(User value)
		{
			Node<User> newLastNode = new Node<User>(value);

			if(Size == 0)
			{
				AddFirst(value);
			}
			else
			{
				Tail.Next = newLastNode;
				Tail = newLastNode;
				Size++;
			}

		}

		/// <summary>
		/// Clears the list.
		/// </summary>
		public void Clear()
		{
			Node<User> currentNode = Head;

			while(currentNode != null)
			{
				Node<User> nextNode = currentNode.Next;
				currentNode.Next = null;
				currentNode = nextNode;
			}

			Head = null;
			Tail = null;

			Size = 0;
		}

		/// <summary>
		/// Go through nodes and check if one has value.
		/// </summary>
		/// <param name="value">Value to find index of.</param>
		/// <returns>True if element exists with value.</returns>
		public bool Contains(User value)
		{
			Node<User> currentNode = Head;

			while(currentNode != null)
			{
				if (currentNode.Data.Equals(value))
				{
					return true;
				}
				currentNode = currentNode.Next;
			}

			return false;
		}

		
	}
		
}
