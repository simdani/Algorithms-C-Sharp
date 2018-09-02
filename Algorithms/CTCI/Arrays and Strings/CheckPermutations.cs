// Question: Given two strings writw a method to decide if one is a permutation of the other

using System;

namespace Algorithms.CTCI.Arrays_and_Strings
{
    public static class CheckPermutations
    {
        // Solution #1 sort the strings (if strings are equal than we have a permutation
        public static bool PermutationsSortString(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            return SortString(s).Equals(SortString(t));
        }

        private static string SortString(string s)
        {
            char[] content = s.ToCharArray();
            Array.Sort(content);
            return new string(content);
        }

        // Solution #2 check if th e strings have identical character counts.
        public static bool Permutations(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            int[] letters = new int[128]; // possible letters(assumption)

            char[] s_array = s.ToCharArray();
            foreach (char c in s_array) // count number of each char in s word.
            {
                letters[c]++;
            }

            for (int i = 0; i < t.Length; i++)
            {
                int c = t[i];
                letters[c]--; // remove t world letter
                if (letters[c] < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
