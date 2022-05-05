// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System;

public class Program
{
    // static counters to be used when analyzing each algo
    static int count1;
    static int count2;
    static int count3;

    // Linear String search
    public static int Lin_Search(string[] readText, string X)
    {
        int n = readText.Length;
        for (int i = 0; i < n; i++)
        {
            count1++;
            if (readText[i] == X)
            {
                count1++;
                return i; 
            }
        }
        count1++;
        return -1;
    }

    // Binary iterative string search
    public static int Bin_It_Search_String(string[] readText, string X)
    {
        int lower = 0, upper = readText.Length - 1;
        while (lower <= upper)
        {
            count2++;
            int middle = lower + (upper - lower) / 2;

            int result = X.CompareTo(readText[middle]);

            if (result == 0)
            {
                count2++;
                return middle;
            }
            if (result > 0)
            {
                count2++;
                lower = middle + 1;
            }
            else
            {
                count2++;
                upper = middle - 1;
            }
        }
        count2++;
        return -1;
    }

    // Binary recursive string search
    public static int Bin_Rec_Search_String(string[] readText, int lower, int upper, string X)
    {
        if (upper >= lower)
        {
            count3++;
            int middle = lower + (upper - lower) / 2;

            int result = X.CompareTo(readText[middle]);
            if (result == 0)
            {
                count3++;
                return middle;
            }
            if (result < 0)
            {
                count3++;
                return Bin_Rec_Search_String(readText, lower, middle - 1, X);

            }
            else
            {
                count3++;
                return Bin_Rec_Search_String(readText, middle + 1, upper, X);
            }
        }
        count3++;
        return -1;
    }


    public static void Main()
    {
        // Provide file path for text file below
        string path = @"C:\Users\dawso\Desktop\data\movieTitles100.txt";


        if (File.Exists(path))
        {
            Console.WriteLine("Text file located successfully....\n");
            Console.WriteLine("Please input movie title below and hit enter\n");
            string userInput = Console.ReadLine();

            // Open the file to read from.
            string[] readText = File.ReadAllLines(path);
            string X = userInput;

            // Create stopwatch for linear search
            Stopwatch sw1 = Stopwatch.StartNew();
            // Call linear search passing new text file array and user search
            int resultLin = Lin_Search(readText, X);
            sw1.Stop();
            TimeSpan ts = sw1.Elapsed;

            //string elapsed1 = String.Format("{0:000.000}", ts.Milliseconds);

            // Display linear search results to console
            Console.WriteLine("\nThe Linear Search Result\n");
            if (resultLin == -1)
            {
                Console.WriteLine("String is not present in array");
            }
            else
            {
                Console.WriteLine("String located at index " + resultLin);
            }

            Console.WriteLine($"Time elapsed {ts}");
            Console.WriteLine($"Found in {count1} steps");


            //Create stopwatch for iterative search
            Stopwatch sw2 = Stopwatch.StartNew();

            //Call binary iterative search passing text file array and user search
            int resultBinIt = Bin_It_Search_String(readText, X);

            // Stop the second stop watch and store time in milliseconds
            sw2.Stop();
            TimeSpan ts2 = sw2.Elapsed;

            //string elapsed2 = String.Format("{0:000.000}", ts2.Milliseconds);

            Console.WriteLine("\nThe Binary iterative Search Result\n");
            if (resultBinIt == -1)
            {
                Console.WriteLine("String is not present in array");
            }
            else
            {
                Console.WriteLine("String located at index " + resultBinIt);
            }

            Console.WriteLine($"Time elapsed {ts2}");
            Console.WriteLine($"Found in {count2} steps");

            Stopwatch sw3 = Stopwatch.StartNew();

            // Binary Recurse Search For String
            int resultBinRec = Bin_Rec_Search_String(readText, 0, readText.Length, X);

            sw3.Stop();
            TimeSpan ts3 = sw3.Elapsed;

            //string elapsed3 = String.Format("{0:0000}", ts3.Milliseconds);

            Console.WriteLine("\nThe Binary recursive Search Result\n");
            if (resultBinRec == -1)
            {
                Console.WriteLine("String is not present in array");
            }
            else
            {
                Console.WriteLine("String located at index " + resultBinRec);
            }

            Console.WriteLine($"Time elapsed {ts2}");
            Console.WriteLine($"Found in {count3} steps");
        }
        else
        {
            Console.WriteLine("File not found");
        }

    }
}