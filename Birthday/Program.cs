using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using static ConsoleApp2.Program;
using System.Globalization;
using Google.Protobuf.WellKnownTypes;
using MySqlX.XDevAPI.Relational;
using Birthday;

namespace ConsoleApp2
{
    class Program
    {
        delegate void method();
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            BirthdayService birthService = new BirthdayService();
            string[] items = { "Показать весь список ДР", "Показать ближайшие ДР", "Добавить ДР", "Удалить ДР", "Резактировать ДР", "Выход" };
            method[] methods = new method[] { birthService.ShowAllBirthList, birthService.UpcomingBirth, birthService.AddNewBirth, birthService.DelBirth, EditBirth, Exit };
            ConsoleMenu menu = new ConsoleMenu(items);
            int menuResult;
            do
            {
                menuResult = menu.PrintMenu();
                methods[menuResult]();
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey();
            } while (menuResult != items.Length - 1);
        }
        static void EditBirth() //редактирование записи БД
        {
            BirthdayService birthService = new BirthdayService();
            Console.Write("Что будем редактировать?");
            string[] items = { "Редактировать Имя", "Редактировать Дату", "Выход" };
            method[] methods = new method[] { birthService.ReName, birthService.ReDate, Exit };
            ConsoleMenu menu = new ConsoleMenu(items);
            int menuResult;
            do
            {
                menuResult = menu.PrintMenu();
                methods[menuResult]();
            } while (menuResult != items.Length - 1);
        }
        static void Exit() //выход
        {
            Console.WriteLine("Выходим...");
        }
    }
}
