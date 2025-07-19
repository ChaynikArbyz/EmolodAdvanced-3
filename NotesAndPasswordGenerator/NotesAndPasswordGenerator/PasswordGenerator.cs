using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAndPasswordGenerator
{
    internal static class PasswordGenerator
    {
        public static List<string> ShowPasswordGenerator(bool invalidInput, List<string> notes)
        {
            Console.Clear();

            if (invalidInput)
            {
                ColorText.WriteColorLine("Не існуючий варіант, спробуйте ще раз!\n", ConsoleColor.Red);
            }

            ColorText.WriteColorLine("-< генератор паролів >-\n", ConsoleColor.Yellow);
            Console.WriteLine("Виберіть дію:");

            Console.WriteLine("1: Створити новий пароль");
            ColorText.WriteColorLine("\nПаролі зберігаються в нотатках", ConsoleColor.Magenta);

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    int amountOfPasswords;
                    int passwordLength;
                    bool includeUppercase = false;
                    bool includeNumbers = false;
                    bool includeSpecialCharacters = false;

                    Console.Clear();
                    Console.WriteLine("Введіть кількість паролів:");
                    if (!int.TryParse(Console.ReadLine(), out amountOfPasswords))
                    {
                        ColorText.WriteColorLine("Невірний формат вводу", ConsoleColor.Red);
                        Console.ReadKey(true);
                        ShowPasswordGenerator(false, notes);
                    }
                    if (amountOfPasswords < 1)
                    {
                        ColorText.WriteColorLine("Кількість паролів має бути більше 0", ConsoleColor.Red);
                        Console.ReadKey(true);
                        ShowPasswordGenerator(false, notes);
                    }

                    Console.WriteLine("Введіть довжину паролів:");
                    if (!int.TryParse(Console.ReadLine(), out passwordLength))
                    {
                        ColorText.WriteColorLine("Невірний формат вводу", ConsoleColor.Red);
                        Console.ReadKey(true);
                        ShowPasswordGenerator(false, notes);
                    }
                    if (passwordLength < 1)
                    {
                        ColorText.WriteColorLine("Довжина паролів має бути більше 0", ConsoleColor.Red);
                        Console.ReadKey(true);
                        ShowPasswordGenerator(false, notes);
                    }
                    Console.WriteLine("Включати великі літери? (y/n)");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        includeUppercase = true;
                    }
                    Console.WriteLine("\nВключати цифри? (y/n)");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        includeNumbers = true;
                    }
                    Console.WriteLine("\nВключати спеціальні символи? (y/n)");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        includeSpecialCharacters = true;
                    }
                    Console.WriteLine("\nВаші паролі");

                    Random random = new Random();
                    const string lowercase = "abcdefghijklmnopqrstuvwxyz";
                    const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    const string numbers = "0123456789";
                    const string specialCharacters = "!@#$%^&*()_+-=[]{}|;:,.<>?";
                    string finalCharacters = lowercase;

                    if (includeUppercase) { finalCharacters += uppercase; }
                    if (includeNumbers) { finalCharacters += numbers; }
                    if (includeSpecialCharacters) { finalCharacters += specialCharacters; }

                    for (int i = 0; i < amountOfPasswords; i++)
                    {
                        string password = "";
                        for (int j = 0; j < passwordLength; j++)
                        {
                        password += finalCharacters[random.Next(finalCharacters.Length)];
                        }
                        Console.WriteLine(password);
                        notes.Add(password);
                    }
                    ColorText.WriteColorLine("\nПаролі успішно створені та збережені в нотатках", ConsoleColor.Green);

                    Console.ReadKey(true);
                    ShowPasswordGenerator(false, notes);
                    return notes;
                case ConsoleKey.Escape:
                    return notes;
                default:
                    ShowPasswordGenerator(true, notes);
                    return notes;
            }

        }
    }
}
