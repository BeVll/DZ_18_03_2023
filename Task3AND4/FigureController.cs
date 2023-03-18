using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task3AND4
{
    public class FigureController
    {
        public string Path { get; set; }
        public FigureController(string path)
        {
            Path = path;
        }
        public void DisplayConsole(Figure figure)
        {
            if (figure == null) return;

            Console.WriteLine($"Name: {figure.Name}");
            Console.WriteLine($"Path: {figure.Path}");
            Console.WriteLine($"Color: {figure.Color}");
        }
        public void DisplayFile(Figure figure, string filepath)
        {
            if (figure == null) return;
            File.WriteAllText(filepath, $"Name: {figure.Name}; Path: {figure.Path}; Color: {figure.Color}");
        }
        public void SaveTxtFigures(List<Figure> figures)
        {
            File.Delete(Path + "figures.txt");
            foreach (Figure figure in figures)
            {
                File.AppendAllText(Path + "figures.txt", $"{figure.Name}, {figure.Path}, {figure.Color}; ");
            }
        }
        public void SaveJsonFigures(List<Figure> figures)
        {
            File.Delete(Path + "figures.json");
            string json = JsonSerializer.Serialize(figures);
            File.WriteAllText(Path + "figures.json", json);
        }

        public List<Figure> LoadTxtFigures()
        {
            List<Figure> figures = new List<Figure>();

            string file = File.ReadAllText(Path + "figures.txt");
            string[] figuresStr = file.Split("; ");

            foreach (string str in figuresStr)
            {
                if (str != "" && str != " ")
                {
                    string[] fig = str.Split(", ");
                    Figure figure = new Figure(fig[0], fig[1], fig[2]);
                    figures.Add(figure);
                }

            }

            return figures;
        }
        public List<Figure> LoadJsonFigures()
        {
            string str = File.ReadAllText(Path + "figures.json");
            List<Figure> figures = JsonSerializer.Deserialize<List<Figure>>(str);


            return figures;
        }
    }
}
