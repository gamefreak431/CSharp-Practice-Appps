using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Scrabble_Sentence_Score
{
    class WordScore
    {
        private string word;
        private int score;

        public string Word 
        {
            get { return word; }
            set { word = value; }
        }

        public int Score 
        {
            get { return score; }
            set { score = value; }

        }

        public static int Calculator(string word)
        {
            char[] onePoint = { 'e', 'a', 'i', 'o', 'n', 'r', 't', 'l', 's', 'u' };
            char[] twoPoints = { 'd', 'g' };
            char[] threePoints = { 'b', 'c', 'm', 'p' };
            char[] fourPoints = { 'f', 'h', 'v', 'w', 'y' };
            char[] fivePoints = { 'k' };
            char[] eightPoints = { 'j', 'x' };
            char[] tenPoints = { 'q', 'z' };
            string letters = word.ToLower();
            int score = 0;

            foreach (char letter in letters)
            {
                for (int x = 0; x < onePoint.Length; x++)
                {
                    if (letter == onePoint[x])
                    {
                        score++;
                    }
                }

                for (int x = 0; x < twoPoints.Length; x++)
                {
                    if (letter == twoPoints[x])
                    {
                        score += 2;
                    }
                }

                for (int x = 0; x < threePoints.Length; x++)
                {
                    if (letter == threePoints[x])
                    {
                        score += 3;
                    }
                }

                for (int x = 0; x < fourPoints.Length; x++)
                {
                    if (letter == fourPoints[x])
                    {
                        score += 4;
                    }
                }

                for (int x = 0; x < fivePoints.Length; x++)
                {
                    if (letter == fivePoints[x])
                    {
                        score += 5;
                    }
                }

                for (int x = 0; x < eightPoints.Length; x++)
                {
                    if (letter == eightPoints[x])
                    {
                        score += 8;
                    }
                }

                for (int x = 0; x < tenPoints.Length; x++)
                {
                    if (letter == tenPoints[x])
                    {
                        score += 10;
                    }
                }
            }
            return score;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Scrabble Sentence Score is running!");
            Console.WriteLine("Please enter your words with a space between each word.");
            string sentence = Console.ReadLine();
            string[] splitSentence = sentence.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            WordScore[] words = new WordScore[splitSentence.Length];
            int[] scoreBoard = new int[splitSentence.Length];

            for (int x = 0; x < splitSentence.Length; x++) 
            {
                words[x] = new WordScore();
                words[x].Word = splitSentence[x];
                words[x].Score = WordScore.Calculator(words[x].Word);
                scoreBoard[x] = words[x].Score;
            }

            Array.Sort(scoreBoard);
            Array.Reverse(scoreBoard);
            Console.WriteLine("");

            foreach (int num in scoreBoard) 
            {
                for (int x = 0; x < words.Length; x++)
                {
                    if (num == words[x].Score) 
                    {
                        Console.WriteLine(words[x].Word + " - " + num);
                        words[x].Score = 0;
                    }
                }
            }
        }
    }
}
