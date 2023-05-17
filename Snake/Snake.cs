using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        private List<Tuple<int, int>> body;
        private int directionX;
        private int directionY;
        private bool isDead;

        public Snake()
        {
            body = new List<Tuple<int, int>>();
            body.Add(new Tuple<int, int>(10, 10));
            directionX = 1;
            directionY = 0;
            isDead = false;
        }

        public bool IsDead
        {
            get { return isDead; }
        }

        public void Reset()
        {
            body.Clear();
            body.Add(new Tuple<int, int>(10, 10));
            directionX = 1;
            directionY = 0;
            isDead = false;
        }

        public void Move()
        {
            Tuple<int, int> head = GetHead();
            int newX = head.Item1 + directionX;
            int newY = head.Item2 + directionY;

            if (newX < 1 || newX > Console.WindowWidth || newY < 1 || newY > Console.WindowHeight || body.Contains(new Tuple<int, int>(newX, newY)))
            {
                isDead = true;
            }
            else
            {
                body.Insert(0, new Tuple<int, int>(newX, newY));
                body.RemoveAt(body.Count - 1);
            }
        }

        public void Draw()
        {
            foreach (var pos in body)
            {
                Console.SetCursorPosition(pos.Item1, pos.Item2);
                Console.Write("█");
            }
        }

        public void ChangeDirection(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.W && directionY != 1)
            {
                directionX = 0;
                directionY = -1;
            }
            else if (key.Key == ConsoleKey.S && directionY != -1)
            {
                directionX = 0;
                directionY = 1;
            }
            else if (key.Key == ConsoleKey.A && directionX != 1)
            {
                directionX = -1;
                directionY = 0;
            }
            else if (key.Key == ConsoleKey.D && directionX != -1)
            {
                directionX = 1;
                directionY = 0;
            }
        }

        public bool CheckCollision(Food food)
        {
            Tuple<int, int> head = GetHead();
            return head.Item1 == food.X && head.Item2 == food.Y;
        }

        public void Grow()
        {
            Tuple<int, int> tail = body[body.Count - 1];
            body.Add(tail);
        }

        private Tuple<int, int> GetHead()
        {
            return body[0];
        }
    }
}
