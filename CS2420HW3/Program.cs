public class Program
{
	static void Main()
	{
		DoublyLinkedList List = new DoublyLinkedList([1, 2, 3, 4, 5]);
		List.PrintList();
		List.Reverse();
		List.PrintList();
		DoublyLinkedList List2 = new DoublyLinkedList([3, 8, 5, 2, 10, 1]);
		List2.PrintList();
		List2.PartitionList(5);
		List2.PrintList();

	}
	public class Node
	{
		public int value;
		public Node next;
		public Node prev;
		public Node(int value)
		{
			this.value = value;
		}
	}
	public class DoublyLinkedList
	{
		private Node head;
		private Node tail;
		private int length;
		public DoublyLinkedList(int value)
		{
			Node newNode = new Node(value);
			head = newNode;
			tail = newNode;
			length = 1;
		}
		public DoublyLinkedList(int[] arr)
		{
			foreach (int num in arr)
			{
				Append(num);
			}
		}
		public void PrintList()
		{
			Node temp = head;
			while (temp != null)
			{
				Console.Write(temp.value);
				if (temp.next != null) Console.Write(" <-> ");
				temp = temp.next;
			}
			Console.WriteLine();
		}
		public void Append(int value)
		{
			Node newNode = new Node(value);
			if (length == 0)
			{
				head = newNode;
				tail = newNode;
			}
			else
			{
				tail.next = newNode;
				newNode.prev = tail;
				tail = newNode;
			}
			length++;
		}
		public void Prepend(int value)
		{
			Node newNode = new Node(value);
			if (length == 0)
			{
				head = newNode;
				tail = newNode;
			}
			else
			{
				newNode.next = head;
				head.prev = newNode;
				head = newNode;
			}
			length++;
		}
		public Node RemoveFirst()
		{
			if (length == 0) return null;
			Node temp = head;
			if (length == 1)
			{
				head = null;
				tail = null;
			}
			else
			{
				head = head.next;
				head.prev = null;
				temp.next = null;
			}
			length--;
			return temp;
		}
		public Node RemoveLast()
		{
			if (length == 0) return null;
			Node temp = tail;
			if (length == 1)
			{
				head = null;
				tail = null;
			}
			else
			{
				tail = tail.prev;
				temp.prev = null;
				tail.next = null;
			}
			length--;
			return temp;
		}
		public void Reverse()
		{
			if (head == null || length == 1) return;
			Node current = head;
			Node temp;
			while (current != null)
			{
				temp = current.prev;
				current.prev = current.next;
				current.next = temp;
				current = current.prev;
			}
			temp = head;
			head = tail;
			tail = temp;
		}
		public void PartitionList(int x)
		{
			if (head == null || head.next == null) return;
			Node dummy1 = new Node(0);
			Node dummy2 = new Node(0);
			Node prev1 = dummy1;
			Node prev2 = dummy2;
			Node current = head;
			while (current != null)
			{
				if (current.value < x)
				{
					prev1.next = current;
					current.prev = prev1;
					prev1 = current;
				}
				else
				{
					prev2.next = current;
					current.prev = prev2;
					prev2 = current;
				}
				current = current.next;
			}
			if (dummy2.next != null)
			{
				prev1.next = dummy2.next;
				dummy2.next.prev = prev1;
				head = dummy1.next;
				tail = prev2;
			}
			else
			{
				head = dummy1.next;
				tail = prev1;
			}
			head.prev = null;
			tail.next = null;
		}
	}
}

