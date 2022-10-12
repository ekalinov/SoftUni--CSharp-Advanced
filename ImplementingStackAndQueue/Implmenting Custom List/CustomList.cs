using System;


namespace Implmenting_Custom_List
{
    public class CustomList
    {
        private const int InitialArrayLenght = 2;

        private int[] internalArray;
        private int count = 0;


        public CustomList()
        {
            this.internalArray = new int[InitialArrayLenght];
        }


        public int Count { get; private set; }
     
        public int this[int index]
        {
            get
            {
                if (index>=count)
                {
                    throw new IndexOutOfRangeException();   
                }
                return index;
            }

            set
            {
                if (index >= count)
                {
                    throw new IndexOutOfRangeException();
                }
                internalArray[index]=value;
            }
        }



        //------------------------------------------------------------------------------------------------< Private Methods
        //Resize – this method will be used to increase the internal collection's length twice.

        private void Resize()
        {
            int[] ints = new int[internalArray.Length*2];

            for (int i = 0; i < internalArray.Length; i++)
            {
                ints[i] = internalArray[i];
            }

            internalArray = ints;
        }

        //Shrink – this method will help us to decrease the internal collection's length twice.
        private void Shrink()
        {
            int[] ints = new int[internalArray.Length / 2];

            for (int i = 0; i < internalArray.Length; i++)
            {
                ints[i] = internalArray[i];
            }

            internalArray = ints;
        }

        //Shift – this method will help us to rearrange the internal collection's elements after removing one.
        private void Shift(int index)
        {
            for (int i = index; i < internalArray.Length; i++)
            {
                internalArray[i] = internalArray[i + 1];

            }

        }



        //-------------------------------------------------------------------------------------------------< Public Methods
        //Adds the given element to the end of the list
        public void Add(int element)
        {
            if (Count==internalArray.Length)
            {
                Resize();
            }

            internalArray[Count] = element;
            this.Count++;

        }

        //Removes the element at the given index
        public int RemoveAt(int index)
        {
            Shift(index);

            if (this.Count==this.internalArray.Length/4)
            {
                Shrink();
            }

            return this.Count--;
        }

        //Checks if the list contains the given element returns(True or False)
        public bool Contains(int element)
        {
            return true;
        }

        //Swaps the elements at the given indexes
        public void Swap(int firstIndex, int secondIndex)
        {


        }

    }
}
