using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3AND4
{
    public class Figure
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Color { get; set; }
        public Figure(string name, string path, string color)
        {
            Name = name;
            Path = path;
            Color = color;
        }
    }
}
