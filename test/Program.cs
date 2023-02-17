using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = CreateList();
            var total = products.Sum((x) => x.price);
            Console.WriteLine($"所有商品的總價格:{total}");








        }
        static List<Product> CreateList()
        {
            string csvFilePath = @"product.csv";
            using (var reader = new StreamReader(csvFilePath))
            {
                // Skip the first line (header)
                reader.ReadLine();
                var list = new List<Product>();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');
                    var good = new Product();
                    


                    good.Id = values[0];
                    good.Name = values[1];
                    good.quantity = int.Parse(values[2]);
                    good.price = int.Parse(values[3]);
                    good.category = values[4];
                    list.Add(good);

                }

                return list;

            }
            
            
        }
    } 
}
