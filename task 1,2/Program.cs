internal class Program
{
    private static void Main(string[] args)
    {
        FileProcessor.FillFileOneInLine(
            "C:\\git_projects\\Lab7-PSU\\test1.txt", 10);
        bool isNoZeroInFile = FileProcessor.IsNoZero(
            "C:\\git_projects\\Lab7-PSU\\test1.txt");
        Console.WriteLine("Задание 1");
        if (!isNoZeroInFile)
        {
            Console.WriteLine("В первом файле есть 0");
        }
        else
        {
            Console.WriteLine("В первом файле нет 0");
        }

        Console.WriteLine("\nЗадание 2");
        FileProcessor.FillFileManyInLine(
            "C:\\git_projects\\Lab7-PSU\\test2.txt",
            10, 5);
        long max = FileProcessor.findMaxNumber(
            "C:\\git_projects\\Lab7-PSU\\test2.txt");
        Console.WriteLine("Наибольшее число " +
            "во втором файле: " + max);

        Console.WriteLine("\nЗадание 3");
        FileProcessor.FilterLinesByLastChar(
            "C:\\git_projects\\Lab7-PSU\\test3from.txt",
            "C:\\git_projects\\Lab7-PSU\\test3to.txt", 's');
        Console.WriteLine("Ответ записан в файл");

        Console.WriteLine("\nЗадание 4");
        FileProcessor.CreateBinaryFile(
            "C:\\git_projects\\Lab7-PSU\\test4.bin", 14);
        int count = FileProcessor.CountOppositePairs(
            "C:\\git_projects\\Lab7-PSU\\test4.bin");
        Console.WriteLine("Количестов пар в бинарном файле = " +
            count);


        Console.WriteLine("\nЗадание 6");
        List<int> list =
            new List<int> { 1, 5, 1, 8, 3, 1, 7, 9, 2, 1, 4, 6 };
        Console.Write("Список до удаления: ");
        foreach (int i in list)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
        CollectionProcessor.RemoveAfter(list, 1);
        Console.Write("Список после удаления: ");
        foreach (int i in list)
        {
            Console.Write(i + " ");
        }

        Console.WriteLine("\n\nЗадание 7");
        List<int> numberList =
            new List<int> { 1, 2, 3, 4, 1 };
        LinkedList<int> linkedList
            = new LinkedList<int>(numberList);
        Console.WriteLine("LinkedList: ");
        foreach (int i in linkedList)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
        if (CollectionProcessor.IsSameNeighbors(linkedList))
        {
            Console.WriteLine("Есть 2 одинаковых соседних" +
                " элемента");
        }
        else
        {
            Console.WriteLine("Нет 2 одинаковых соседних" +
                " элементов");
        }

        Console.WriteLine("\nЗадание 8");
        List<string> countries = new List<string>
            { "Russia", "Italy", "France", "Poland"};
        List<HashSet<string>> tourists =
            new List<HashSet<string>>
            {
                new HashSet<string> { "Russia", "Italy" },
                new HashSet<string> { "Russia", "Italy", 
                    "France" },
                new HashSet<string> { "Russia" }
            };

        CollectionProcessor.PrintAnalizedContries(tourists, countries);
    }
}