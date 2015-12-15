using System;

namespace Snake
{
    public class Point
    {
        private int x;
        private int y;

        public Point(int x, int y)
        {
            this.Xcord = x;
            this.Ycord = y;
        }

        public int Xcord
        {
            get { return this.x; }
            set
            {
                
                this.x = value;
            }
        }

        public int Ycord
        {
            get { return this.y; }
            set
            {
                
                this.y = value;
            }
        }

        public override string ToString()
        {
            return String.Format("[{0},{1}]",this.x,this.y);
        }
    }
}
