using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace _2Kurs_lab2
{
    class Program : Task_
    {
        static void Main(string[] args)
        {
            if (Console.BackgroundColor == ConsoleColor.Black)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
            }
            Task_ t = new Task_();
            //t.Task_1();
            // t.Task_1_2();
            // t.Task_2_1();
            //t.Task_2_2();
            //t.Task_3();
            GasComp gasComp = new GasComp();
            gasComp.Fu();
        }
    }

    class Task_ : GasComp
    {
        private const int size = 5;
        public void Task_1_1()
        {
            int[] arr = new int[size];
            for (int i = 0; i < arr.Length; i++)
            {

                Console.WriteLine(string.Format("Enter {0} elemebnt:", i + 1));
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            int sum = 0;
            for (int i = 0; i < arr.Length; ++i)
            {
                if (arr[i] % 2 != 0)
                    sum += arr[i];
            }
            Console.WriteLine("Sum  %2:" + sum);

            int index1 = Array.FindLastIndex(arr, x => x < 0);
            Console.WriteLine("index last :" + index1);
            int index2 = Array.FindIndex(arr, x => x < 0);
            Console.WriteLine("index first :" + index2);
            int count = index2 - index1;
            count *= -1;
            Console.WriteLine("COunt " + count);
            var mySegmentsArray = new ArraySegment<int>(arr, index2, count);
            int s = 0;
            s -= arr[index2];
            var list = (IList<int>)mySegmentsArray;
            for (int ctr = 0; ctr <= list.Count - 1; ctr++)
            {
                s += list[ctr];
                Console.WriteLine(list[ctr]);
            }
            Console.WriteLine("sum ;;;;;" + s);
        }

        public void Task_1_2()
        {
            int i, k;
            int Min = 0;
            int Max = 20;
            int[] arr = new int[size];
            Random random = new Random();
            for (i = 0; i < arr.Length; i++)
            {

                arr[i] = random.Next(Min, Max);
            }
            for (i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Array :" + arr[i]);
            }
            Console.WriteLine("Enter M , M<N :");
            k = Convert.ToInt32(Console.ReadLine());
            if (k > 0 && k < size)
            {
                while (k != 0)
                {
                    i = size - 1;
                    int temp = arr[0];
                    for (i = 0; i < size - 1; i++)
                        arr[i] = arr[i + 1];
                    arr[size - 1] = temp;
                    k--;
                }
                Console.WriteLine("====================");
                for (i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine("Array " + arr[i]);
                }

            }
        }

        public void Task_2_1()
        {
            int column = 0, row = 0;
            Console.WriteLine("Enter number of rows : " + row);
            row = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter number of columns : " + column);
            column = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = new int[row,column];
            sumRows(matrix, row, column);


        }
        void sumRows(int[,] tempMatrix, int row, int column)
        {
            int Min = -5;
            int Max = 20;
            Random random = new Random();
            for (int i = 0; i < row; ++i)
            {
                for (int j = 0; j < column; ++j)
                {
                    tempMatrix[i,j] = random.Next(Min, Max);
                }

            }
            for (int i = 0; i < row; ++i)
            {
                for (int j = 0; j < column; ++j)
                {

                    Console.WriteLine("Array : " + tempMatrix[i,j]+"\n");

                }
            }
            for (int i = 0; i < column; ++i)
            {
                int sum = 0;
                int checkPositivity = 1;
                for (int j = 0; j < row; ++j)
                {
                    sum += tempMatrix[i,j];
                    if (tempMatrix[i,j] < 0)
                        checkPositivity = 0;
                }
                if (checkPositivity == 1)
                    Console.WriteLine("Sum : " + sum); 
            }


        }
        public void Task_2_2()
        {
            int Min = -5;
            int Max = 20;
            Random random = new Random();
            const int n = 6;
            int i, j, maxsum = 0;
            int[,] a = new int[n, n];
            int[] s = new int[2 * n];
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    a[i, j] = random.Next(Min, Max);
                }

            }
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.WriteLine("Array : "+a[i,j] +"\n");
                }
            }
            for (j = 0; j < (2 * n); j++)
            {
                s[j] = 0;
            }
            for (i = 0; i < n; i++)
            {
                for (j = 0; j + i < n; j++)
                {
                    s[j] += a[i,i + j];
                    s[n + j] += a[i + j,i];
                }
            }
            for (j = 0; j < n; j++)
            {
                Console.WriteLine("S:"+s[j]);
            }
            for (j = n + 1; j < (2 * n); j++)
            {
                Console.WriteLine("s[j]"+s[j]);
            }
            maxsum = -1000;
            for (j = 1; j < n; j++)
            {
                if (maxsum < s[j])
                {
                    maxsum = s[j];
                }
            }
            Console.WriteLine("Max sum :" + maxsum);

        }

        public void Task_3()
        {
           
            string str = "AaEeIiYyOoUu";
            String text = "TExt          teeeeeet eaaaar e te tet et";
            text = text.Trim(new char[] { ',', '.' });
            string[] textArray = text.Split(new char[] {' ' });
            Console.WriteLine("Words num:" + textArray.Length);

            int cntWords = textArray.Length;
            int[] counters = new int[cntWords];
            for (int i = 0; i < cntWords; ++i)
            {
                for (int j = 0; j < textArray[i].Length; ++j)
                    if (str.IndexOf(textArray[i][j]) != -1)
                        counters[i]++;
            }
            int maxB = counters[0];
            for (int i = 1; i < cntWords; ++i)
                if (counters[i] > maxB)
                    maxB = counters[i];
            Console.WriteLine("Word with the most vowels is : ");
            for (int i = 0; i < cntWords; ++i)
                if (counters[i] == maxB)
                    Console.WriteLine(textArray[i]);

            while (text.Contains("  ")) 
                text = text.Replace("  ", " "); 

            Console.WriteLine("Without spacies: " + text);


        }
      

    }
    class GasComp : Flat
    {
        Flat flat = new Flat();
        public void Fu()
        {
            
            flat.Funcc();
        }
        public void Service()
        {
            Console.WriteLine("Next service will  be 20 10 2020");
            Console.WriteLine("If have a problem with gas press Enter numberflat");
            string numb = Console.ReadLine();
            for(int i=0;i<b.Length;i++)
            {
                if (b[i].Item4 == numb)
                {
                    Console.WriteLine("This weak we will fix your problem ");
                }
                else Console.WriteLine("Your flat not exist");

            }


        }




    }
    class Flat
    {
       
        private string number_flat ;
        private double count_gas;
        private int count_people;
        private bool counter;
        private string name_owner;
        private int Count_number;
        private decimal price;
        public Flat(string name_owner="Vasyan", int Count_number=3434, decimal price=22,string number_flat = "124A", double count_gas = 30, int count_people = 2, bool counter = true) 
        {
            this.number_flat = number_flat;
            this.count_gas = count_gas;
            this.count_people = count_people;
            this.counter = counter;
            this.name_owner = name_owner;
            this.Count_number = Count_number;
            this.price = price;
        }
       string Get_number_flat()
        {
            return this.number_flat;

        }
       public Tuple<string, int, double, string, double, int, int>[] b;
        
        public void Funcc()
        {
            Console.WriteLine("Enter count of new flat");
            int f = Convert.ToInt32(Console.ReadLine());
         
         
            Console.WriteLine("========================");
            Console.WriteLine("Enter name owner ");
            string name_owner = Console.ReadLine();
            Console.WriteLine("Enter number of counter");
            int Count_number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter price");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter number flat");
            string number_flat = Console.ReadLine();
            Console.WriteLine("Enter count gas");
            double count_gas = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter count people");
            int count_people = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter 1 if you have the counter. \n Enter 2 if you don't have the counter");
            int counter = Convert.ToInt32(Console.ReadLine());
            double pricc=0;
            if (counter == 1)
            {
                pricc = count_gas;
            }
            else if (counter == 2)
            {
                pricc = count_people + (count_gas / 2);
            }
            else Console.WriteLine("You should enter trueth info about counter");
            // Tuple<string, int, decimal, string, double, int, bool> tuple = new Tuple<string, int, decimal, string, double, int, bool>(name_owner, Count_number, price, number_flat, count_gas, count_people, counter);
            var list = new List<Tuple<string, int, double, string, double, int, int>>();

            list.Add(Tuple.Create(name_owner, Count_number, price*pricc, number_flat, count_gas, count_people, counter));
           

            b = list.ToArray();



            void print_flat()
            {
                for (int i = 0; i < b.Length; i++)
                {
                    Console.WriteLine("EE :" + b[i] + "\n");
                }
            }
           
           
        }
       


    }
    //class Owner: Flat
    //{
    //  private int id; 
    //  private string name;
    //  private int Count_number;
    //  private decimal price;

     
    //    public Owner(string name, int Count_number , decimal price,string number_flat,double count_gas,int count_people, bool counter):base(number_flat, count_gas, count_people, counter)
    //    {
    //        this.name = name;
    //        this.Count_number = Count_number;
    //        this.price = price;
    //    }



    //}


}
