using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab8
{
    // Come back when I learn about enumeration
    //public class AtBat
    //{
    //    public string Name;
    //    public int Age;
    //    public double GPA;

    //    public Result(string _name, int _age, double _gpa)
    //    {
    //        Name = _name;
    //        Age = _age;
    //        GPA = _gpa;
    //    }
    //}

    public class Validate
    {
        public static bool Continue(string x)
        {
            while (true)
            {
                if (!Regex.IsMatch(x, "^(y|Y|n|N)$"))
                {
                    Console.WriteLine("What? Try again! (y/Y/n/N)");
                }
                else
                {
                    if (x == "y" || x == "Y")
                        return true;
                    else
                        return false;
                }
            }
        }

        public static int PositiveInt(string x)
        {
            while (true)
            {
                if (int.Parse(x) > 0)
                    return int.Parse(x);
                else
                {
                    Console.WriteLine("Not a valid input. Try again...");
                    x = Console.ReadLine();
                }
            }
        }

        public static int ResultAtBat(string x)
        {
            while (true)
            {
                if (!Regex.IsMatch(x, "^(0|1|2|3|4)$"))
                {
                    Console.WriteLine("Not a valid input. Try again... 0=out 1=single 2=double 3=triple 4=homerun");
                    x = Console.ReadLine();
                }
                else
                    break;
            }
            return int.Parse(x);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // # base/atbats -> slugging %
            // # hits / atbats -> batting average
            while (true)
            {
                Console.Write("Enter the number of batters: ");
                int NumberBatters = Validate.PositiveInt(Console.ReadLine());
                Console.Write("Enter the number of times at bat: ");
                int NumberAtBats = Validate.PositiveInt(Console.ReadLine());

                PrintAverages(StoreResults(NumberBatters, NumberAtBats));

                Console.WriteLine("Another batter? (y/Y/n/N)");
                if (Validate.Continue(Console.ReadLine()) == false)
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
            }
        }

        public static int[,] StoreResults(int x, int y)
        {
            int[,] NumberAtBats = new int[x, y];
            Console.WriteLine("What were the results? 0=out 1=single 2=double 3=triple 4=homerun");

            for (int r = 0; r < x; r++)
            {
                for (int c = 0; c < y; c++)
                {
                    Console.Write("Result for at-bat: ");
                    NumberAtBats[r, c] = Validate.ResultAtBat(Console.ReadLine());
                }
            }
            return NumberAtBats;
        }

        public static void PrintAverages(int[,] AtBats)
        {
            int TotalBases = 0;
            int TotalHits = 0;

            for (int r = 0; r < AtBats.GetLength(0); r++)
            { // .GetLength(x) x = # of dimension of array
                for (int c = 0; c < AtBats.GetLength(1); c++)
                {
                    TotalBases += AtBats[r,c];
                    if (AtBats[r,c] > 0)
                        TotalHits++;
                }
            }
            double Slugging = Math.Round(Convert.ToDouble(TotalBases) / AtBats.Length, 3);
            Console.WriteLine(Slugging);
            double Batting = Math.Round(Convert.ToDouble(TotalHits) / AtBats.Length, 3);
            Console.WriteLine(Batting);
        }
    }
}
