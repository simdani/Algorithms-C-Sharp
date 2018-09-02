// Questions: given a string wirte a function to check if it is a permutation of a palindrome

namespace Algorithms.CTCI.Arrays_and_Strings
{
    public static class PalindromePermutation
    {
        // solution 1, check if we have max one odd character in phrase (takes O(n) time)
        public static bool IsPermutationofPalindrome(string phrase)
        {
            int[] table = BuildCharFrequencyTable(phrase);
            return CheckMaxOneOdd(table);
        }

        // check that no more than one character has an odd count.
        private static bool CheckMaxOneOdd(int[] table)
        {
            bool foundOdd = false;
            foreach (int count in table)
            {
                if (count % 2 == 1)
                {
                    if (foundOdd)
                    {
                        return false;
                    }

                    foundOdd = true;
                }
            }

            return true;
        }

        // Map each character to a number (a to 0, b to 1, c to 2)
        // non letters map to -1
        private static int GetCharNumber(char c)
        {
            int a = (int) char.GetNumericValue('a');
            int z = (int) char.GetNumericValue('z');
            int val = (int) char.GetNumericValue(c);
            if (a <= val && val <= z)
            {
                return val - a;
            }

            return -1;
        }

        // Count how many times each character appears
        private static int[] BuildCharFrequencyTable(string phrase)
        {
            int[] table = new int[(int) (char.GetNumericValue('z') - char.GetNumericValue('a') + 1)];

            foreach (char c in phrase.ToCharArray())
            {
                int x = GetCharNumber(c);
                if (x != -1)
                {
                    table[x]++;
                }
            }

            return table;
        }

        // Solution #2: optimized
        public static bool IsPermutationOfPalindromeOptimized(string phrase)
        {
            int countOdd = 0;
            int[] table = new int[(int) (char.GetNumericValue('z') - char.GetNumericValue('a') + 1)];

            foreach (char c in phrase)
            {
                int x = GetCharNumber(c);
                if (x != -1)
                {
                    table[x]++;
                    if (table[x] % 2 == 1)
                    {
                        countOdd++;
                    }
                    else
                    {
                        countOdd--;
                    }
                }
            }

            return countOdd <= 1;
        }

        // Solution #3 palindrome permutatio (bit magic)
        public static bool IsPermutationOfPalindromeBits(string phrase)
        {
            int bitVector = CreateBitVector(phrase);
            return bitVector == 0 || CheckExactlyOneBit(bitVector);
        }

        // Create a bit vector for the string. For each letter with value i, toggle the ith bit
        private static int CreateBitVector(string phrase)
        {
            int bitVector = 0;
            foreach (char c in phrase)
            {
                int x = GetCharNumber(c);
                bitVector = Toggle(bitVector, x);
            }

            return bitVector;
        }

        // Toggle the ith bit in the integer.
        private static int Toggle(int bitVector, int index)
        {
            if (index < 0) return bitVector;

            int mask = 1 << index;
            if ((bitVector & mask) == 0)
            {
                bitVector |= mask;
            }
            else
            {
                bitVector &= ~mask;
            }

            return bitVector;
        }

        // check that exactly one bit is set by subracting one from the integer and
        // and ANDING it with the original interger
        private static bool CheckExactlyOneBit(int bitVector)
        {
            return (bitVector & (bitVector - 1)) == 0;
        }
    }
}
