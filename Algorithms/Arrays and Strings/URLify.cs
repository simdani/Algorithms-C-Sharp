// question replace all spaces in string wiht %20.

using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Arrays_and_Strings
{
    public class UrLify
    {
        // simple but works
        public static string Urlify(string url, int lenght)
        {
            StringBuilder newUrl = new StringBuilder();
            for (int i = 0; i < lenght; i++)
            {
                if (url[i] == ' ')
                {
                    newUrl.Append("%20");
                }
                else
                {
                    newUrl.Append(url[i]);
                }
            }

            return newUrl.ToString();
        }

        // Solution #2 the proper way
        public static void ReplaceSpaces(char[] str, int trueLengh)
        {
            int spaceCount = 0;
            int index = 0;
            int i = 0;

            for (i = 0; i < trueLengh; i++)
            {
                if (str[i] == ' ')
                {
                    spaceCount++;
                }
            }

            index = trueLengh + spaceCount * 2;
            if (trueLengh < str.Length)
            {
                str[trueLengh] = '\0'; // end array
            }

            for (i = trueLengh - 1; i >= 0; i--)
            {
                if (str[i] == ' ')
                {
                    str[index - 1] = '0';
                    str[index - 2] = '2';
                    str[index - 3] = '%';
                    index = index - 3;
                }
                else
                {
                    str[index - 1] = str[i];
                    index--;
                }
            }
        }
    }
}
