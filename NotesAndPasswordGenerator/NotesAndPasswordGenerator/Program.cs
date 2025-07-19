using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAndPasswordGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            bool Running = true;
            bool invalidInput = false;

            List<string> notes = new List<string>();

            while (Running)
            {
                Console.Clear();
                if (invalidInput)
                    {
                    ColorText.WriteColorLine("Не існуючий варіант, спробуйте ще раз!\n", ConsoleColor.Red);
                    invalidInput = false;
                    }
                ColorText.WriteColorLine("-< Нотатки + dlc генератор паролів >-\n", ConsoleColor.Yellow);
                Console.WriteLine("Виберіть дію:");

                Console.WriteLine("1: Нотатки");
                Console.WriteLine("2: Генератор паролів");
                Console.WriteLine("esc: Завжди назад");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        Notes.ShowNotes(false, notes);
                        break;
                    case ConsoleKey.D2:
                        PasswordGenerator.ShowPasswordGenerator(invalidInput, notes);
                        break;
                    case ConsoleKey.Escape:
                        Running = false;
                        break;
                    default:
                        invalidInput = true;
                        break;
                }
            }

        }
    }
}
