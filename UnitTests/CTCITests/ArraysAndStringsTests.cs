using Algorithms.CTCI.Arrays_and_Strings;
using Xunit;

namespace UnitTests.CTCITests
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

        [Fact]
        public void TestPalindromePermutation()
        {
            // solution #1 by checking frequency table
            Assert.True(PalindromePermutation.IsPermutationofPalindrome("Tact Coa"));

            // solution #2 same as #1 just more optimzed
            Assert.True(PalindromePermutation.IsPermutationOfPalindromeOptimized("Tact Coa"));

            // solution #3 using bit arithmetics
            Assert.True(PalindromePermutation.IsPermutationOfPalindromeBits("Tact Coa"));
        }

        [Fact]
        public void TestOneAway()
        {
            // solution #1
            Assert.True(OneAway.OneAwayEdit("pale", "ple"));
            Assert.True(OneAway.OneAwayEdit("pales", "pale"));
            Assert.True(OneAway.OneAwayEdit("pale", "bale"));
            Assert.False(OneAway.OneAwayEdit("pale", "bae"));

            // solution #2
            Assert.True(OneAway.OneAwayEditWhole("pale", "ple"));
            Assert.True(OneAway.OneAwayEditWhole("pales", "pale"));
            Assert.True(OneAway.OneAwayEditWhole("pale", "bale"));
            Assert.False(OneAway.OneAwayEditWhole("pale", "bae"));
        }

        [Fact]
        public void TestStringCompression()
        {
            // solution #1 ineffective string comparison
            Assert.Equal("a2b1c5a3", StringCompression.CompressBad("aabcccccaaa"));

            // solution #2 with string builder
            Assert.Equal("a2b1c5a3", StringCompression.CompressStringBuilder("aabcccccaaa"));

            // solution #3 with added check if compressed string is longer than initial one
            Assert.Equal("a2b1c5a3", StringCompression.Compress("aabcccccaaa"));
        }

        [Fact]
        public void TestStringRotation()
        {
            Assert.True(StringRotation.IsRotation("waterbottle", "erbottlewat"));
            Assert.False(StringRotation.IsRotation("waterbottle", "erbotllewat"));
        }
    }
}
