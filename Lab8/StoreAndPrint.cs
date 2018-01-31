using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class StoreAndPrint
    {
        public static int[][] StoreResults(int x)
        {
            int[][] BatterData = new int[x][];

            for (int r = 0; r < x; r++)
            {
                Console.Write($"Enter the number of at-bats for batter {r + 1}: ");
                int Columns = Validate.PositiveInt(Console.ReadLine());
                BatterData[r] = new int[Columns];
                Console.Clear();
                Console.WriteLine("0=out 1=single 2=double 3=triple 4=homerun");

                for (int c = 0; c < Columns; c++)
                {
                    Console.Write($"Batter {r + 1} result {c + 1} for at-bat: ");
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
            { // .GetLength(x) where x = # of the dimension of array

                for (int c = 0; c < AtBats[r].Length; c++)
                {
                    TotalBases += AtBats[r][c];
                    if (AtBats[r][c] > 0)
                        TotalHits++;
                }

                double Slugging = Math.Round(Convert.ToDouble(TotalBases) / AtBats[r].Length, 3);
                double Batting = Math.Round(Convert.ToDouble(TotalHits) / AtBats[r].Length, 3);
                Console.WriteLine($"Batter {r + 1} average: {Batting}\t\tslugging percentage: {Slugging}");
            }
        }
    }
}
