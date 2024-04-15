using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = "input.txt";
        string outputFilePath = "output.txt";

        try
        {
            bool is_containing_letters = false;
            bool are_words_written = false;

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string content = reader.ReadToEnd();
                is_containing_letters = Regex.IsMatch(content, @"\p{L}");
            }

            if (!is_containing_letters)
            {
                Console.WriteLine("Файл порожній або містить лише цифри.");
            }
            else
            {
                using (StreamReader reader = new StreamReader(inputFilePath))
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] words = Regex.Split(line, @"[^\p{L}]+");

                        foreach (string word in words)
                        {
                            if (!string.IsNullOrEmpty(word) && word.Length % 2 == 0)
                            {
                                writer.WriteLine(word);
                                are_words_written = true;
                            }
                        }
                    }
                }

                if (!are_words_written)
                {
                    Console.WriteLine("У файлі відсутні слова з парною кількістю букв.");
                }
                else
                {
                    Console.WriteLine($"Результати було записано у файл {outputFilePath}.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Сталася помилка: {ex.Message}");
        }
    }
}