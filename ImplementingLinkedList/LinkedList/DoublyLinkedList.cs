﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class DoublyLinkedList
    {
        private ListNode head { get; set; }

        private ListNode tail { get; set; }

        public int Count { get; private set; }


        public void AddFirst(int element)
        {
            if (Count == 0)
            {
                head = new ListNode(element);
                tail = new ListNode(element);
                this.Count++;
                return;
            }

            var newHead = new ListNode(element);

            if (Count == 1)
            {
                tail.Previous = newHead;
            }

            head.Previous = newHead;
            newHead.Next = head;
            head = newHead;
            this.Count++;

        }

        public void AddLast(int element)
        {
            if (Count == 0)
            {
                head = new ListNode(element);
                tail = new ListNode(element);
                this.Count++;

                return;
            }
            var newTail = new ListNode(element);

            if (Count == 1)
            {
                head.Next = newTail;
            }

            tail.Next = newTail;
            newTail.Previous = tail;
            tail = newTail;

            this.Count++;
        }

        public int RemoveFirst()
        {

            if (Count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }

            var firstEl = head.Value;

            this.head = head.Next;

            if (head != null)
            {
                this.head.Previous = null;
            }
            else
            {
                this.tail = null;
            }

            this.Count--;


            return firstEl;

        }

        public int RemoveLast()
        {

            if (Count == 0)
            {
                throw new InvalidOperationException("List is empty");
            }

            var lastEl = tail.Value;

            this.tail = tail.Previous;

            if (tail != null)
            {
                this.tail.Next = null;
            }
            else
            {
                this.head = null;
            }

            this.Count--;


            return lastEl;

        }

        public void ForEach(Action<int> action)
        {
            var currNode = this.head;

            while (currNode != null)
            {
                action(currNode.Value);
                currNode=currNode.Next;
            }

        }

        public int[] ToArray()
        {
            var array = new int[this.Count];
            var element = this.head;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = element.Value;
                element = element.Next;
            }

            return array;
        }


    }
}
