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
            //var a = new StreamReader(File.OpenRead(@"product.csv"));
            //Console.WriteLine(a.ReadToEnd());
            string path = @"product.csv";

            //建立一個二維字串陣列來儲存 CSV 檔案中的資料
            List<string[]> data = new List<string[]>();

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    // 一行一行讀取 CSV 檔案
                    while (sr.Peek() >= 0)
                    {
                        string line = sr.ReadLine();

                        // 使用逗號分隔符號，將每行資料分割成一個字串陣列
                        string[] values = line.Split(',');

                        // 將分割後的資料加入到二維字串陣列中
                        data.Add(values);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            // 顯示每個資料項目
            foreach (string[] row in data)
            {
                // 顯示該資料項目的每個欄位
                foreach (string value in row)
                {
                    Console.Write(value + " ");
                }
                Console.WriteLine();
            }
        }
        //static List<Product> CreateList()
        //{
        //    return new List<Product>()
        //    {
                
        //    };
        //}
    }
}
