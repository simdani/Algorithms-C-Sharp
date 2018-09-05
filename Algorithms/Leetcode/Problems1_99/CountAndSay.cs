using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Leetcode.Problems1_99
{
    public class CountAndSay
    {
        public string CountAndSayProblem(int n)
        {
            if (n == 1)
                return "1";
            
            StringBuilder builder = new StringBuilder();
            string s = CountAndSayProblem(n - 1);
            char say = s[0];
            int count = 1;
            for (int i = 1; i < s.Length; i++)
            {
                char c = s[i];
                if (c == say) count++;
                else
                {
                    builder.Append(count).Append(say);
                    count = 1;
                    say = c;
                }
            }

            builder.Append(count).Append(say);
            return builder.ToString();
        }
    }
}
