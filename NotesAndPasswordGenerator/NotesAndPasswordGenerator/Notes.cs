using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAndPasswordGenerator
{
    internal static class Notes
    {
        public static List<string> ShowNotes(bool invalidInput, List<string> notes)
        {
            Console.Clear();

            if (invalidInput)
            {
                ColorText.WriteColorLine("Не існуючий варіант, спробуйте ще раз!\n", ConsoleColor.Red);
            }

            ColorText.WriteColorLine("-< Нотатки >-\n", ConsoleColor.Yellow);
            Console.WriteLine("Виберіть дію:");

            Console.WriteLine("1: Створити нову нотатку");
            Console.WriteLine("2: Показати всі нотатки");
            Console.WriteLine("3: Показати нотатку по індексу");
            Console.WriteLine("4: Змінити нотатку по індексу");
            ColorText.WriteColorLine("5: Видалити нотатку по індексу", ConsoleColor.Red);
            ColorText.WriteColorLine("6: Видалити всі нотатки", ConsoleColor.Red);
            ColorText.WriteColorLine("\nНатиснення будь якої клавіши після виконання дії поверне вас до цього меню", ConsoleColor.Magenta);

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Console.WriteLine("Введіть нотатку: ");
                    notes.Add(Console.ReadLine());
                    ColorText.WriteColorLine("Нотатку додано!", ConsoleColor.Green);
                    Console.ReadKey(true);

                    ShowNotes(false, notes);
                    return notes;
                case ConsoleKey.D2:
                    Console.Clear();
                    Console.WriteLine("Список нотаток:");

                    for (int i = 0; i < notes.Count; i++)
                    {
                        Console.WriteLine($"{i}: {notes[i]}");
                    }
                    Console.ReadKey(true);
                    ShowNotes(false, notes);
                    return notes;
                case ConsoleKey.D3:
                    Console.Clear();
                    Console.WriteLine("Введіть індекс нотатки:");

                    if (int.TryParse(Console.ReadLine(), out int j) && j >= 0 && j < notes.Count)
                    {
                        Console.WriteLine($"Нотатка {j}: {notes[j]}");
                        Console.ReadKey(true);
                        ShowNotes(false, notes);
                    }
                    else
                    {
                        ColorText.WriteColorLine("Неправильний індекс!", ConsoleColor.Red);
                        Console.ReadKey(true);
                        ShowNotes(false, notes);
                    }
                    return notes;
                case ConsoleKey.D4:
                    Console.Clear();
                    Console.WriteLine("Введіть індекс нотатки для зміни:");

                    if (int.TryParse(Console.ReadLine(), out int k) && k >= 0 && k < notes.Count)
                    {
                        Console.WriteLine($"Нотатка {k}: {notes[k]}");
                        Console.WriteLine("Введіть нову нотатку:");
                        notes[k] = Console.ReadLine();
                        ColorText.WriteColorLine("Нотатку змінено!", ConsoleColor.Green);
                        Console.WriteLine($"Нотатка {k}: {notes[k]}");
                        Console.ReadKey(true);
                        ShowNotes(false, notes);
                    }
                    else
                    {
                        ColorText.WriteColorLine("Неправильний індекс!", ConsoleColor.Red);
                        Console.ReadKey(true);
                        ShowNotes(false, notes);
                    }
                    return notes;
                case ConsoleKey.D5:
                    Console.Clear();
                    Console.WriteLine("Введіть індекс нотатки для видалення:");
                    if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < notes.Count)
                    {
                        notes.RemoveAt(index);
                        ColorText.WriteColorLine("Нотатку видалено!", ConsoleColor.Green);
                        Console.ReadKey(true);
                        ShowNotes(false, notes);
                    }
                    else
                    {
                        ColorText.WriteColorLine("Неправильний індекс!", ConsoleColor.Red);
                        Console.ReadKey(true);
                        ShowNotes(false, notes);
                    }
                    return notes;
                case ConsoleKey.D6:
                    Console.Clear();
                    ColorText.WriteColorLine("Ви впевнені що хочете видалити всі нотатки? (y/n)", ConsoleColor.Red);
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        notes.Clear();
                        ColorText.WriteColorLine("\nВсі нотатки видалено!", ConsoleColor.Red);
                        Console.ReadKey(true);
                        ShowNotes(false, notes);
                    }
                    else
                    {
                        ColorText.WriteColorLine("\nВидалення скасовано.", ConsoleColor.DarkGray);
                        Console.ReadKey(true);
                        ShowNotes(false, notes);
                    }
                    return notes;
                case ConsoleKey.Escape:
                    return notes;
                default:
                    ShowNotes(true, notes);
                    return notes;
            }

        }
    }
}
