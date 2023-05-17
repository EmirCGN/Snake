using System;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;

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
        SoundPlayer eatSound = new SoundPlayer("eat.wav");
        SoundPlayer gameOverSound = new SoundPlayer("gameover.wav");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.CursorVisible = false;

        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("----------Menü----------");
            Console.WriteLine("1. Statistiken");
            Console.WriteLine("2. Spiel starten");
            Console.WriteLine("3. Programm beenden");
            Console.WriteLine("(Geben Sie eine Zahl ein!)");
            Console.WriteLine("------------------------");
            Console.Write("> ");
            int menu = Convert.ToInt32(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    Console.WriteLine("Score: " + score);
                    Console.WriteLine("Überlebende Zeit: {0}\n", time.Elapsed);
                    Thread.Sleep(1000);

                    Console.WriteLine("Bitte drücken Sie ENTER um ins Menü zu gelangen!");
                    Console.ReadKey();
                    break;
                case 2:
                    time.Start();
                    x = 10;
                    y = 10;
                    foodX = 15;
                    foodY = 15;
                    score = 0;
                    snake.Clear();
                    snake.Add(new Tuple<int, int>(x, y));

                    while (true)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(x, y);
                        Console.Write("█");
                        Console.SetCursorPosition(foodX, foodY);
                        Console.Write("■");
                        Console.SetCursorPosition(0, 0);
                        Console.Write("Score:{0}        Time:{1}", score, time.Elapsed);

                        input = Console.ReadKey(true).KeyChar;

                        if (input == 'w') y--;
                        else if (input == 's') y++;
                        else if (input == 'a') x--;
                        else if (input == 'd') x++;

                        if (x <= 0 || x >= Console.WindowWidth || y <= 0 || y >= Console.WindowHeight || snake.Contains(new Tuple<int, int>(x, y)))
                        {
                            Console.Clear();
                            Console.Beep(330, 500);
                            gameOverSound.Play();
                            Console.WriteLine("Game Over! Dein Score ist: " + score);
                            Console.WriteLine("Drücke R um neuzustarten\n Drücke Q um das Spiel zu beenden\n Drücke M um wieder ins Menü zu gelangen");
                            input = Console.ReadKey(true).KeyChar;
                            if (input == 'r')
                                break;
                            else if (input == 'q')
                            {
                                running = false;
                                break;
                            }
                            else if (input == 'm')
                                break;
                        }

                        if (x == foodX && y == foodY)
                        {
                            eatSound.Play();
                            foodX = new Random().Next(1, Console.WindowWidth);
                            foodY = new Random().Next(1, Console.WindowHeight);
                            score++;
                        }

                        Thread.Sleep(100);
                    }

                    time.Stop();
                    break;
                case 3:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Ungültige Auswahl. Bitte geben Sie eine gültige Zahl ein.");
                    Thread.Sleep(1000);
                    break;
            }
        }

        Console.WriteLine("Spiel wird beendet!");
        Console.ReadLine();
    }
}
