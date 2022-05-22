using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    abstract class Components
    {
        public abstract double ReturnSize();
        public abstract string GetDescription();
    }

    class File : Components
    {
        private double Size { get; set; }
        public File(double size, List<Components> list)
        {
            Size = size;
            list.Add(this);
        }

        public override double ReturnSize()
        {
            return Size;
        }

        public override string GetDescription()
        {
            return "Доданий файл з розмiром " + this.Size + " mb";
        }
    }

    class Mp3 : Components
    {
        private double Size { get; set; }

        public Mp3(double size, List<Components> list)
        {
            Size = size;
            list.Add(this);
        }

        public override double ReturnSize()
        {
            return Size;
        }

        public override string GetDescription()
        {
            return "Доданий Mp3 файл з розмiром " + this.Size + " mb";
        }
    }

    class Archive : Components
    {
        private double Size { get; set; }
        public Archive(double size, List<Components> list)
        {
            Size = size;
            list.Add(this);
        }

        public override double ReturnSize()
        {
            return Size;
        }

        public override string GetDescription()
        {
            return "Доданий архiв з розмiром " + this.Size + " mb";
        }
    }
}
