using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesAndPasswordGenerator;

namespace ContactBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            bool Running = true;
            bool invalidInput = false;

            Dictionary<string, string> contacts = new Dictionary<string, string>();

            while (Running)
            {
                Console.Clear();
                if (invalidInput)
                {
                    ColorText.WriteColorLine("Не існуючий варіант, спробуйте ще раз!\n", ConsoleColor.Red);
                    invalidInput = false;
                }
                ColorText.WriteColorLine("-< Книга контактів >-\n", ConsoleColor.Yellow);
                Console.WriteLine("Виберіть дію:");

                Console.WriteLine("1: Додати контакт");
                Console.WriteLine("2: Вивести всі контакти");
                Console.WriteLine("3: Видалити контакт");
                Console.WriteLine("esc: Завжди назад");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        Contacts.AddContact(contacts);
                        break;
                    case ConsoleKey.D2:
                        Contacts.ShowContacts(contacts);
                        break;
                    case ConsoleKey.D3:
                        Contacts.DeleteContact(contacts);
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
