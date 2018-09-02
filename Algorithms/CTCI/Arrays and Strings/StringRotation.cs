namespace Algorithms.CTCI.Arrays_and_Strings
{
    public static class StringRotation
    {
        public static bool IsRotation(string s1, string s2)
        {
            int len = s1.Length;
            // check that s1 and s2 are equal length and not empty
            if (len == s2.Length && len > 0)
            {
                // concateneate s1 and s1 within new buffer
                string s1s1 = s1 + s1;
                return IsSubstring(s1s1, s2);
            }

            return false;
        }

        private static bool IsSubstring(string s1s2, string s2)
        {
            return s1s2.Contains(s2);
        }
    }

    
}
