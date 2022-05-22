using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Directory : Components
    {
        public static void ForDir1()
        {
            Archive archive1 = new Archive(10.2, DirList);
            Mp3 mp3_1 = new Mp3(1.2, DirList);
            Mp3 mp3_2 = new Mp3(2.8, DirList);
            Mp3 mp3_3 = new Mp3(0.6, DirList);
        }

        public static List<Components> DirList = new List<Components>();

        public Directory(List<Components> list)
        {
            list.Add(this);
        }

        public static double Scale;

        public static void CheckSize(List<Components> list)
        {
            foreach (Components item in list)
            {
                Scale = Scale + item.ReturnSize();
            }
            Console.WriteLine();
            Console.WriteLine("Розмiр директорiї - " + Scale + " mb");
        }

        public override double ReturnSize()
        {
            return Scale;
        }

        public static List<Components> GetDirList()
        {
            ForDir1();
            ShowDescription(DirList);    
            Console.WriteLine();    
            return DirList;
        }

        public static void ShowDescription(List<Components> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.GetDescription());
            }
        }

        public static void CheckType(List<Components> list)
        {
            int Count1 = 0, Count2 = 0, Count3 = 0;
            Console.WriteLine();
            Console.WriteLine("У директорiї знаходяться:");
            foreach (Components component in list)
            {
                if (component.GetType() == typeof(File))
                {
                    Count1++;
                }
                else if (component.GetType() == typeof(Archive))
                {
                    Count2++;
                }
                else if(component.GetType() == typeof(Mp3))
                {
                    Count3++;
                }
            }
            if (Count1 != 0)
            {
                Console.WriteLine(typeof(File) + " " + Count1 + " шт.");
            }
            if (Count2 != 0)
            {
                Console.WriteLine(typeof(Archive) + " " + Count2 + " шт.");
            }
            if (Count3 != 0)
            {
                Console.WriteLine(typeof(Mp3) + " " + Count3 + " шт.");
            }
        }

        public static void CountMp3(List<Components> list)
        {
            int Count = 0;
            foreach (Components component in list)
            {
                if (component.GetType() == typeof(Mp3))
                {
                    Count++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Кiлькiсть Mp3 файлiв у директорiї - " + Count);
        }

        public static void FileOpen(Components component)
        {
            if (component.GetType() == typeof(File))
            {
                Console.WriteLine();
                Console.WriteLine("Запуск файлу " + component.GetType());
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Помилка запуску " + component.GetType() + ". Запустит можна тiльки файл!");
                Console.WriteLine();
            }
        }

        public override string GetDescription()
        {
            return "Додана директорiя з розмiром " + Scale + " mb";
        }
    }
}
