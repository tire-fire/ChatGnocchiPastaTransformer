using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ChatGnocchiPastaTransformer
{
    public class MarkovChainBot
    {
        private Dictionary<string, List<string>> markovChain = new Dictionary<string, List<string>>();

        public void Train(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var words = line.ToLower().Split(' '); // Simple tokenization
                for (int i = 0; i < words.Length - 1; i++)
                {
                    if (!markovChain.ContainsKey(words[i]))
                    {
                        markovChain[words[i]] = new List<string>();
                    }
                    markovChain[words[i]].Add(words[i + 1]);
                }
            }
        }

        public string GetRandomWord()
        {
            if (markovChain.Count == 0)
            {
                throw new InvalidOperationException("Markov chain is empty.");
            }

            // Select a random key (word)
            Random rand = new Random();
            var keys = markovChain.Keys.ToList();
            string randomKey = keys[rand.Next(keys.Count)];

            // Select a random word from the list associated with the key
            List<string> words = markovChain[randomKey];
            if (words.Count == 0)
            {
                throw new InvalidOperationException("Word list is empty for the selected key.");
            }

            string randomWord = words[rand.Next(words.Count)];
            return randomWord;
        }

        public string GenerateResponse(string input)
        {
            Random rand = new Random();
            string[] inputWords = input.Split(' ');
            string currentWord = inputWords[rand.Next(inputWords.Length)];
            string response = currentWord;

            if (!markovChain.ContainsKey(currentWord))
            {
                currentWord = GetRandomWord();
            }
            int responseLength = rand.Next(4, 40);

            for (int i = 0; i < responseLength; i++)
            {
                if (!markovChain.ContainsKey(currentWord)) break;
                if (currentWord.Contains(".")) break;
                var nextWords = markovChain[currentWord];
                currentWord = nextWords[rand.Next(nextWords.Count)];
                response += " " + currentWord;
            }
            return response;
        }
    }
}