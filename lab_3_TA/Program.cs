using System; using System.Text;  class Program {
    static bool brackets_checker(string text)
    {
        int brackets_round = 0;
        int brackets_square = 0;
        int brackets_curly = 0;

        foreach (char ch in text)
        {
            if (ch == '(')
                brackets_round++;
            else if (ch == ')')
                brackets_round--;
            else if (ch == '[')
                brackets_square++;
            else if (ch == ']')
                brackets_square--;
            else if (ch == '{')
                brackets_curly++;
            else if (ch == '}')
                brackets_curly--;
        }

        return brackets_round == 0 && brackets_square == 0 && brackets_curly == 0;
    }      static string RemoveTextInBrackets(string text)     {         StringBuilder result = new StringBuilder();         Stack<int> opened_brackets = new Stack<int>();         Stack<int> removed_text_indexes = new Stack<int>();          for (int i = 0; i < text.Length; i++)         {             char ch = text[i];              if (ch == '(')             {                 opened_brackets.Push(i);             }             else if (ch == ')')             {                 if (opened_brackets.Count > 0)                 {                     int startIndex = opened_brackets.Pop();                     removed_text_indexes.Push(startIndex);                     removed_text_indexes.Push(i);                 }             }              result.Append(ch);         }          while (removed_text_indexes.Count > 0)         {             int endIndex = removed_text_indexes.Pop();             int startIndex = removed_text_indexes.Pop();             result.Remove(startIndex, endIndex - startIndex + 1);         }          return result.ToString();     }       static void Main(string[] args)     {         Console.OutputEncoding = Encoding.UTF8;         bool execution_continue = true;          while (execution_continue)         {             Console.WriteLine("Введіть текстовий рядок:");             string inputText = Console.ReadLine() ?? "";              if (string.IsNullOrEmpty(inputText))             {                 Console.WriteLine("Рядок порожній.");                 continue;             }              if (brackets_checker(inputText))                 Console.WriteLine("Кількість відкритих та закритих дужок співпадає.");             else                 Console.WriteLine("Кількість відкритих та закритих дужок не співпадає.");              string textWithoutRoundBrackets = RemoveTextInBrackets(inputText);             Console.WriteLine("Текст без круглих дужок: " + textWithoutRoundBrackets);         }     } } 