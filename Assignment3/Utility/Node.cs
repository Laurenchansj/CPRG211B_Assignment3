using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
	[DataContract] //add [DataContract] and [DataMember]
	public class Node<NodeType>
	{
		[DataMember]
		public NodeType Data { get; set; }
		[DataMember]
		public Node<NodeType> Next { get; set; }
		public Node(NodeType data)
		{
			Data = data;
			Next = null;
		}

		public override string ToString()
		{
			return Data.ToString();
		}
	}
}
