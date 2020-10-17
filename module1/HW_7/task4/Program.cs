using System;
using System.Text;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace task4
{
    class MainClass
    {
        public static void Menu()
        {
            Console.WriteLine("Выберите команду(введите номер команды):" + Environment.NewLine +
                              "1.Добавить новый словарь." + Environment.NewLine +
                              "2.Добавить новое слово." + Environment.NewLine +
                              "3.Найти слово." + Environment.NewLine +
                              "4.Сыграть в карты." + Environment.NewLine +
                              "5.Выход." + Environment.NewLine);

            if (int.TryParse(Console.ReadLine(), out int ans))
            {
                switch (ans)
                {
                    case 5:
                        Environment.Exit(0);
                        break;
                    case 1:
                        AddNewDict();
                        break;
                    case 2:
                        AddNewWord();
                        break;
                    case 3:
                        GetTranslation();
                        break;
                    case 4:
                        PlayCards();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода.");
            }

        }

        public static void AddNewDict()
        {
            string name = Console.ReadLine();
            name += ".txt";
            try
            {
                if (File.Exists(name))
                {
                    Console.WriteLine("Такой словарь уже существует.");
                    return;

                }
                else
                {
                    File.AppendAllText(name, "");
                    Console.WriteLine("Словарь создан");
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при создании словаря: " + ex.Message + ex.GetType().Name);
                return;
            }

        }

        public static void AddNewWord()
        {
            Console.Write("Введите назввание словаря: ");
            string nameOfDict = Console.ReadLine();
            nameOfDict += ".txt";

            try
            {
                if (File.Exists(nameOfDict))
                {
                    Console.Write("Введите новое слово: ");
                    string word = Console.ReadLine();
                    Console.Write("Введите перевод: ");
                    string translation = Console.ReadLine();

                    if (word.Trim() != "" && translation.Trim() != "")
                    {
                        File.AppendAllText(nameOfDict, word + "-" + translation + Environment.NewLine);
                        Console.WriteLine("Слово добавлено.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода: введена пустая строка.");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Такого словаря не существует.");
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при добавлении слова: " + ex.Message + ex.GetType().Name);
                return;
            }
        }

        public static void GetTranslation()
        {
            Console.Write("Введите назввание словаря: ");
            string nameOfDict = Console.ReadLine();
            nameOfDict += ".txt";

            try
            {
                if (File.Exists(nameOfDict))
                {
                    Console.Write("Введите интересующее слово: ");
                    string word = Console.ReadLine();

                    string[] ans;

                    try
                    {
                        ans = File.ReadAllLines(nameOfDict);
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка при чтении слов: " + ex.Message + ex.GetType().Name);
                        return;
                    }

                    bool flag = true;
                    foreach (string str in ans)
                    {
                        if (str.StartsWith(word))
                        {
                            flag = false;
                            Console.WriteLine(str);
                        }
                    }
                    if (flag) Console.WriteLine("Слово не найдено.");

                }

                else
                {
                    Console.WriteLine("Такого словаря не существует.");
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при поиске перевода: " + ex.Message + ex.GetType().Name);
                return;
            }
        }

        public static int score = 0;

        public static void PlayCards()
        {


            Console.WriteLine("Игра в слова:" + Environment.NewLine +
                              "Вам будет предлагаться случайное слово из выбранного словаря." + Environment.NewLine +
                              "Ваша задача написать корерктрый перевод." + Environment.NewLine +
                              "За кадый правильный ответ начисляется балл." + Environment.NewLine +
                              "Логи игры сохраняются в файле Score.csv" + Environment.NewLine +
                              "Для выхода в меню, введите -quit" + Environment.NewLine +
                              "Enjoy." + Environment.NewLine);

            Console.Write("Введите название словаря: ");
            string nameOfDict = Console.ReadLine();
            if (nameOfDict == "-quit")
            {
                return;
            }
            else
            {
                nameOfDict += ".txt";
                List<string> words = new List<string>();
                Random rnd = new Random();
                try
                {
                    if (File.Exists(nameOfDict))
                    {
                        try
                        {
                            words = File.ReadAllLines(nameOfDict).ToList();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ошибка при чтении слов: " + ex.Message + ex.GetType().Name);
                            return;
                        }


                        int initial = words.Count();


                        for(int i = 0; i<initial;i++)
                        {
                            string pair0 = words[rnd.Next(words.Count())];
                            string[] pair = pair0.Split('-');
                            words.Remove(pair0);

                            Console.Write(Environment.NewLine + $"Введите первод {pair[0]} - ");
                            string ans = Console.ReadLine();
                            if (ans == "-quit")
                            {
                                SaveResults();
                                return;
                            }
                            else
                            {
                                if (ans == pair[1])
                                {
                                    Console.WriteLine("Верно!");
                                    score++;

                                }
                                else
                                    Console.WriteLine("Невеврно. Верный ответ: " + pair[1]);
                            }

                        }
                        Console.Write(Environment.NewLine + $"Слова закончились. Ваш результат {score} из {initial}." + Environment.NewLine);
                        SaveResults();

                    }
                    else
                    {
                        Console.WriteLine("Такого словаря не существует.");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при поиске словаря: " + ex.Message + ex.GetType().Name);
                    return;
                }
            }
        }

        public static void SaveResults()
        {
            Console.Write("Введите имя пользователя для записи результатов: ");
            string name = Console.ReadLine();
            try 
            {
                File.AppendAllText("score/Score.csv", name + ";" + score + ";" + System.DateTime.Now.ToString() + "\n");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Ошибка при создании Score.csv: " + ex.Message + ex.GetType().Name);
                return;
            }
            Console.WriteLine("Результат сохранен.");
        }


public static void Main(string[] args)
{
    Console.OutputEncoding = Encoding.UTF8;
    Console.InputEncoding = Encoding.UTF8;
    //CultureInfo.CurrentCulture = new CultureInfo("ru-Ru", false);

    while (true)
    {
        Console.WriteLine("\n");
        Menu();
    }

}
}
}
