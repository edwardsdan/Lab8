using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab8
{
    class Validate
    {
        public static bool Continue(string x)
        {
            while (true)
            {
                if (!Regex.IsMatch(x, "^(y|Y|n|N)$"))
                {
                    Console.WriteLine("What? Try again! (y/Y/n/N)");
                    x = Console.ReadLine();
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
}
