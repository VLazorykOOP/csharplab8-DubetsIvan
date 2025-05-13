using System;
using System.IO;

class Program_5
{
    static void Main()
    {
        string basePath = "D:\\Універ\\2 курс\\2 семестр\\Крос-платформне програмуваня\\Лаби\\Lab_8\\Program_5\\temp";
        string studentLastName = "Dubets";
        string folder1 = Path.Combine(basePath, studentLastName + "1");
        string folder2 = Path.Combine(basePath, studentLastName + "2");

        Directory.CreateDirectory(folder1);
        Directory.CreateDirectory(folder2);

        string t1Path = Path.Combine(folder1, "t1.txt");
        File.WriteAllText(t1Path, "Дубець Iван Русланович, 2006 року народження, мiсце проживання с. Топорiвцi");
        string t2Path = Path.Combine(folder1, "t2.txt");
        File.WriteAllText(t2Path, "Студент Бiба Бобович, 1987 року народження, мiсце проживання м. Чернiвцi");

        string t3Path = Path.Combine(folder2, "t3.txt");
        string t1Content = File.ReadAllText(t1Path);
        string t2Content = File.ReadAllText(t2Path);
        File.WriteAllText(t3Path, t1Content + Environment.NewLine + t2Content);

        Console.WriteLine("Iнформацiя про створенi файли:");
        PrintFileInfo(t1Path);
        PrintFileInfo(t2Path);
        PrintFileInfo(t3Path);

        string t2NewPath = Path.Combine(folder2, "t2.txt");
        File.Move(t2Path, t2NewPath);

        string t1CopyPath = Path.Combine(folder2, "t1.txt");
        File.Copy(t1Path, t1CopyPath, true);

        string allFolder = Path.Combine(basePath, "ALL");
        if (Directory.Exists(allFolder)) Directory.Delete(allFolder, true); 
        Directory.Move(folder2, allFolder);

        Directory.Delete(folder1, true);

        Console.WriteLine("\nПовна iнформацiя про файли в папцi ALL:");
        string[] files = Directory.GetFiles(allFolder);
        foreach (string file in files)
        {
            PrintFileInfo(file);
        }
    }

    static void PrintFileInfo(string filePath)
    {
        FileInfo fi = new FileInfo(filePath);
        Console.WriteLine($"Назва: {fi.Name}");
        Console.WriteLine($"Розташування: {fi.FullName}");
        Console.WriteLine($"Розмiр: {fi.Length} байт");
        Console.WriteLine($"Створено: {fi.CreationTime}");
        Console.WriteLine($"Змiнено: {fi.LastWriteTime}");
        Console.WriteLine(new string('-', 40));
    }
}