using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Disk disk = new Disk();

            File file1 = new File(2.1);
            disk.CheckSize(file1);

            File file2 = new File(4.5);
            disk.CheckSize(file2);

            Archive archive1 = new Archive(10.2);
            disk.CheckSize(archive1);

            Archive archive2 = new Archive(13.9);
            disk.CheckSize(archive2);

            Directory dir1 = new Directory();
            disk.CheckSize(dir1);

            dir1.Add(file1);
            dir1.Add(archive1);

            disk.CheckSize(dir1);

            Mp3 mp1 = new Mp3(3.4);
            dir1.Add(mp1);
            dir1.CheckSize(mp1);

            Mp3 mp2 = new Mp3(1.2);
            dir1.Add(mp2);
            dir1.CheckSize(mp2);

            Mp3 mp3 = new Mp3(5.4);
            dir1.Add(mp3);
            dir1.CheckSize(mp3);

            disk.CheckSize(dir1);

            disk.FileOpen(file2);

            disk.FileOpen(archive1);

            dir1.FileOpen(file1);

            dir1.CountMp3();

            dir1.CheckAllType();   
        }
    }
    class Disk
    {
        public void CheckSize(Components component)
        {
            component.CheckSize();
        }
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
                Console.WriteLine("Запустит можна тiльки файл!");              
            }
        }
    }

    abstract class Components
    {
        public abstract void CheckSize();
        public abstract double ReturnSize();
    }

    class File : Components
    {
        private double Size { get; set; }
        public File(double size)
        {
            Size = size;
        }
        public override void CheckSize()
        {
            Console.WriteLine("Розмiр файлу - " + this.Size + " mb");
        }
        public override double ReturnSize()
        {
            return Size;
        }
    }

    class Mp3 : Components
    {
        private double Size { get; set; }

        public Mp3(double size)
        {
            Size = size;
        }
        public override void CheckSize()
        {
            Console.WriteLine("Розмiр Mp3 - " + this.Size + " mb");
        }
        public override double ReturnSize()
        {
            return Size;
        }
    }

    class Archive : Components
    {
        private double Size { get; set; }
        public Archive(double size)
        {
            Size = size;
        }
        public override void CheckSize()
        {
            Console.WriteLine("Розмiр архiву - " + this.Size + " mb");
        }

        public override double ReturnSize()
        {
            return Size;
        }
    }
    class Directory : Components
    {
        static double Mp3count = 0;
        static double Filecount = 0; 
        static double Archivecount = 0;
        static double Scale = 0;
        public void Add(Components component)
        {
            Console.WriteLine();
            if(component.GetType() == typeof(Mp3))
            {
                Mp3count++;
            }
            else if(component.GetType() == typeof(File))
            {
                Filecount++;
            }
            else if (component.GetType() == typeof(Archive))
            {
                Archivecount++;
            }
            Scale = Scale + component.ReturnSize();
            Console.WriteLine("До директорiї доданий обьєкт " + component.GetType());
        }

        public override void CheckSize()
        {
            Console.WriteLine();
            Console.WriteLine("Розмiр директорiї - " + Scale + " mb");
        }

        public override double ReturnSize()
        {
            return Scale;
        }

        public void CheckSize(Components component)
        {
            Console.WriteLine("Розмiр Mp3 у директорiї - " + component.ReturnSize() + " mb");
        }

        public void CheckAllType()
        {
            Console.WriteLine();
            Console.WriteLine("У директорiї знаходяться:");
            Console.WriteLine(typeof(File) + " " + Filecount + " шт.");
            Console.WriteLine(typeof(Archive) + " " + Archivecount + " шт.");
            Console.WriteLine(typeof(Mp3) + " " + Mp3count + " шт.");
        }

        public void CountMp3()
        {
            Console.WriteLine();
            Console.WriteLine("Кiлькiсть Mp3 файлiв у директорiї - " + Mp3count);
        }

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
                Console.WriteLine("Запустит можна тiльки файл!");
            }
        }
    }
}
