using System;
using System.IO;

class Program_2
{
    static void Main(string[] args)
    {
        string num_str;
        string input_a = "D:\\Універ\\2 курс\\2 семестр\\Крос-платформне програмуваня\\Лаби\\Lab_8\\Program_2\\input.txt";
        using (FileStream stream_r = File.OpenRead(input_a))
        {
            byte[] arr_i = new byte[stream_r.Length];
            stream_r.Read(arr_i, 0, arr_i.Length);

            num_str = System.Text.Encoding.Default.GetString(arr_i);
        }

        int[] num = num_str
            .Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(n => int.Parse(n))
            .ToArray();

        int max = int.MinValue;
        foreach (int i in num)
        {
            if (i > max)
            {
                max = i;
            }
        }
        Console.WriteLine($"Max value: {max}");
    }
}