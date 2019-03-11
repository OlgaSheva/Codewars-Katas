using System;
using System.Collections.Generic;

namespace PersistentBugger
{
    public class Persist
    {
        public static int Persistence(long n)
        {
            if (n < 10)
                return 0;

            var numbers = new List<long>();
            long num = n;
            int count = 0;

            do
            {
                numbers.Clear();

                while (num > 9)
                {
                    numbers.Add(num % 10);
                    num /= 10;
                }
                numbers.Add(num);
                num = 1;

                foreach (var i in numbers)
                    num *= i;

                count++;
            } while (num > 9);

            return count;
        }
    }
}
