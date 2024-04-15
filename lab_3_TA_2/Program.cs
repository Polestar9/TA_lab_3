using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        bool are_numbers_written = false;

        try
        {
            string inputFilePath = "f.txt";
            string outputFilePath = "g.txt";

            using (StreamReader reader = new StreamReader(inputFilePath))
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] numbers = line.Split(' ');

                    foreach (string numberStr in numbers)
                    {
                        if (int.TryParse(numberStr, out int number))
                        {
                            if (number % 2 == 0)
                            {
                                writer.WriteLine(number);
                                are_numbers_written = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Рядок '{numberStr}' не є цілим числом.");
                        }
                    }
                }

                if (are_numbers_written)
                {
                    Console.WriteLine("Операція завершена.\nПарні числа, які були в нбуло записано у файл g.txt.");
                }
                else
                {
                    Console.WriteLine("Жодного парного числа не було знайдено.\nБудь ласка, перевірте наявність парних чисел в вашому файлі.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Сталася помилка: {ex.Message}");
        }
    }
}