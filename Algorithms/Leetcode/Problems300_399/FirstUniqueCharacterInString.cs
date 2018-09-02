using System.Collections.Generic;

namespace Algorithms.Leetcode.Problems300_399
{
    public class FirstUniqueCharacterInString
    {
        public int FirstUniqChar(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!map.ContainsKey(s[i]))
                    map.Add(s[i], 1);
                else
                {
                    map[s[i]] = 2;
                }
            }

            for (int j = 0; j < s.Length; j++)
            {
                if (map[s[j]] == 1)
                {
                    return j;
                }
            }

            return -1;
        }
    }
}
