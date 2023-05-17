using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Snake
{
    class Game
    {
        private Stopwatch time;
        private int score;
        private Snake snake;
        private Food food;
        private SoundPlayer eatSound;
        private SoundPlayer gameOverSound;
        private bool running;

        public Game()
        {
            time = new Stopwatch();
            score = 0;
            snake = new Snake();
            food = new Food();
            eatSound = new SoundPlayer("eat.wav");
            gameOverSound = new SoundPlayer("gameover.wav");
        }

        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorVisible = false;

            running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("----------Menü----------");
                Console.WriteLine("1. Spiel starten");
                Console.WriteLine("2. Statistiken");
                Console.WriteLine("3. Programm beenden");
                Console.WriteLine("(Geben Sie eine Zahl ein!)");
                Console.WriteLine("------------------------");
                Console.Write("> ");
                int menu = Convert.ToInt32(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        StartGame();
                        break;
                    case 2:
                        DisplayStatistics();
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

        private void StartGame()
        {
            score = 0;
            snake.Reset();
            food.Generate();

            time.Start();

            while (!snake.IsDead)
            {
                Console.Clear();
                snake.Move();
                snake.Draw();
                food.Draw();
                DisplayStats();

                if (snake.CheckCollision(food))
                {
                    eatSound.Play();
                    score++;
                    snake.Grow();
                    food.Generate();
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.R:
                            RestartGame();
                            break;
                        case ConsoleKey.M:
                            time.Stop();
                            return;
                        default:
                            snake.ChangeDirection(key);
                            break;
                    }
                }

                Thread.Sleep(100);
            }

            time.Stop();

            Console.Clear();
            Console.Beep(330, 500);
            gameOverSound.Play();
            Console.WriteLine("Game Over! Dein Score ist: " + score);
            Console.WriteLine("Drücke R um neuzustarten\nDrücke Q um das Spiel zu beenden\nDrücke M um wieder ins Menü zu gelangen");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.R)
                {
                    RestartGame();
                    break;
                }
                else if (key.Key == ConsoleKey.Q)
                {
                    running = false;
                    break;
                }
                else if (key.Key == ConsoleKey.M)
                {
                    time.Stop();
                    return;
                }
            }
        }

        private void RestartGame()
        {
            score = 0;
            snake.Reset();
            food.Generate();
            time.Restart();
        }

        private void DisplayStats()
        {
            Console.Clear();
            Console.WriteLine("Score: " + score);
            Console.WriteLine("Überlebende Zeit: {0}\n", time.Elapsed);
            Thread.Sleep(1000);

            Console.WriteLine("Bitte drücken Sie ENTER, um ins Menü zu gelangen!");
            Console.ReadKey();
        }

        private void DisplayStatistics()
        {
            Console.Clear();
            Console.WriteLine("-----Statistiken-----");
            Console.WriteLine("Score: " + score);
            Console.WriteLine("Überlebende Zeit: {0}\n", time.Elapsed);
            Thread.Sleep(1000);

            Console.WriteLine("Bitte drücken Sie ENTER, um ins Menü zu gelangen!");
            Console.ReadKey();
        }
    }
}
