// Question: there are three types of edits that can be performed on strings 
// (insert, remove, edit) given to strings write a function if they are one(or zero) away

using System;

namespace Algorithms.CTCI.Arrays_and_Strings
{
    public static class OneAway
    {
        // Solution #1
        public static bool OneAwayEdit(string first, string second)
        {
            if (first.Length == second.Length)
            {
                return OneEditReplace(first, second);
            }
            else if (first.Length + 1 == second.Length)
            {
                return OneEditInsert(first, second);
            }
            else if (first.Length - 1 == second.Length)
            {
                return OneEditInsert(second, first);
            }

            return false;
        }

        private static bool OneEditReplace(string s1, string s2)
        {
            bool foundDifference = false;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    if (foundDifference)
                    {
                        return false;
                    }

                    foundDifference = true;
                }
            }

            return true;
        }

        // check if you can insert a character into s1 to make s2.
        private static bool OneEditInsert(string s1, string s2)
        {
            int index1 = 0;
            int index2 = 0;

            while (index2 < s2.Length && index1 < s1.Length)
            {
                if (s1[index1] != s2[index2])
                {
                    if (index1 != index2)
                    {
                        return false;
                    }

                    index2++;
                }
                else
                {
                    index1++;
                    index2++;
                }
            }

            return true;
        }

        // Solution #2 = first solution made into one whole function
        public static bool OneAwayEditWhole(string first, string second)
        {
            // check given strings length
            if (Math.Abs(first.Length - second.Length) > 1)
            {
                return false; // more than one edit away...
            }

            // get shorter and longer string
            string s1 = first.Length < second.Length ? first : second;
            string s2 = first.Length < second.Length ? second : first;

            int index1 = 0;
            int index2 = 0;
            bool foundDifference = false;

            while (index2 < s2.Length && index1 < s1.Length)
            {
                if (s1[index1] != s2[index2])
                {
                    // ensure that is the first difference found
                    if (foundDifference)
                    {
                        return false;
                    }

                    foundDifference = true;

                    if (s1.Length == s2.Length) // on replace, move shorter ponter
                    {
                        index1++;
                    }
                }
                else
                {
                    index1++; // if matching, move shorter pointer
                }

                index2++; // always move pointer for longer string
            }

            return true;
        }
    }
}
