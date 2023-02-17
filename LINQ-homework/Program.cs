using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = CreateList();
            Console.WriteLine("請選擇1到4查看各頁資料");
            string page = "";

            do
            {
                page = Console.ReadLine();
                if (page == "1")
                {
                    var totalOfprice = products.Sum((x) => x.price);
                    Console.WriteLine($"1.所有商品的總價格:{totalOfprice}");
                    var average = products.Average((x) => x.price);
                    Console.WriteLine($"2.所有商品價格的平均:{average:N}");
                    var totalOfproducts = products.Sum(x => x.quantity);
                    Console.WriteLine($"3.商品的總數量:{totalOfproducts}");
                    var averageOfproducts = products.Average((x) => x.quantity);
                    Console.WriteLine($"4.商品的平均數量:{averageOfproducts:0}");

                }

                else if (page == "2")
                {
                    var max = products.Max((x) => x.price);
                    var maxOfproducts = products.SingleOrDefault(x => x.price == max);
                    Console.WriteLine($"5.最貴的商品:{maxOfproducts.Name}");
                    var min = products.Min((x) => x.price);
                    var minOfproducts = products.SingleOrDefault(x => x.price == min);
                    Console.WriteLine($"6.最便宜的商品:{minOfproducts.Name}");
                    var totalOf3C = products.GroupBy((x) => x.category);
                    foreach (var item in totalOf3C)
                    {
                        if (item.Key == "3C")
                        {
                            var totalpriceOf3C = item.Sum((x) => x.price);
                            Console.WriteLine($"7.商品類別為3C的總價:{totalpriceOf3C}");
                        }
                    }
                    var totalOfdrink = products.GroupBy((x) => x.category);
                    foreach (var item in totalOfdrink)
                    {
                        if (item.Key == "飲料")
                        {
                            var totalpriceOfdrink = item.Sum((x) => x.price);
                            Console.WriteLine($"8.商品類別為飲料的總價:{totalpriceOfdrink}");
                        }
                    }

                }



                else if (page == "3")
                {
                    var totalOfeat = products.GroupBy((x) => x.category);
                    foreach (var item in totalOfeat)
                    {
                        if (item.Key == "食品")
                        {
                            var totalpriceOfeat = item.Sum((x) => x.price);
                            Console.WriteLine($"9.商品類別為食品的總價:{totalpriceOfeat}");
                            Console.WriteLine("10.商品類別為食品且數量超過100:");
                            foreach (var eat in item)
                            {
                                if (eat.quantity > 100)
                                {
                                    Console.WriteLine(eat.Name);
                                }
                            }
                        }
                    }

                    var allOfpricemore1000 = products.GroupBy((x) => x.category);
                    foreach (var item in allOfpricemore1000)
                    {
                        Console.WriteLine($"11.商品為{item.Key}且價格大於1000:");
                        foreach (var pricemore1000 in item)
                        {
                            if (pricemore1000.price > 1000)
                            {
                                Console.WriteLine(pricemore1000.Name);
                            }
                        }
                    }

                    var allOfpriceAverage = products.GroupBy((x) => x.category);
                    foreach (var item in allOfpriceAverage)
                    {
                        Console.WriteLine($"12.商品:{item.Key}");
                        var priceAverage = item.Average((x) => x.price);
                        Console.WriteLine($"平均價格為{priceAverage:0}");
                    }

                }


                else if (page == "4")
                {
                    var order1 = products.OrderBy((x) => x.Name).ThenBy((x) => x.price);
                    Console.WriteLine("13.商品價格由大到小:");
                    Display(order1);

                    var order2 = products.OrderByDescending((x) => x.Name).ThenByDescending((x) => x.quantity);
                    Console.WriteLine("14.商品數量由小到大:");
                    Display(order1);

                    var allproductOfmax = products.GroupBy((x) => x.category);
                    foreach (var item in allproductOfmax)
                    {
                        Console.WriteLine($"15.商品類別{item.Key}最貴為:");
                        var productOfmax = item.Max((x) => x.price);
                        foreach (var bbb in item)
                        {
                            if (bbb.price == productOfmax)
                            {
                                Console.WriteLine(bbb.Name);
                            }
                        }
                    }

                    Console.WriteLine("16.商品價格超過10000的有:");
                    foreach (var item in products)
                    {
                        if (item.price > 10000)
                        {
                            Console.WriteLine(item.Name);
                        }
                    }

                }

                else
                {
                    Console.WriteLine("請選擇正確的頁碼");

                }
            } while (page == "1" || page == "2" || page == "3" || page == "4");
            {
                Console.WriteLine("已離開查閱的資料");
            }
        }
        static void Display(IOrderedEnumerable<Product> source)
        {
            foreach (var item in source)
            {
                Console.WriteLine(item.Name);
            }
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
