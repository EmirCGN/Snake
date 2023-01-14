using System;
using System.Threading;

class Snake
{
    static void Main(string[] args)
    {
        int x = 10, y = 10; // Startposition des Schlangenkopfs
        int foodX = 15, foodY = 15; // Startposition des Futters
        char input;

        while (true)
        {
            Console.Clear(); // Löscht den Bildschirm
            Console.SetCursorPosition(x, y); // Setzt die Cursorposition
            Console.Write("O"); // Zeichnet den Schlangenkopf
            Console.SetCursorPosition(foodX, foodY); // Setzt die Cursorposition
            Console.Write("X"); // Zeichnet das Futter

            input = Console.ReadKey().KeyChar; // Liest die Tasteneingabe

            if (input == 'w') y--; // Bewegt die Schlange nach oben
            else if (input == 's') y++; // Bewegt die Schlange nach unten
            else if (input == 'a') x--; // Bewegt die Schlange nach links
            else if (input == 'd') x++; // Bewegt die Schlange nach rechts

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
