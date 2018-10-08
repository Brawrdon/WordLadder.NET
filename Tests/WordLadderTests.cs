using System;
using System.Collections.Generic;
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
            var list = wordLadder.FindShortestPath("dot", "cog");

            foreach (var element in list)
            {
               Console.WriteLine(element);
            }
        }
        
        [Fact]
        public void LoadDictionary_Default()
        {
            var wordLadder = new WordLadder.NET.WordLadder();
            Assert.Equal(370099, wordLadder.Dictionary.Count);
        }
    }
}