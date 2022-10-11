using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class ListNode
    {

        public ListNode Previous { get; set; }

        public ListNode Next { get; set; }

        public int Value { get; set; }



        public ListNode(int value)
        {
            this.Value = value;
        }
    }
}
