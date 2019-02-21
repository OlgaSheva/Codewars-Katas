using System;
using System.Text.RegularExpressions;

namespace Strings__Numbers_and_Calculation
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "4SO9]uY1scMM7agKM[3`uSMm.evU0^n32tir8F17aZ9`nVH[[7lTVVumBc7b`KFj*Dq5n6ur371.pjppNCBsOKG[TMw3iij0Y2DSs1O1q8pAk6k978";
            Kata kata = new Kata();
            string i = kata.calculateString(s);
            Console.WriteLine(i);   
            Console.ReadKey(); 
        }
    }

    public class Kata
    {
        public string calculateString(string calcIt)
        {
            string[] arguments = calcIt.Split(new char[] { '+', '-', '/', '*' });
            
            Regex rgx = new Regex("[^0-9 - /.]");
            arguments[0] = rgx.Replace(arguments[0], "");
            arguments[1] = rgx.Replace(arguments[1], "");

            double a, b;
            long result = 0;
            a = Convert.ToDouble(arguments[0]);
            b = Convert.ToDouble(arguments[1]);

            string[] operetors = { "+", "-", "*", "/" };

            foreach (string op in operetors)
            {
                if (calcIt.Contains(op))
                {
                    switch (op)
                    {
                        case "+":
                            result = (long)Math.Round(a + b);
                            break;
                        case "-":
                            result = (long)Math.Round(a - b);
                            break;
                        case "/":
                            if (b == 0)
                                throw new DivideByZeroException();
                            result = (long)Math.Round(a / b);
                            break;
                        case "*":
                            result = (long)Math.Round(a * b);
                            break;
                    }
                }
            }

            string strResult = "" + result;
            return strResult;
        }
    }
}
