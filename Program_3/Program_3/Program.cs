using System;
using System.IO;
using System.Linq;

class Program_3
{
    static void Main(string[] args)
    {
        string input_a = "D:\\Універ\\2 курс\\2 семестр\\Крос-платформне програмуваня\\Лаби\\Lab_8\\Program_3\\input.txt";
        string output_a = "D:\\Універ\\2 курс\\2 семестр\\Крос-платформне програмуваня\\Лаби\\Lab_8\\Program_3\\output.txt";
        string text;
        using(FileStream stream_r = File.OpenRead(input_a))
        {
            byte[] word_arr = new byte[stream_r.Length];
            stream_r.Read(word_arr, 0, word_arr.Length);

            text = System.Text.Encoding.Default.GetString(word_arr);
        }

        string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var filteredWords = words.Where(w => words.Count(x => x == w) > 1);

        using (StreamWriter writer = new StreamWriter(output_a))
        {
            writer.Write(string.Join(" ", filteredWords));
        }
    }
}