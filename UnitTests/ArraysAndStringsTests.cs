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
        public void TestCheckPermutations()
        {
            // sort strings and check if permutation
            Assert.True(CheckPermutations.PermutationsSortString("god", "dog"));
            Assert.False(CheckPermutations.PermutationsSortString("abc", "cbd"));

            Assert.True(CheckPermutations.Permutations("god", "dog"));
            Assert.False(CheckPermutations.Permutations("abc", "cbd"));
        }

        [Fact]
        public void TestUrlify()
        {
            // simple testing method
            Assert.Equal("Mr%20John%20Smith", UrLify.Urlify("Mr John Smith    ", 13));

            // method 2 by iterating throug char array
            char[] name = "Mr John Smith    ".ToCharArray();
            UrLify.ReplaceSpaces(name, 13);
            Assert.Equal("Mr%20John%20Smith", name);
        }
    }
}
