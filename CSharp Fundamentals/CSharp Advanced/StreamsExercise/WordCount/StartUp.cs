using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            int counter = 0;
            List<string> textList = new List<string>();
            using (var streamReader = new StreamReader("text.txt"))
            {
                string textLine;
                while ((textLine = streamReader.ReadLine()) != null)
                {
                    textList.Add(textLine);
                }
            }
            using (var streamWords = new StreamReader("words.txt"))
            {
                string targetWord;
                while ((targetWord = streamWords.ReadLine()) != null)
                {
                    for (int i = 0; i < textList.Count; i++)
                    {
                        counter = 0;
                        var listWords = textList[i]
                            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                            .ToList();
                        for (int j = 0; j < listWords.Count; j++)
                        {
                            if (listWords[j].Trim(new char[] {'-',',','.' }).ToLower() == targetWord)
                            {
                                if (!dict.ContainsKey(targetWord))
                                {
                                    dict.Add(targetWord, 1);
                                }
                                else
                                {
                                    dict[targetWord] += 1;
                                }
                            }
                        }
                    }
                }
            }
            using (var streamWriter = new StreamWriter("result.txt"))
            {
                foreach (var word in dict.OrderByDescending(x => x.Value))
                {
                    streamWriter.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
