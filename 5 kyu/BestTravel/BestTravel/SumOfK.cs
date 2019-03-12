using System;
using System.Collections.Generic;

namespace BestTravel
{
    public static class SumOfK
    {
        public static int? chooseBestSum(int t, int k, List<int> ls)
        {
            if (ls.Count < k)
                return null;

            Holder holder = new Holder();
            recur(ls, 0, 0, t, k, 0, holder);
            if (holder.max == -1)
                return null;
            return holder.max;
        }

        class Holder
        {
            public int max = -1;
        }

        private static void recur(List<int> list, int i, int numElementsIncluded, int t, int k, int sum, Holder holder)
        {

            if (numElementsIncluded == k && sum <= t)
            {
                holder.max = Math.Max(holder.max, sum);
            }
            if (i == list.Count)
            {
                return;
            }

            recur(list, i + 1, numElementsIncluded + 1, t, k, sum + list[i], holder);
            recur(list, i + 1, numElementsIncluded, t, k, sum, holder);
        }
    }
}

    

