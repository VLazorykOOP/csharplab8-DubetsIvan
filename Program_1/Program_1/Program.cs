using System;
using System.IO;

class Program_1
{
    static void Main(string[] args)
    {
        int em_count = 0;
        string address_in = "D:\\Універ\\2 курс\\2 семестр\\Крос-платформне програмуваня\\Лаби\\Lab_8\\Program_1\\text.txt";
        string address_out = "D:\\Універ\\2 курс\\2 семестр\\Крос-платформне програмуваня\\Лаби\\Lab_8\\Program_1\\emails.txt";
        string text;

        using (FileStream stream_r = File.OpenRead(address_in))
        {
            byte[] text_b = new byte[stream_r.Length];
            stream_r.Read(text_b, 0, text_b.Length);

            text = System.Text.Encoding.Default.GetString(text_b);
        }

        string[] word = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        using (StreamWriter stream_w = new StreamWriter(address_out, true))
        {
            foreach (string el in word)
            {
                if (el.Contains("@gmail.com"))
                {
                    stream_w.WriteLine(el);
                    em_count++;
                }
            }
        }
        Console.WriteLine($"Found {em_count} gmails.");
    }
}