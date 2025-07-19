using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAndPasswordGenerator
{
    internal static class Contacts
    {
        public static void AddContact(Dictionary<string,string> contacts)
        {
            Console.Clear();
            ColorText.WriteColorLine("Введіть ім'я контакту:", ConsoleColor.Cyan);
            string name = Console.ReadLine();
            ColorText.WriteColorLine("Введіть номер телефону:", ConsoleColor.Magenta);
            string phoneNumber = Console.ReadLine();
            if (contacts.ContainsKey(name))
            {
                ColorText.WriteColorLine("Контакт з таким ім'ям вже існує!", ConsoleColor.Red);
                Console.ReadKey(true);
            }
            else
            {
                contacts.Add(name, phoneNumber);
                ColorText.WriteColorLine("Контакт успішно додано!", ConsoleColor.Green);
                Console.ReadKey(true);
            }
        }

        public static void ShowContacts(Dictionary<string, string> contacts) 
        {
            Console.Clear();
            if (contacts.Count < 1)
            {
                ColorText.WriteColorLine("Контакти відсутні!", ConsoleColor.Red);
                Console.ReadKey(true);
            }
            else
            {
                 ColorText.WriteColorLine("Список контактів:", ConsoleColor.Yellow);
                     foreach (KeyValuePair<string,string> kv in contacts)
                     {
                         Console.WriteLine(kv.Key + " - " + kv.Value);
                     }
                Console.ReadKey(true);
            }
        }

        public static void DeleteContact(Dictionary<string, string> contacts)
        {
            Console.Clear();
            ColorText.WriteColorLine("Введіть ім'я контакту для видалення:", ConsoleColor.DarkGray);
            string name = Console.ReadLine();
            if (contacts.ContainsKey(name))
            {
                Console.WriteLine($"Ви впевнені, що хочете видалити контакт {name}? (y/n)");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    contacts.Remove(name);
                    ColorText.WriteColorLine("\nКонтакт успішно видалено!", ConsoleColor.Green);
                    Console.ReadKey(true);
                }
                else
                {
                    ColorText.WriteColorLine("\nВидалення скасовано.", ConsoleColor.Yellow);
                    Console.ReadKey(true);
                }
            }
            else
            {
                ColorText.WriteColorLine("Контакт з таким ім'ям не знайдено!", ConsoleColor.Red);
                Console.ReadKey(true);
            }
        }

    }
}
