using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordLadder.NET
{
    public class WordLadder
    {
        public readonly List<string> Dictionary;
        private readonly List<LinkedList<string>> _paths;

        public WordLadder()
        {
            Dictionary = new List<string>();
            _paths = new List<LinkedList<string>>();

            using (var reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"Resources\dictionary.txt"))
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
            
            // Check if words are the same length
            if (start.Equals(end))
                throw new ArgumentException("Words can't be the same");


            BuildLadders(start, end);
            return _paths.OrderByDescending(x => x.Count).Last();
        }

        private void BuildLadders(string current, string end)
        {
            for (var i = 0; i < end.Length; i++)
            {
                var newString = new StringBuilder(current) {[i] = end[i]}.ToString();
                if (CheckDictionary(newString) && !newString.Equals(current))
                {
                    var path = new LinkedList<string>();
                    path.AddLast(current);
                    path.AddLast(newString);
                    _paths.Add(path);
                }
            }

            // No paths
            if (_paths.Count == 0) 
                return;
            
            BuildLadders(end);
        }

        private void BuildLadders(string end)
        {
            
            foreach (var path in _paths.FindAll(x => x.Last.Value != end))
            {
                var added = false;
                for (var i = 0; i < end.Length; i++)
                {
                    var newString = new StringBuilder(path.Last.Value) {[i] = end[i]}.ToString();
    
                    if (CheckDictionary(newString) && !path.Contains(newString))
                    {
                        added = true;
                        Branch(path, newString);
                    }
                }
                
                if (!added)
                {
                    _paths.Remove(path);
                }
            }

            if (_paths.Count == 0 || _paths.TrueForAll(x => x.Last.Value.Equals(end)))
                return;
            
            BuildLadders(end);


        }

        private bool CheckDictionary(string word)
        {
            return Dictionary.Contains(word);
        }

        private void Branch(LinkedList<string> path, string word)
        {
            var branch = new LinkedList<string>(path);
            branch.AddLast(word);
            _paths.Add(branch);
            _paths.Remove(path);
            
        }
        
       
    }
}