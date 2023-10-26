
namespace AllAloneConsole
{
    class Program
    {
        public struct Point
        {
            public Point(int y, int x)
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

            if (!isSearchEnded)
            {
                // Checks if point was already analyzed
                if (!analyzedPoints.Contains(point))
                {
                    analyzedPoints.Add(point);

                    Point UpPoint = new Point(point.Y + 1, point.X);
                    Point DownPoint = new Point(point.Y - 1, point.X);
                    Point LeftPoint = new Point(point.Y, point.X - 1);
                    Point RightPoint = new Point(point.Y, point.X + 1);

                    List<Point> nearPoints = new List<Point>() { UpPoint, DownPoint, LeftPoint, RightPoint };

                    foreach (Point nearPoint in nearPoints)
                    {
                        if (analyzedPoints.Contains(nearPoint)) break;

                        var nearPointElement = house[nearPoint.X][nearPoint.Y];

                        Console.WriteLine($"Coords {nearPoint.X}, {nearPoint.Y} {nearPointElement}");

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

        }

        static public bool AllAlone(char[][] house)
        {
            // Search for Potus in array
            for (int i = 0; i < house.Length; i++)
            {
                for (int j = 0; j < house[i].Length; j++)
                {
                    if (house[j][i] == 'X')
                    {
                        potusCoords.X = j;
                        potusCoords.Y = i;
                        Console.WriteLine($"Potus {i - 1},{j}");
                        Console.WriteLine(house[i]);


                    }
                }
            }

            // Start to search for elfes starting with Potus location
            analyzeNearPoints(potusCoords, house);

            Console.WriteLine("End of program");

            Console.WriteLine(isPotusAlone);
            return isPotusAlone;

        }


        static public void Main(string[] args)
        {
            char[][] house = {
            "  o                o        #######".ToCharArray(),
            "###############             #     #".ToCharArray(),
            "#             #        o    #  o  #".ToCharArray(),
            "#  X          ###############     #".ToCharArray(),
            "#                                 #".ToCharArray(),
            "###################################".ToCharArray()};

            AllAlone(house);
        }
    }
}

