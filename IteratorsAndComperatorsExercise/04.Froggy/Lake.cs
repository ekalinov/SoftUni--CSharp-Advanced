using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _04.Froggy
{
    public class Lake :IEnumerable<int> 
    {
        private List<int> stones;

        public Lake(List<int> stones)
        {
            this.stones = stones;
        }

        public void Jumping()
        {
            List<int> list = new List<int>();

            for (int i = 0; i < stones.Count; i += 2)
            {
                list.Add(stones[i]);
            }
            for (int i = stones.Count - 1; i >= 0; i--)
            {
                if (i%2!=0)
                {
                    list.Add(stones[i]);
                }
            }

            Console.WriteLine(String.Join(", ",list));
        }


        public IEnumerator<int> GetEnumerator()
        {
            foreach (var item in stones)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
    }
}
