using System;
using Algorithms.Arrays_and_Strings;
using Xunit;

namespace UnitTests
{
    public class ArraysAndStringsTests
    {
        [Fact]
        public void TestIfStringIsUnique()
        {
            // chech if string is unique
            Assert.True(UniqueString.IsUniqueChars("abcdfghjkl"));
            Assert.False(UniqueString.IsUniqueChars("aabvbcvbcvb"));

            // check is string is unique (using lowercase)
            Assert.True(UniqueString.IsUniqueCharsLowerCase("agdwetyf"));
            Assert.False(UniqueString.IsUniqueCharsLowerCase("aasdfsdfsdfsdfsd"));

            // compare to one another
            Assert.True(UniqueString.CompareEveryCharacter("agdwetyf"));
            Assert.False(UniqueString.CompareEveryCharacter("asdfsdfsdfsdfsda"));
        }

        [Fact]
        public void CheckPermutations()
        {

        }
    }
}
