using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        TemperaturesComparison.Run();
    }
}

public class TemperaturesComparison
{
    public static void Run()
    {
        List<int> temperatures = new List<int>();

        for (int i = 0; i < 5; i++)
        {
            int temp;
            do
            {
                Console.Write($"INPUT Temperature {i + 1}: ");
                temp = int.Parse(Console.ReadLine());

                if (temp < -30 || temp > 130)
                {
                    Console.WriteLine($"EXCEPTION Temperature {temp} is invalid, Please enter a valid temperature between -30 and 130");
                }
            } while (temp < -30 || temp > 130);

            temperatures.Add(temp);
        }

        // Determine and display the temperature trend
        if (IsAscending(temperatures))
        {
            Console.WriteLine("OUTPUT Getting Warmer");
        }
        else if (IsDescending(temperatures))
        {
            Console.WriteLine("OUTPUT Getting Colder");
        }
        else
        {
            Console.WriteLine("OUTPUT It's a mixed bag");
        }

        // Display the temperatures
        Console.WriteLine("OUTPUT 5-day Temperature [" + string.Join(", ", temperatures) + "]");

        // Display the average temperature
        double average = CalculateAverage(temperatures);
        Console.WriteLine($"OUTPUT Average Temperature is {average} degrees");
    }

    public static bool IsAscending(List<int> list)
    {
        for (int i = 1; i < list.Count; i++)
        {
            if (list[i] < list[i - 1]) return false;
        }
        return true;
    }

    public static bool IsDescending(List<int> list)
    {
        for (int i = 1; i < list.Count; i++)
        {
            if (list[i] > list[i - 1]) return false;
        }
        return true;
    }

    public static double CalculateAverage(List<int> list)
    {
        double sum = 0;
        foreach (int temp in list)
        {
            sum += temp;
        }
        return sum / list.Count;
    }
}
