/**
 * Akhond sarah Mesbah 041009466
 * Lab1
 * */

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Exercise
    {
        static void Main(string[] args)
        {
            IList<string> words = new List<string>();// using generic list type of IList<string>
            string option;
            bool a = true;

            while (a) // for the menu function to come again
            {
                System.Console.Write("Options:\n1 - Import Words From File" +
                       "\n2 - Bubble Sort words" +
                       "\n3 - LINQ/Lambda sort words" +
                       "\n4 - Count the Distinct Words" +
                       "\n5 - Take the first 10 words" +
                       "\n6 - Get the number of words that start with 'j' and display the count" +
                       "\n7 - Get and display of words that end with 'd' and display the count" +
                       "\n8 - Get and display of words that are greater than 4 characters long, and display the count" +
                       "\n9 - Get and display of words that are less than 3 characters long and start with the letter 'a', and display the count" +
                       "\nx - Exit" +
                       "\n\nSelect an option:");

                option = Console.ReadLine();
                Console.WriteLine("\n");
                Console.Clear();
                // using th if else function to choose the menu
                if (option == "1")
                {
                    option1(words);
                }else if (option == "2")
                {
                    BubbleSort(words);
                }
                else if (option == "3")
                {
                    option3(words);
                } else if (option == "4")
                {
                    option4(words);
                } else if (option == "5")
                {
                    option5(words);
                } else if (option == "6")
                {
                    option6(words);
                } else if (option == "7")
                {
                    option7(words);
                }
                else if (option == "8")
                {
                    option8(words);
                }
                else if (option == "9")
                {
                    option9(words);
                }
                else if (option == "x")
                {
                    a = false;
                }
                else
                {
                    System.Console.Write("Not a valid input");
                }
                

            }
        }
        /**
         * Method 1 - Imports the file and then reads it 
         * 
         */
        public static void option1(IList<string> words)
        {try // exception handilng if the file is not found
            {int a= words.Count();// function used to count the number of words in the file
             using (StreamReader ae = new StreamReader("Words.txt")) // Reading the file
            {string word;
             while ((word = ae.ReadLine()) != null)
             {words.Add(word);
              a++;
             }
            }
            Console.WriteLine("The number of words is  " + a);
            }
            catch (Exception e)
            {
                Console.WriteLine("The file is not found");Console.WriteLine(e.Message);
            }
        }
        /**
         * Method 2 - using the bubblesort
         * 
         */
        public static string[] BubbleSort(IList<string> words)
        {string b; // stores the word while the file is sorting
         bool c; // does the sorting while the boolean is running
         var stopwatch = System.Diagnostics.Stopwatch.StartNew();
         if (words.Count != 0){
          do{
            c = false;
            for (int i = 0; i < words.Count - 1; i++) // start of the bubble sort
            {
            if (string.Compare(words[i], words[i + 1]) < 0)
             {b = words[i];
              words[i] = words[i + 1];
              words[i + 1] = b;
              c = true;
             }
            } // end of the bubble sort
            } while (c);
            }
            stopwatch.Stop();
            Console.WriteLine("Execution time " + stopwatch.ElapsedMilliseconds + "ms");

            return words.ToArray();
        }
        //Method 3 - for lambda sort
        public static void option3(IList<string> words)
        {Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
         var search = from a in words orderby a.ToString() select a;// lambda sort being done here 
         stopwatch.Stop();
         TimeSpan time = stopwatch.Elapsed;
         Console.WriteLine("Execution time: " + time.Milliseconds + "ms\n\n");
        }

        /**
         * Method 4 - Counts the distinct words
         * */
        public static void option4(IList<string> words)
        {var search = (from a in words select a).Distinct().Count();// using the distinct and count function to count the words
        Console.WriteLine("The number of distinct words is: " + search + "\n\n");
        }
        /**
         * Method 5 Counts the first 10 words in the file
         * */
        public static void option5(IList<string> words)
        {if (words.Count != 0) // using the count function which gets the number of words in the file
         {for (int i = 0; i < 10; i++)
                {Console.WriteLine(words[i]);
                }
            }
        }
        /**
         * Method 6 Counts the number of words which starts with J
         * */
        public static void option6(IList<string> words)
        {var search = (from a in words where a.StartsWith("j") select a); // extracts all the words that starts with J using the startswith function
        foreach (string value in search) 
        {Console.WriteLine(value);}
        Console.WriteLine("Number of words that start with 'j': " + search.Count() + "\n\n");
        }
        /**
         * Method 7 Counts the number of words which ends with a
         * */
        public static void option7(IList<string> words)
        {var search = (from a in words where a.EndsWith("d") select a); // extracts all the words that ends with a using the endswith function
        foreach (string value in search)
        {Console.WriteLine(value);}
        Console.WriteLine("Number of words that end with 'd': " + search.Count() + "\n\n");
        }
        /**
         * Method 8 Counts the number of words are longer than 4 characters
         * */
        public static void option8(IList<string> words)
        {var search = (from a in words where a.Length > 4 select a);// extracts all the words that are longer than 4 words using the length function
        foreach (string value in search)
        {Console.WriteLine(value);}
        Console.WriteLine("Number of words longer than 4 characters: " + search.Count() + "\n\n");
        }

        /**
         * Method 9 Counts the number of words are shorter than 3 characters and starts with a 
         * */
        public static void option9(IList<string> words)
        {var search = from a in words where a.Count() < 3 && a.StartsWith("a") select a;// extracts all the words that are shorter than 3 characters and start with  using the ccount function and startswith function
            foreach (var value in search)
         {Console.WriteLine(value);}
         Console.WriteLine("Number of words longer less than 3 characters and start with 'a': " + search.Count());
        }
    }
}