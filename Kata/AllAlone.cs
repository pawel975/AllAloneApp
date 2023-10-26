
using System;

namespace AllAloneApp
{

    class Program
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

        static public List<Point> analyzedPoints = new List<Point>();
        static public Point potusCoords = new Point();
        static public bool isPotusAlone = true;
        static public bool isSearchEnded = false;

        static public void analyzeNearPoints(Point point, char[][] house)
        {
            Console.WriteLine("Start of analyze function");

            if (!isSearchEnded)
            {
                // Checks if point was already analyzed
                if (!analyzedPoints.Contains(point))
                {
                    analyzedPoints.Add(point);

                    Point UpPoint = new Point(point.X, point.Y + 1);
                    Point DownPoint = new Point(point.X, point.Y - 1);
                    Point LeftPoint = new Point(point.X - 1, point.Y);
                    Point RightPoint = new Point(point.X + 1, point.Y);

                    List<Point> nearPoints = new List<Point>() { UpPoint, DownPoint, LeftPoint, RightPoint };

                    foreach (Point nearPoint in nearPoints)
                    {
                        if (analyzedPoints.Contains(nearPoint)) break;

                        var nearPointElement = house[nearPoint.X][nearPoint.Y];

                        if (nearPointElement == 'o')
                        {
                            isSearchEnded = true;
                            isPotusAlone = false;
                            break;
                        }
                        else if (nearPointElement == '#')
                        {
                            analyzedPoints.Add(nearPoint);
                        }
                        else
                        {
                            analyzeNearPoints(nearPoint, house);
                        }
                    }
                }
            }

            Console.WriteLine("End of analyze function");
        }

        static public bool AllAlone(char[][] house)
        {
            // Search for Potus in array
            for (int i = 0; i < house.Length; i++)
            {
                for (int j = 0; j < house[i].Length; j++)
                {
                    if (house[i][j] == 'X')
                    {
                        potusCoords.X = i;
                        potusCoords.Y = j;
                    }
                }
            }

            // Start to search for elfes starting with Potus location
            analyzeNearPoints(potusCoords, house);

            Console.WriteLine("End of program");

            return isPotusAlone;
        }


        public void Main(string[] args)
        {
            char[][] house = {
            "  o                o        #######".ToCharArray(),
            "###############             #     #".ToCharArray(),
            "#             #        o    #     #".ToCharArray(),
            "#  X          ###############     #".ToCharArray(),
            "#                                 #".ToCharArray(),
            "###################################".ToCharArray()};

            AllAlone(house);
        }
    }
}

