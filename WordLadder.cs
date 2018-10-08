using System;
using System.Collections.Generic;
using System.IO;

namespace WordLadder.NET
{
    public class WordLadder
    {
        public readonly List<string> Dictionary;
        
        public WordLadder()
        {
            Dictionary = new List<string>();
            using (var reader = new StreamReader(@"Resources\dictionary.txt"))
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
    }
}