using System;

namespace Algorithms.Leetcode.Problems200_299
{
    public class ValidAnagram
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            char[] sChars = s.ToCharArray();
            char[] tChars = t.ToCharArray();

            int[] arr = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                arr[s[i] - 97]++;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (!(arr[t[i] - 97] > 0)) return false;
                arr[t[i] - 97]--;
            }

            return true;
        }
    }
}
