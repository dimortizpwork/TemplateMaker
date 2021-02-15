using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMaker.Viewer.Helpers.SmartString
{
    internal static class SmartStringDictonary
    {
        private static string WordsFileName = "words.json";

        public static List<string> Words = new List<string>();

        private static void AddWord(string word, bool allowMultipleUpperCase = false)
        {
            if (!char.IsUpper(word[0]))
                throw new Exception($"Word {word} is out of pattern: does not start with upper case letter");
            
            if (!allowMultipleUpperCase && word.Where(x => char.IsUpper(x)).Count() > 1)
                throw new Exception($"Word {word} is out of pattern: it contains more than one upper case letter");

            if (Words.Where(x => x.Equals(word)).Count() == 0)
                Words.Add(word);
        }

        public static void LoadWords()
        {
            List<Word> words = JsonConvert.DeserializeObject<List<Word>>(File.ReadAllText(WordsFileName));
            foreach (Word word in words)
                AddWord(word.Value, word.AllowMultipleUpperCase);
        }

        public static void SaveWords()
        {
            File.WriteAllText(WordsFileName, JsonConvert.SerializeObject(Words, Formatting.Indented));
        }
        
        public static List<string> GetWords(string input)
        {
            string originalInput = input;
            //Threat the string
            input = input.Replace(" ", "");
            input = input.Replace("_", "");
            input = input.Replace("-", "");

            List<string> foundWords = new List<string>();
            input = input.ToLower();
            for(var i = 0; i<input.Length; i++)
                foreach(string word in Words)
                    if(input.IndexOf(word.ToLower()) == i)
                        foundWords.Add(word);

            var combinations = new Combination().GetCombinations(foundWords);
            foreach(List<string> combination in combinations)
            {
                if(string.Join("", combination.ToArray()).ToLower() == input.ToLower())
                {
                    foundWords = combination;
                }
            }

            if (foundWords.Count == 0 || string.Join("", foundWords.ToArray()).ToLower() != input.ToLower())
                throw new MissingDictonaryEntryException($"Some words was not found for string `{originalInput}`", originalInput);

            return foundWords;
        }


        public static string GetCamelCase(string input)
        {
            return string.Join("", GetWords(input).ToArray());
        }

        public static string GetPascalCase(string input)
        {
            List<string> words = GetWords(input);
            words[0] = words[0].ToLower();
            return string.Join("", words.ToArray());
        }

        public static string GetSnakeCase(string input)
        {
            return string.Join("_", GetWords(input).ToArray());
        }

    }

    public class Combination
    {
        private List<string> List { get; set; }
        private List<List<string>> Combinations;

        public List<List<string>> GetCombinations(List<string> list)
        {
            List = list;
            Combinations = new List<List<string>>();
            GenerateCombination(default(int), new List<string>());
            return Combinations;
        }

        private void GenerateCombination(int position, List<string> previousCombination)
        {
            for (int i = position; i < List.Count(); i++)
            {
                var currentCombination = new List<string>();
                currentCombination.AddRange(previousCombination);
                currentCombination.Add(List.ElementAt(i));
                Combinations.Add(currentCombination);
                GenerateCombination(i + 1, currentCombination);
            }
        }
    }
}
