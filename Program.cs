using ExercPriceTag.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercPriceTag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());
            List<Product> lstProd = new List<Product>();

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Product #{i} data:");
                Console.Write("Common, used or imported (c/u/i)? ");
                char prdType = Char.Parse(Console.ReadLine().ToLower());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                switch (prdType)
                {
                    case 'i':
                        Console.Write("Customs fee: ");
                        double custfee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        lstProd.Add(new ImportedProduct(name, price, custfee));
                        break;
                    case 'u':
                        Console.Write("Manufacture Date (dd/mm/yyyy): ");
                        DateTime manufacDt = DateTime.Parse(Console.ReadLine());
                        lstProd.Add(new UsedProduct(name, price, manufacDt));
                        break;
                    default:
                        lstProd.Add(new Product(name, price));
                        break;
                }
            }
            Console.WriteLine();
            Console.WriteLine("PRICE TAGS: ");
            foreach (Product product in lstProd)
            {
                Console.WriteLine(product.PriceTag());
            }

            Console.ReadLine();
        }
    }
}
