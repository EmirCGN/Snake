using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food
    {
        private int x;
        private int y;

        public Food()
        {
            x = 15;
            y = 15;
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public void Generate()
        {
            // Generiere zufällige Koordinaten innerhalb des Konsolenfensters
            int windowWidth = Console.WindowWidth - 1;
            int windowHeight = Console.WindowHeight - 1;
            x = new Random().Next(1, windowWidth);
            y = new Random().Next(1, windowHeight);
        }

        public void Draw()
        {
            // Setze die Position des Cursors und zeichne das Food-Symbol
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("■");
            Console.ResetColor();
        }
    }
}
