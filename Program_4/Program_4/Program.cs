using System;
using System.IO;

class Program_4
{
    static void Main()
    {
        Console.WriteLine("Введiть кiлькiсть чисел: ");
        int n = int.Parse(Console.ReadLine());

        double[] nums = new double[n];
        for (int i = 0; i < n; i++) {
            Console.WriteLine($"Введіть число {i + 1}: ");
            nums[i] = double.Parse(Console.ReadLine());
        }

        string address = "D:\\Універ\\2 курс\\2 семестр\\Крос-платформне програмуваня\\Лаби\\Lab_8\\Program_4\\nums.bin";
        using (BinaryWriter writer = new BinaryWriter(File.Open(address, FileMode.Create)))
        {
            foreach (double num in nums) {
            writer.Write(num);
            }
        }

        Console.WriteLine("Введiть дiапазон (a b): ");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());

        if (a < 0 || b >= n || a > b)
        {
            Console.WriteLine("Хибнi iндекси.");
            return;
        }

        Console.WriteLine("Числа поза дiапазоном: ");
        using (BinaryReader reader = new BinaryReader(File.Open(address, FileMode.Open)))
        {
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                for (int index = 0; index < n; index++)
                {
                    double num = reader.ReadDouble();
                    if (index < a || index > b)
                    {
                        Console.WriteLine(num);
                    }
                }
            }
        }
    }
}