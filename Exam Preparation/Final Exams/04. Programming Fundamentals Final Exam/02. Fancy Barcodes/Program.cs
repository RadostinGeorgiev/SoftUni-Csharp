using System;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^@#+([A-Z][A-Za-z0-9]{4,}[A-Z])@#+$";
            int rows = int.Parse(Console.ReadLine());

            for (int i = 1; i <= rows; i++)
            {
                string barcode = Console.ReadLine();

                if (Regex.IsMatch(barcode, pattern))
                {
                    string product = Regex.Match(barcode, pattern).Value;

                    string groupCode = string.Empty;
                    for (var j = 0; j < product.Length; j++)
                    {
                        if (char.IsDigit(product[j]))
                        {
                            groupCode += product[j];
                        }
                    }

                    if (groupCode == string.Empty)
                    {
                        groupCode = "00";
                    }
                    Console.WriteLine($"Product group: {groupCode}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
