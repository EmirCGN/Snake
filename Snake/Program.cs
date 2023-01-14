using System;
using System.Threading;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;

class Snake
{
    static void Main(string[] args)
    {
        int x = 10, y = 10; // Startposition des Schlangenkopfs
        int foodX = 15, foodY = 15; // Startposition des Futters
        int score = 0;
        List<Tuple<int, int>> snake = new List<Tuple<int, int>>();
        snake.Add(new Tuple<int, int>(x, y));
        char input;

        while (true)
        {
            Console.Clear(); // Löscht den Bildschirm
            Console.SetCursorPosition(x, y); // Setzt die Cursorposition
            Console.Write("O"); // Zeichnet den Schlangenkopf
            Console.SetCursorPosition(foodX, foodY); // Setzt die Cursorposition
            Console.Write("X"); // Zeichnet das Futter

            input = Console.ReadKey().KeyChar; // Liest die Tasteneingabe

            if (input == 'w') y--; // hoch
            else if (input == 's') y++; // runter
            else if (input == 'a') x--; // links
            else if (input == 'd') x++; // rechts
            else if (input == 'r')
            {
                x = 10;
                y = 10;
                foodX = 15;
                foodY = 15;
                score = 0;
                snake = new List<Tuple<int, int>>();
                snake.Add(new Tuple<int, int>(x, y));
                continue;
            }
            else if (input == 'q') break;

            // Überprüft, ob die Schlange das Futter gefressen hat
            if (x == foodX && y == foodY)
            {
                foodX = new Random().Next(0, Console.WindowWidth); // Generiert eine neue x-Position für das Futter
                foodY = new Random().Next(0, Console.WindowHeight); // Generiert eine neue y-Position für das Futter
            }

            Thread.Sleep(100); // Wartet 100 Millisekunden
        }
    }
}
