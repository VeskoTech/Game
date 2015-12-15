using System;
using System.Collections.Generic;

namespace Snake
{
    public class Snake : IDraw
    {
        public Queue<Point> snakeElements = new Queue<Point>();

        public Point Direction { get; set; }
        public Point SnakeHeadPos { get; set; }

        public Snake()
        {
            SnakeHeadPos = new Point(6,0);
            Direction = new Point(1,0);
           
            for (int i = 0; i < 6; i++)
            {
                snakeElements.Enqueue(new Point(i, 0));
            }
            snakeElements.Enqueue(SnakeHeadPos);
        }

        public void DrawSnake()
        {  
            foreach (var point in snakeElements)
            {
                SetDrawPoint(point);
                Console.Write(Constant.SymbolSnake);
            }
        }

        public void move(Point pos)
        {
            snakeElements.Dequeue();
            snakeElements.Enqueue(pos);
        }

        public void SetDrawPoint(Point point)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(point.Xcord, point.Ycord);
        }

        public void Grow(Point head)
        {
            snakeElements.Enqueue(head);
        }

        public bool IsValidHeadSnakePos()
        {
            foreach (var element in snakeElements)
            {
                if (SnakeHeadPos.ToString() == element.ToString())
                {
                    return false;
                }
            }

            if (SnakeHeadPos.Xcord < 0 || SnakeHeadPos.Xcord > Constant.GameFieldWidth)
            {
                return false;
            }

            if (SnakeHeadPos.Ycord < 0 || SnakeHeadPos.Ycord > Constant.GameFieldHight)
            {
                return false;
            }
            return true;
        }
    }

}
