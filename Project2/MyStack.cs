namespace Project2
{
    public class MyStack
	{
		public StackNode top;
		public int size;
		public MyStack()
		{
			// Set node values
			this.top = null;
			this.size = 0;
		}
		// Add node at the top of stack
		public void push(char element)
		{
			this.top = new StackNode(element, this.top);
			this.size++;
		}
		public bool isEmpty()
		{
			if (this.size > 0 && this.top != null)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		// Remove top element of stack
		public void pop()
		{
			if (this.size > 0 && this.top != null)
			{
				var temp = this.top;
				// Change top element of stack
				this.top = temp.next;
				this.size--;
			}
		}
		// Return top element of stack
		public char peek()
		{
			if (this.top == null)
			{
				return ' ';
			}
			return this.top.element;
		}
	}
}
