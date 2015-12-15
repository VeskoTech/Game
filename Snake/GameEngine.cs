using System;
using System.Threading;


namespace Snake
{
    public class GameEngine
    {
        private static readonly Point Left = new Point(-1, 0);
        private static readonly Point Right = new Point(1, 0);
        private static readonly Point Up = new Point(0, -1);
        private static readonly Point Down = new Point(0, 1);
        private int score;
        private Point currDirection;

        public void Run()
        {
            Console.SetWindowSize(Constant.ConsoleWidth, Constant.ConsoleHeight);
            Console.SetBufferSize(Constant.ConsoleWidth, Constant.ConsoleHeight);

            DrawMenu menu = new DrawMenu(); 
            Snake snake = new Snake();
            snake.DrawSnake(); 
            currDirection = snake.Direction;
         
            Apple apple = new Apple();

            while (true)
            {

                KeyControl(snake);
                
                snake.SnakeHeadPos = new Point(snake.SnakeHeadPos.Xcord + snake.Direction.Xcord , 
                                                snake.SnakeHeadPos.Ycord + snake.Direction.Ycord);
  
                if (!snake.IsValidHeadSnakePos())
                {
                    break;
                }

                if (apple.ApplePos.ToString() == snake.SnakeHeadPos.ToString())
                { 
                    snake.Grow(apple.ApplePos);
                    apple.NewApple(snake);
                    score+=5;
                }

                apple.DrawAplle(apple.ApplePos);

                snake.DrawSnake();
                snake.move(snake.SnakeHeadPos);

                Thread.Sleep(200);
                Console.Clear();

                menu.Menu(score);
            }

            menu.GameOver();
            Console.Read();

        }
        public void KeyControl(Snake snake)
        {
            ConsoleKeyInfo userKey;

            if (Console.KeyAvailable)
            {
                userKey = Console.ReadKey(true);

                switch (userKey.Key)
                {
                    case ConsoleKey.RightArrow:
                        if (currDirection.ToString() != Left.ToString())
                        {
                            snake.Direction = Right;
                            currDirection = Right;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (currDirection.ToString() != Right.ToString())
                        {
                            snake.Direction = Left;
                            currDirection = Left;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (currDirection.ToString() != Down.ToString())
                        {
                            snake.Direction = Up;
                            currDirection = Up;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (currDirection.ToString() != Up.ToString())
                        {
                            snake.Direction = Down;
                            currDirection = Down;
                        }
                        break;
                }
            }
        }
    }
}
