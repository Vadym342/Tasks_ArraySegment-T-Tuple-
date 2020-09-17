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



            MainMenu();


        }
        public static void MainMenu()
        {
            Task_ t = new Task_();
            GasComp gasComp = new GasComp();
            Console.Clear();
            int i = 0;
            do
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Task 1.1");
                Console.WriteLine("2. Task 1.2");
                Console.WriteLine("3. Task 2.1");
                Console.WriteLine("4. Task 2.2");
                Console.WriteLine("5. Task 3");
                Console.WriteLine("6. Task 4");
                Console.WriteLine("7. Exit");
                Console.Write("\r\nSelect an option: ");
                switch (Console.ReadLine())
                {

                    case "1":
                        t.Task_1_1();
                        break;
                    case "2":
                        t.Task_1_2();
                        break;
                    case "3":
                        t.Task_2_1();
                        break;
                    case "4":
                        t.Task_2_2();
                        break;
                    case "5":
                        t.Task_3();
                        break;
                    case "6":

                        gasComp.Fu();

                        break;
                    case "7":
                        i = 1;
                        break;
                    default:
                        Console.WriteLine("Error, wrong menu position! TRY AGAIN");
                        break;



                }


            } while (i != 1);

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
            Console.WriteLine("Count " + count);
            var mySegmentsArray = new ArraySegment<int>(arr, index2, count);
            int s = 0;
            s -= arr[index2];
            var list = (IList<int>)mySegmentsArray;
            for (int ctr = 0; ctr <= list.Count - 1; ctr++)
            {
                s += list[ctr];
                Console.WriteLine(list[ctr]);
            }
            Console.WriteLine("Sum :" + s);
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
            int[,] matrix = new int[row, column];
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
                    tempMatrix[i, j] = random.Next(Min, Max);
                }

            }
            for (int i = 0; i < row; ++i)
            {
                for (int j = 0; j < column; ++j)
                {

                    Console.WriteLine("Array : " + tempMatrix[i, j] + "\n");

                }
            }
            for (int i = 0; i < column; ++i)
            {
                int sum = 0;
                int checkPositivity = 1;
                for (int j = 0; j < row; ++j)
                {
                    sum += tempMatrix[i, j];
                    if (tempMatrix[i, j] < 0)
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
                    Console.WriteLine("Array : " + a[i, j] + "\n");
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
                    s[j] += a[i, i + j];
                    s[n + j] += a[i + j, i];
                }
            }
            for (j = 0; j < n; j++)
            {
                Console.WriteLine("S:" + s[j]);
            }
            for (j = n + 1; j < (2 * n); j++)
            {
                Console.WriteLine("s[j]" + s[j]);
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
            string[] textArray = text.Split(new char[] { ' ' });
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
            flat.Features_flat();
            Service();
        }
        public void Service()
        {
            


        }
    }
    class Flat
    {

        private string number_flat;
        private double count_gas;
        private int count_people;
        private bool counter;
        private string name_owner;
        private int Count_number;
        private decimal price;
        public Flat(string name_owner = "Vasyan", int Count_number = 3434, decimal price = 22, string number_flat = "124A", double count_gas = 30, int count_people = 2, bool counter = true)
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

        public void Features_flat ()
        {
            Console.WriteLine("Enter position menu");
            Console.WriteLine("1.Add flat");
            Console.WriteLine("2.Exit");
            int m = Convert.ToInt32(Console.ReadLine());
            switch (m)
            {

                case 1:
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
                        double pricc = 0;
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
                        for (int i = 0; i < f; i++)
                        {
                            list.Add(Tuple.Create(name_owner, Count_number, price * pricc, number_flat, count_gas, count_people, counter));
                            b = list.ToArray();
                           
                        }

                      

                        Console.WriteLine("Print flat:");
                        for (int i = 0; i < b.Length; i++)
                        {
                            Console.WriteLine("Flat :" + b[i] + "\n");
                        }
                        Console.WriteLine("Next service will  be 20 10 2020");
                        Console.WriteLine("Enter position menu");
                        Console.WriteLine("1.If have a problem with gas");
                        Console.WriteLine("2.Exit");
                        int menu = Convert.ToInt32(Console.ReadLine());

                        switch (menu)
                        {
                            case 1:
                                {
                                    Console.WriteLine("Enter numberflat");
                                    string numb = Console.ReadLine();
                                    for (int i = 0; i < b.Length; i++)
                                    {
                                        if (b[i].Item4 == numb)
                                        {
                                            Console.WriteLine("This weak we will fix your problem ");
                                            Console.WriteLine("Check");
                                            Console.WriteLine("Your flat :" + b[i].Item4);
                                            Console.WriteLine("Name employee : JAMS");
                                            Console.WriteLine("Price :333");

                                        }
                                        else Console.WriteLine("Your flat not exist");


                                    }
                                }
                                break;

                            case 2:
                                break;
                            default:
                                Console.WriteLine("Wring position menu");
                                break;
                        }
                    }
                    break;
                case 2:
                    break;
                
            }
        }
    }   
}

        
    

    
   



