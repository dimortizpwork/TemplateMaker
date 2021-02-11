using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMaker.Viewer.Helpers.SmartString
{
    internal static class SmartStringDictonary
    {
        public static List<string> Words = new List<string>();

        public static void LoadWords()
        {
            Words.Add("Van");
            Words.Add("Order");
            Words.Add("Id");
            Words.Add("Invoice");
            Words.Add("Reminder");
            Words.Add("Cache");
            Words.Add("Cpr");
            Words.Add("Cpc");
            Words.Add("Line");
            Words.Add("Item");
            Words.Add("Product");
            Words.Add("Evaluation");
            Words.Add("Solution");
            Words.Add("Quotation");
            Words.Add("Price");
            Words.Add("Date");
            Words.Add("Time");
            Words.Add("Value");
            Words.Add("Supplier");
            Words.Add("Shipment");
            Words.Add("Return");
            Words.Add("Customer");
            Words.Add("User");
            Words.OrderBy(x => x);
        }
        
        public static List<string> GetWords(string input)
        {
            //Treat the string
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
                throw new Exception($"Some workds was not found for string {input}");

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
