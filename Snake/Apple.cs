using System;

namespace Snake
{
    public class Apple : IDraw
    {
        
        private readonly Random gen;
        public Point ApplePos { get; private set; }

        public Apple()
        {
            gen = new Random();
            nextApple();
        }

        public void DrawAplle(Point apple)
        {
            SetDrawPoint(apple);
            Console.WriteLine(Constant.AppleSymbol);
        }
       
        public void NewApple(Snake sn)
        {
            nextApple();

            foreach (var element in sn.snakeElements)
            {
                if (element.ToString() == ApplePos.ToString())
                {
                    nextApple();
                }
            }
            
        }
        public void SetDrawPoint(Point point)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(point.Xcord, point.Ycord);
        }
        private void nextApple()
        {
            ApplePos = new Point(gen.Next(0, (Constant.GameFieldWidth+1)), 
                                    gen.Next(0, (Constant.GameFieldHight+1)));
        }
    }
}
