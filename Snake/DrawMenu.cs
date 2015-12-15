using System;

namespace Snake
{
    public class DrawMenu : IDraw
    {
        private readonly Point drawMenuPoint = new Point(0,20);

        public void Menu(int score)
        {
            SetDrawPoint(drawMenuPoint);
            Console.WriteLine(new string('=',Constant.ConsoleWidth));
            SetDrawPoint(new Point(1,21));
            Console.WriteLine("Score: {0}",score);
        }
            
        public void SetDrawPoint(Point point)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(point.Xcord, point.Ycord);
        }

        public void GameOver()
        {
            SetDrawPoint(new Point(18,9));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GameOver !");
        }
    }
}
