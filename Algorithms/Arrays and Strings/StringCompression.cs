// questoin: implement a method to perform basic string compression
// string aabccccaaa would become a2b1c5a3

using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Arrays_and_Strings
{
    public static class StringCompression
    {
        // Solution #1 slow (it takes O(p + k^2) because string concatenation is slow at O(n^2)
        public static string CompressBad(string str)
        {
            string compressedString = "";
            int countConsecutive = 0;
            for (int i = 0; i < str.Length; i++)
            {
                countConsecutive++;
                // if next character is different than current, append this char to result
                if (i + 1 >= str.Length || str[i] != str[i + 1])
                {
                    compressedString += "" + str[i] + countConsecutive;
                    countConsecutive = 0;
                }
            }

            return compressedString.Length < str.Length ? compressedString : str;
        }

        // Solution #2 fix first solution with string builder
        public static string CompressStringBuilder(string str)
        {
            StringBuilder compressed = new StringBuilder();
            int countConsecutive = 0;

            for (int i = 0; i < str.Length; i++)
            {
                countConsecutive++;

                if (i + 1 >= str.Length || str[i + 1] != str[i])
                {
                    compressed.Append(str[i]);
                    compressed.Append(countConsecutive);
                    countConsecutive = 0;
                }
            }

            return compressed.Length < str.Length ? compressed.ToString() : str;
        }

        // Solution #3 optimize when we dont have a large number of repeating characters
        public static string Compress(string str)
        {
            // check final length and return input string if it would be longer.
            int finalLength = CountCompression(str);
            if (finalLength >= str.Length)
            {
                return str;
            }

            StringBuilder compressed = new StringBuilder(finalLength);
            int countConsecutive = 0;
            for (int i = 0; i < str.Length; i++)
            {
                countConsecutive++;
                if (i + 1 >= str.Length || str[i] != str[i + 1])
                {
                    compressed.Append(str[i]);
                    compressed.Append(countConsecutive);
                    countConsecutive = 0;
                }
            }

            return compressed.ToString();
        }

        private static int CountCompression(string str)
        {
            int compressedLength = 0;
            int countConsecutive = 0;
            for (int i = 0; i < str.Length; i++)
            {
                countConsecutive++;
                if (i + 1 >= str.Length || str[i] != str[i + 1])
                {
                    compressedLength += 1 + Convert.ToString(countConsecutive).Length;
                    countConsecutive = 0;
                }
            }

            return compressedLength;
        }
    }
}
