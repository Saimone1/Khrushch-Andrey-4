using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Disk
    {
        public static List<Components> DiskList = new List<Components>();

        Directory dir1 = new Directory(DiskList);
        Directory dir2 = new Directory(DiskList);
        File file1 = new File(2.1, DiskList);
        File file2 = new File(4.5, DiskList);
        Archive archive1 = new Archive(10.2, DiskList);
        Archive archive2 = new Archive(13.9, DiskList);

        public void FileOpen(Components component)
        {
            if (component.GetType() == typeof(File))
            {
                Console.WriteLine();
                Console.WriteLine("Запуск файлу " + component.GetType());
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Помилка запуску" + component.GetType() + ". Запустит можна тiльки файл!");
                Console.WriteLine();
            }
        }    
        
        public static List<Components> GetDiskList()
        {
            ShowDescription(DiskList);
            Console.WriteLine();
            return DiskList;
        }

        public static void ShowDescription(List<Components> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.GetDescription());
            }
        }
    }
}
