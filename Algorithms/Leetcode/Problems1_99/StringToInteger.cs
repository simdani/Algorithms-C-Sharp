using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Leetcode.Problems1_99
{
    public class StringToInteger
    {
        public int MyAtoi(string str)
        {
            str = str.TrimStart();

            if (str == String.Empty || !(Char.IsDigit(str[0]) || str[0] == '+' || str[0] == '-'))
            {
                return 0;
            }

            string s = String.Empty;

            for (int i = 0; i < str.Length; i++)
            {
                s = s + str[i];

                if (i + 1 < str.Length && !Char.IsDigit(str[i + 1]))
                {
                    break;
                }
            }

            if (s == "+" || s == "-")
            {
                return 0;
            }


            if (Int32.TryParse(s, out int r))
            {
                return r;
            }
            else if (!s.Contains('-'))
            {
                return Int32.MaxValue;
            }
            else
            {
                return Int32.MinValue;
            }
        }
    }
}
