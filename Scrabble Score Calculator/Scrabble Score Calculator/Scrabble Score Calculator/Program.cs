using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Scrabble_Score_Calculator
{
    class Program
    {

        static int Calculator(string word)
        {
            char[] onePoint = { 'e', 'a', 'i', 'o', 'n', 'r', 't', 'l', 's', 'u' };
            char[] twoPoints = { 'd', 'g' };
            char[] threePoints = { 'b', 'c', 'm', 'p' };
            char[] fourPoints = { 'f', 'h', 'v', 'w', 'y' };
            char[] fivePoints = { 'k' };
            char[] eightPoints = { 'j', 'x' };
            char[] tenPoints = { 'q', 'z' };
            char[] letters = word.ToCharArray();
            int score = 0;

            foreach (char letter in letters)
            {
                int points = 0;

                for (int x = 0; x < onePoint.Length; x++)
                {
                    if (letter == onePoint[x])
                    {
                        points++;
                    }
                }

                for (int x = 0; x < twoPoints.Length; x++)
                {
                    if (letter == twoPoints[x])
                    {
                        points += 2;
                    }
                }

                for (int x = 0; x < threePoints.Length; x++)
                {
                    if (letter == threePoints[x])
                    {
                        points += 3;
                    }
                }

                for (int x = 0; x < fourPoints.Length; x++)
                {
                    if (letter == fourPoints[x])
                    {
                        points += 4;
                    }
                }

                for (int x = 0; x < fivePoints.Length; x++)
                {
                    if (letter == fivePoints[x])
                    {
                        points += 5;
                    }
                }

                for (int x = 0; x < eightPoints.Length; x++)
                {
                    if (letter == eightPoints[x])
                    {
                        points += 8;
                    }
                }

                for (int x = 0; x < tenPoints.Length; x++)
                {
                    if (letter == tenPoints[x])
                    {
                        points += 10;
                    }
                }
                score += points;
            }
            return score;
        }


            static void Main(string[] args)
            {
                Console.WriteLine("Scrabble calculator is runnig");
                Console.WriteLine("Please enter a word");
                string word = Console.ReadLine();
                string lowerWord = word.ToLower();

                if (word.Length < 10)
                {
                    int output = Calculator(lowerWord);
                    Console.WriteLine(word + " is worth " + output + " Points");
                }
                else
                {
                    Console.WriteLine("Your word" + " " + word + " " + "is too long");
                    Console.WriteLine("Words must be less than 10 letters long");
                }
            }
    }
}
