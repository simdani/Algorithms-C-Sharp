// Question: Implement an algorithm to determine if string has all unique characters

namespace Algorithms.CTCI.Arrays_and_Strings
{
    public static class UniqueString
    {
        // Solution 1 (Time complexity is O(n)
        public static bool IsUniqueChars(string word)
        {
            if (word.Length > 128)
            {
                return false;
            }
            bool[] charSet = new bool[128];
            for (int i = 0; i < word.Length; i++)
            {
                int value = word[i];
                if (charSet[value])
                {
                    return false;
                }

                charSet[value] = true;
            }
            return true;
        }

        // solution 2 (reduced space usage) but only works with lowercase characters
        public static bool IsUniqueCharsLowerCase(string word)
        {
            int checker = 0;
            for (int i = 0; i < word.Length; i++)
            {
                int val = word[i] - 'a';
                if ((checker & (1 << val)) > 0)
                {
                    return false;
                }

                checker |= (1 << val);
            }

            return true;
        }

        // solution 3 (compare every character of the string) O(n^2) time and O(1) space
        public static bool CompareEveryCharacter(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < word.Length; j++)
                {
                    if (i != j && word[i] == word[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
