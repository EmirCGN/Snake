using System;
using System.Threading;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;
using System.Speech.Synthesis;
using System.Threading.Channels;
using System.Diagnostics;

class Snake
{
    static void Main(string[] args)
    {
        Stopwatch time = new Stopwatch();
        int x = 10, y = 10; // Startposition des Schlangenkopfs
        int foodX = 15, foodY = 15; // Startposition des Futters
        int score = 0;
        List<Tuple<int, int>> snake = new List<Tuple<int, int>>();
        snake.Add(new Tuple<int, int>(x, y));
        char input;
        SpeechSynthesizer synth = new SpeechSynthesizer();

        Anfang:
        Console.Clear();
        Console.WriteLine("----------Menü----------");
        Console.WriteLine("1. Statistiken");
        Console.WriteLine("2. Spiel starten");
        Console.WriteLine("3. Programm beenden");
        Console.WriteLine("(Geben Sie eine Zahl ein!)");
        Console.WriteLine("------------------------");
        Console.Write("> ");
        int menu = Convert.ToInt32(Console.ReadLine());


        if (menu == 1)
        {
            Console.WriteLine("Score: " + score);
            Console.WriteLine("Überlebende Zeit: {0}\n", time.Elapsed);
            Thread.Sleep(1000);

            Console.WriteLine("Bitte drücken Sie ENTER um ins Menü zu gelangen!");
            Console.ReadKey();
            goto Anfang;

        }
        if (menu == 2)
        {
            time.Start();
        while (true)
        {
            Console.Clear(); // Löscht den Bildschirm
            Console.SetCursorPosition(x, y); // Setzt die Cursorposition
            Console.Write("O"); // Zeichnet den Schlangenkopf
            Console.SetCursorPosition(foodX, foodY); // Setzt die Cursorposition
            Console.Write("X"); // Zeichnet das Futter
            Console.SetCursorPosition(0, 0); // Setzt die Cursorposition
            Console.Write("Score:{0}        Time:{1}",score,time.Elapsed); // Zeigt die Punktzahl und wie lange man überlebt hat an


            input = Console.ReadKey(true).KeyChar; // Liest die Tasteneingabe

            if (input == 'w') y--; // hoch
            else if (input == 's') y++; // runter
            else if (input == 'a') x--; // links
            else if (input == 'd') x++; // rechts
            if (x <= 0 || x >= Console.WindowWidth || y <= 0 || y >= Console.WindowHeight || snake.Contains(new Tuple<int, int>(x, y))) // Man kann nicht über die Borderline gehen mit der Schlange
            {
                Console.Clear();
                Console.Beep(330, 500);
                synth.Speak("Game over");
                Console.WriteLine("Game Over! Dein score ist: " + score);
                Console.WriteLine("Drücke R um neuzustarten\n Drücke Q um das Spiel zu beenden\n Drücke M um wieder ins Menü zu gelangen");
                input = Console.ReadKey(true).KeyChar;
                if (input == 'r') // Startet das Spiel neu
                {
                        time.Stop();
                        time.Reset();
                        x = 10;
                        y = 10;
                        foodX = 15;
                        foodY = 15;
                        score = 0;
                        snake.Clear();
                        snake.Add(new Tuple<int, int>(x, y));
                }
                else if (input == 'q') // Beendet das Programm
                    {
                        time.Stop();
                        break;
                    }
                else if(input == 'm') // Bringt zurück ins Menü
                    {
                        time.Stop();
                        goto Anfang;
                    }
            }

            // Überprüft, ob die Schlange das Futter gefressen hat
            if (x == foodX && y == foodY)
            {
                foodX = new Random().Next(0, Console.WindowWidth); // Generiert eine neue x-Position für das Futter
                foodY = new Random().Next(1, Console.WindowHeight);// Generiert eine neue y-Position für das Futter
                score++;
            }

            Thread.Sleep(100); // Wartet 100 Millisekunden
        }
        }else if(menu == 3){
            Console.WriteLine("Spiel wird beendet!");
            Environment.Exit(0);
        }
    }
}
