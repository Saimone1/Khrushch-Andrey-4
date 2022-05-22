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

            List<Components> directories = Disk.GetDiskList();

            Components dir = directories[0];
            List<Components> components_of_dir1 = Directory.GetDirList();

            Components file1 = directories[2];
            Components archive1 = directories[4];

            Directory.CheckType(components_of_dir1);

            Directory.CountMp3(components_of_dir1);

            Directory.FileOpen(file1);
            Directory.FileOpen(archive1);

            Directory.CheckSize(components_of_dir1);
        }
    }
}
