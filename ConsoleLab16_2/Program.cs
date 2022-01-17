using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;

namespace ConsoleLab16_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity_line = 0;
            string path = @"Test\Test.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.ReadLine() != null)
                {
                    quantity_line++;
                }
            }
            string[] newProductList = new string[quantity_line];
            using (StreamReader sr = new StreamReader(path))
            {
                for (int i = 0; i < quantity_line; i++)
                {
                    newProductList[i] = sr.ReadLine();
                }
            }
            int p = 0;
            double pr = 0;
            int t = 0;
            Product[] newProduct = new Product[quantity_line];
            foreach (string s in newProductList)
            {
                newProduct[p] = JsonSerializer.Deserialize<Product>(newProductList[p]);
                newProduct[p].ProductList();
                if (newProduct[p].ProductPrice > pr)
                {
                    pr = newProduct[p].ProductPrice;
                    t = p;
                }
                p++;
            }
            Console.WriteLine();
            Console.WriteLine("Самый дорогой товар - {0}, его стоимость - {1}", newProduct[t].ProductName, newProduct[t].ProductPrice);
            Console.WriteLine();
            Console.WriteLine("Для завершения нажмите любую клавишу");
            Console.ReadKey();
        }
    }

    class Product
    {
        int productCode;
        string productName;
        double productPrice;
        public int ProductCode
        {
            get
            {
                return productCode;
            }
            set
            {
                productCode = value;
            }
        }
        public string ProductName
        {
            get
            {
                return productName;
            }
            set
            {
                productName = value;
            }
        }
        public double ProductPrice
        {
            get
            {
                return productPrice;
            }
            set
            {
                productPrice = value;
            }
        }

        public void ProductList()
        {
            Console.WriteLine("Код продукта - \t\t{0}\nНаименование продукта - {1}\nСтоимость продукта - \t{2}", productCode, productName, productPrice);
        }
    }
}
