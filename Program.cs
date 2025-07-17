namespace ПРОЕКТ._Слова
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int gameCount = 0;
            while (true)
            {
                bool flag = false;
                Console.WriteLine("Слова");
                Console.WriteLine();
                Console.WriteLine("1. Начать игру");
                Console.WriteLine("2. Выйти из игры");
                Console.WriteLine();
                string input;
                while (true)
                {
                    input = Console.ReadLine();
                    if (!(input == "1" || input == "2")) continue;
                    if (input == "2") flag = true;
                    break;
                }
                if (flag) break;

                Console.WriteLine();
                string[] words = ["ОКЕАН", "КНИГА", "МЫШКА", "РУЧКА", "ГОРОД", "ВОЛЬТ", "ШАШКИ", "СЪЕЗД", "БУБЕН", "МАСКА"];

                if (gameCount == 9) gameCount = 0;

                string word = words[gameCount];
                for (int k = 0; k < 7; k++) 
                {
                    Console.WriteLine("Назовите слово из 5 букв:");
                    Console.WriteLine();
                    while (true) 
                    {
                        input = Console.ReadLine();
                        if (input.Length != 5) continue;
                        if (HasWrongSymbols(input)) continue;
                        break;
                    }

                    Console.WriteLine(MakeAnswerString(word, input));
                    Console.WriteLine();

                    if (HasWrongSymbols(MakeAnswerString(word, input)))
                    {
                        if (k == 6)
                        {
                            Console.WriteLine("Вы проиграли!");
                            Console.WriteLine();
                        }
                        continue;
                    }
                    Console.WriteLine("Да! Всё верно вы победили!");
                    Console.WriteLine();
                    break;
                }
            }
        }
        static string MakeAnswerString(string word, string input) 
        {
            string result = "";
            for (int i = 0; i < input.Length; i++) 
            {
                if (input[i] == word[i]) result += input[i];
                else if (ContainsChar(word, input[i])) result += "#";
                else result += "@";
            }
            return result;
        }
        static bool ContainsChar(string word, char c) 
        {
            for (int i = 0; i < word.Length; i++) 
            {
                if (word[i] == c) return true;
            }
            return false;
        }
        static bool HasWrongSymbols(string input) 
        {
            for (int i = 0; i < input.Length; i++) 
            {
                if (!(input[i] >= 1040 && input[i] <= 1071)) return true;
            }
            return false;
        }
    }
}
