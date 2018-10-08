using System;
using System.Globalization;
using Xunit;

namespace Tests
{
    public class WordLadderTests
    {
        
        [Fact]
        public void Main()
        {
            var wordLadder = new WordLadder.NET.WordLadder();
            wordLadder.FindShortestPath("cat", "dog");
        }
        
        [Fact]
        public void LoadDictionary_Default()
        {
            var wordLadder = new WordLadder.NET.WordLadder();
            Assert.Equal(370099, wordLadder.Dictionary.Count);
        }
    }
}