﻿using System;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "SnakeGame - EmirCGN";

            Game game = new Game();
            game.Run();
        }
    }
}