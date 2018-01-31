using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab8
{
    //public enum Result { OUT, SINGLE, DOUBLE, TRIPLE, HOMERUN };

    ////Come back when I learn about enumeration
    //public class AtBat
    //{
    //    public Result Result { get; set; }
    //    {
    //        _result = Result;
    //    } 

    //    public static int BasesEarned()
    //    {
    //        return 3;
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter the number of batters: ");
                int NumberBatters = Validate.PositiveInt(Console.ReadLine());
                
                StoreAndPrint.PrintAverages(StoreAndPrint.StoreResults(NumberBatters));

                Console.WriteLine("Another team? (y/Y/n/N)");
                if (Validate.Continue(Console.ReadLine()) == false)
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
            }
        }
    }
}
