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
            while (true)
            {
                Console.Write("Enter the number of batters: ");
                int NumberBatters = Validate.PositiveInt(Console.ReadLine());
                
                PrintAverages(StoreResults(NumberBatters));

                Console.WriteLine("Another team? (y/Y/n/N)");
                if (Validate.Continue(Console.ReadLine()) == false)
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
            }
        }

        public static int[][] StoreResults(int x)
        {
            int[][] BatterData = new int[x][];
            Console.WriteLine("What were the results? 0=out 1=single 2=double 3=triple 4=homerun");

            for (int r = 0; r < x; r++)
            {
                Console.Write($"Enter the number of at-bats for batter {r+1}: ");
                int Columns = Validate.PositiveInt(Console.ReadLine());
                BatterData[r] = new int[Columns];
                for (int c = 0; c < Columns; c++)
                {
                    Console.Write($"Batter {r+1} result {c+1} for at-bat: ");
                    BatterData[r][c] = Validate.ResultAtBat(Console.ReadLine());
                }
            }
            return BatterData;
        }

        public static void PrintAverages(int[][] AtBats)
        {
            int TotalBases = 0;
            int TotalHits = 0;

            for (int r = 0; r < AtBats.GetLength(0); r++)
            { // .GetLength(x) x = # of dimension of RECTANGULAR array
                for (int c = 0; c < AtBats[r].Length; c++)
                {
                    TotalBases += AtBats[r][c];
                    if (AtBats[r][c] > 0)
                        TotalHits++;
                }
                double Slugging = Math.Round(Convert.ToDouble(TotalBases) / AtBats[r].Length, 3);
                double Batting = Math.Round(Convert.ToDouble(TotalHits) / AtBats[r].Length, 3);
                Console.WriteLine($"Batter {r+1} average: {Batting}\t\tslugging percentage: {Slugging}");
            }
        }
    }
}
