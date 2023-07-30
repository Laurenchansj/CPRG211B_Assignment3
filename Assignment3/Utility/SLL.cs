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

		/// <summary>
		/// Gets the number of elements in the list.
		/// </summary>
		/// <returns>Size of list (0 meaning empty)</returns>
		public int Count()
		{
  			if(Head == null)
     			{
				return 0;
    			}
			return Size;
		}

		/// <summary>
		/// Gets the value at the specified index.
		/// </summary>
		/// <param name="index">Index of element to get.</param>
		/// <returns>Value of node at index</returns>
		/// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list.</exception>
		public User GetValue(int index)
		{
  			Node<User> current = Head;
     
  			if(Head == null || index >= Size || index < 0)
     			{
				throw new IndexOutOfRangeException("The list is empty or the index is out of range or the index is less than 0.");
   			}
      			else
	 		{
    				for(int i = 0; i < index; i++)
				{
    					current = current.Next;
				}
    				return current.Data;
			}
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
  			Node<User> current = Head;
     			int index = 0;
	
  			while(current != null)
    			{
				if(current.Data == value)
     				{
	  				return index;
				}
     				else
	  			{
       					index++;
	     			}
	  		}
     			return -1;
		}

		/// <summary>
		/// Checks if the list is empty.
		/// </summary>
		/// <returns>True if it is empty.</returns>
		public bool IsEmpty()
		{
			if(Head == null)
   			{
      				return true;
	  		}
     			return false;
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
			if(Head == null || index >= Size || index < 0)
   			{
      				throw new IndexOutOfRangeException("The list is empty, or the index is out of range, or the index is less than zero.");
	  		}
     			else
			{
   				Node<User> current = Head;

	   			for(int i = 0; i < index; i++)
       				{	
	   				current = current.Next;
				}
    				current.Data = value;
			}
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
		/// Divide the linked list into two separate linked lists based on a specific index position.
		/// </summary>
		/// <returns>A new linked list which starts from the index position, and the original linked list after dividing.</returns>
  		public SLL Divided(int index)
		{
			SLL newSll = new SLL(); // create a new SLL
			Node<User> runner = Head; // point to the original SLL's Head
			if ((IsEmpty()) || (index < 0 || index >= Count())) // when couldn't find the index
            		{
                		throw new IndexOutOfRangeException("Index is negative or larger than list size.");
           	 	}
			else
			{
				for (int i = index; i < Count(); i++)
				{
					newSll.AddLast(GetValue(i)); // add each item at the end of the new SLL
                		}
			}
			newSll.Size = Size - index;

			for (int i = 0; i < index; i++) // get the last item in original SLL after dividing
			{
				runner = runner.Next;
            		}
            		Tail = runner; // the last item will be the new tail for the original SLL
            		Size = index;

            		return newSll;
		}

		/// <summary>
  		/// Reverses the order of the nodes in the list.
    		/// </summary>
      		public Node<User> ReverseLinkedList()
		{
			if(Head == null)
   			{
      				return null;
	  		}

			Node<User> currentNode = Head;
   			Node<User> previousNode = null;
      			Node<User> tempNext;

    			while(currentNode != null)
       			{
	  			tempNext = currentNode.Next;
      				currentNode.Next = previousNode;
	  			previousNode = currentNode;
      				currentNode = tempNext;
			}
   			return previousNode;
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

