using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

internal class FileProcessor
{
    public static void FillFileOneInLine(string path, 
        int count, int minValue = 0, int maxValue = 100)
    {
        Random random = new Random();

        using (StreamWriter writer = new StreamWriter(path))
        {
            for (int i = 0; i < count; i++)
            {
                int randomNumber = random.Next(minValue, maxValue);
                writer.WriteLine(randomNumber);
            }
        }
    }
    public static bool IsNoZero(string path)
    {
        using (StreamReader sr = File.OpenText(path))
        {
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                if(Convert.ToInt32(s) == 0)
                {
                    return false;
                }
            }
        }
        return true;
    }
    public static void FillFileManyInLine(string path, int line,
        int row, int minValue = 0,
        int maxValue = 100)
    {
        Random random = new Random();

        using (StreamWriter writer = new StreamWriter(path))
        {
            for(int i = 0; i < line; i++)
            {
                for(int j = 0; j < row; j++)
                {
                    writer.Write(
                        random.Next(minValue, maxValue));
                    if (j < row - 1)
                    {
                        writer.Write(" ");
                    }
                }
                writer.WriteLine();
            }
        }
    }
    public static int findMaxNumber(string path)
    {
        int maxNumber = int.MinValue;
        using (StreamReader sr = File.OpenText(path))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] numbers = line.Split(" ");
                foreach (string number in numbers)
                {
                    maxNumber = Math.Max(maxNumber,
                    Convert.ToInt32(number));
                }
            }
        }
        return maxNumber;
    }
    public static void FilterLinesByLastChar(string source,
        string target, char c)
    {
        using (StreamReader sr = File.OpenText(source))
        using (StreamWriter sw = File.CreateText(target))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line[line.Length - 1] == c)
                {
                    sw.WriteLine(line);
                }
            }
        }
    }
    public static void CreateBinaryFile(string path, int count,
        int minValue = -10, int maxValue = 10)
    {
        Random random = new Random();
        using (BinaryWriter writer = 
            new BinaryWriter(File.Create(path)))
        {
            for (int i = 0; i < count; i++)
            {
                writer.Write(random.Next(minValue, maxValue));
            }
        }
    }
    public static int CountOppositePairs(string filePath)
    {
        Dictionary<int, int> numberCounts = 
            new Dictionary<int, int>();
        int pairCount = 0;

        using (BinaryReader reader = new 
            BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            try
            {
                while (true)
                {
                    int number = reader.ReadInt32();
                    int opposite = -number;

                    if (numberCounts.
                        TryGetValue(opposite, out int oppositeCount)
                        && oppositeCount > 0)
                    {
                        numberCounts[opposite] = oppositeCount - 1;
                        pairCount++;
                    }
                    else
                    {
                        if (numberCounts.ContainsKey(number))
                        {
                            numberCounts[number]++;
                        }
                        else
                        {
                            numberCounts[number] = 1;
                        }
                    }
                }
            }
            catch (EndOfStreamException)
            {
                
            }
        }

        return pairCount;
    }
}
