using System;

class Program
{
    const int MAX = 100;

    static void Main()
    {
        int n = GetNumberOfElements();
        int[] arr = GetArrayInput(n);
        int total = CalculateSum(arr);

        Console.WriteLine($"Sum of the numbers: {total}");
    }

    static int GetNumberOfElements()
    {
        while (true)
        {
            Console.Write("Enter the number of elements (1-100): ");
            if (int.TryParse(Console.ReadLine(), out int n) && n >= 1 && n <= MAX)
            {
                return n;
            }
            Console.WriteLine("Invalid input. Please provide a number between 1 and 100.");
        }
    }

    static int[] GetArrayInput(int n)
    {
        int[] arr = new int[n];
        Console.WriteLine($"Enter {n} integers:");
        for (int i = 0; i < n; i++)
        {
            while (true)
            {
                Console.Write($"Enter integer {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out arr[i]))
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
        return arr;
    }

    static int CalculateSum(int[] arr)
    {
        int result = 0;
        foreach (int num in arr)
        {
            result += num;
        }
        return result;
    }
}