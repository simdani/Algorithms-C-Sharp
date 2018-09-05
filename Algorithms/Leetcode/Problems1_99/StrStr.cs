using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Algorithms.Leetcode.Problems1_99
{
    public class StrStr
    {
        public int Haystack(string haystack, string needle)
        {
            for (int i = 0;; i++)
            {
                for (int j = 0;; j++)
                {
                    if (j == needle.Length) return i;
                    if (i + j == haystack.Length) return -1;
                    if (needle[j] != haystack[i + j]) break;
                }
            }
        }
    }
}
