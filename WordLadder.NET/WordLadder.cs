using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WordLadder.NET
{
    public class WordLadder
    {
        public readonly List<string> Dictionary;
        private List<LinkedList<string>> _paths;
        
        public WordLadder()
        {
            Dictionary = new List<string>();
            _paths = new List<LinkedList<string>>();

            using (var reader = new StreamReader(System.AppDomain.CurrentDomain.BaseDirectory + @"Resources\dictionary.txt"))
            {
                while (!reader.EndOfStream)
                {
                    Dictionary.Add(reader.ReadLine());
                }
            }
        }

        public WordLadder(string path)
        {
            Dictionary = new List<string>();
            _paths = new List<LinkedList<string>>();

            try
            {
                using (var reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        Dictionary.Add(reader.ReadLine());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

         }


        public LinkedList<string> FindShortestPath(string start, string end)
        {
            // Check if words are in the dictionary
            if (!Dictionary.Contains(start))
                throw new ArgumentException(string.Format("{0} is not in the dictionary", start), nameof(start));
            
            if (!Dictionary.Contains(end))
                throw new ArgumentException(string.Format("{0} is not in the dictionary", end), nameof(end));
            
            // Check if words are the same length
            if (start.Length != end.Length) 
                throw new ArgumentException("The start and end word must be the same length");

            return SwitchLetter(start, end);
        }

        private LinkedList<string> SwitchLetter(string current, string end)
        {

            
            if (_paths.Count == 0)
            {
                for (var i = 0; i < current.Length; i++)
                {
                    var newString = new StringBuilder(current) {[i] = end[i]}.ToString();
                    if (CheckDictionary(newString))
                    {
                        var path = new LinkedList<string>();
                        path.AddLast(current);
                        path.AddLast(newString);
                        _paths.Add(path);
                    }

                }
            }
            return null;

        }

        private bool CheckDictionary(string word)
        {
            return Dictionary.Contains(word);
        }
        
    }
}