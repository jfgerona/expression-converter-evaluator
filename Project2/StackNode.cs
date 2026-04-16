using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class StackNode
    {
		// Stack data
		public char element;
		public StackNode next;
		public StackNode(char element,
						  StackNode next)
		{
			this.element = element;
			this.next = next;
		}
	}
}
