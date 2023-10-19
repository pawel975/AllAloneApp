
using System;

namespace AllAloneApp
{

    public struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
    static public class Dinglemouse
    {
        static public List<Point> analyzedPoints = new List<Point>();
        static public Point potusCoords = new Point();

        static public void analyzeNearPoints(Point point)
        {
            if (!analyzedPoints.Contains(point))
            {
                analyzedPoints.Add(point);
            }

            Point UpPoint = new Point(point.X, point.Y + 1);
            Point DownPoint = new Point(point.X, point.Y - 1);
            Point LeftPoint = new Point(point.X - 1, point.Y);
            Point RightPoint = new Point(point.X + 1, point.Y);

            List<Point> nearPoints = new List<Point>() { UpPoint, DownPoint, LeftPoint, RightPoint };

            foreach (Point nearPoint in nearPoints)
            {
                if (nearPoint == 'o')
                {

                }
            }
        }

        static public bool AllAlone(char[][] house)
        {
            for (int i = 0; i < house.Length; i++)
            {
                for (int j = 0; j < house[i].Length; j++)
                {
                    if (house[i][j] == '#')
                    {
                        potusCoords.X = i;
                        potusCoords.Y = j;
                    }
                }
            }

            // Your code here
            return false;
        }
    }
}

