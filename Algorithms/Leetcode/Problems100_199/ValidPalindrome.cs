using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Leetcode.Problems100_199
{
    public class ValidPalindrome
    {
        // my solution
        public bool IsPalindrome(string s)
        {
            if (s.Length == 0) return true;

            char[] arr = s.ToLower().Where(c => (char.IsLetterOrDigit(c))).ToArray();

            string modified = new string(arr);

            int back = modified.Length - 1;
            for (int i = 0; i < modified.Length / 2; i++)
            {
                if (modified[i] != modified[back])
                {
                    return false;
                }

                back--;
            }
            return true;
        }

        // improved performance solution
        public bool IsPalindromeInPlace(string s)
        {
            if (s.Length == 0) return true;
            int i = 0;
            int j = s.Length - 1;
            while (i < j)
            {
                while (i < j && !char.IsLetterOrDigit(s[i]))
                    i++;
                while (i < j && !char.IsLetterOrDigit(s[j]))
                    j--;
                if (char.ToLower(s[i++]) != char.ToLower(s[j--]))
                    return false;
            }

            return true;
        }
    }
}
