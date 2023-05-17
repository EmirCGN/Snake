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
            x = new Random().Next(1, Console.WindowWidth);
            y = new Random().Next(1, Console.WindowHeight);
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write("■");
        }
    }
}
