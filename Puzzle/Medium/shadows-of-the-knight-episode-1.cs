using System;

class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]); // width of the building.
        int H = int.Parse(inputs[1]); // height of the building.
        int N = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
        inputs = Console.ReadLine().Split(' ');
        int X0 = int.Parse(inputs[0]);
        int Y0 = int.Parse(inputs[1]);
        int minx = 0;
        int miny = 0;
        int maxx = W - 1;
        int maxy = H - 1;

        // game loop
        while (true)
        {
            string bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)

            if(bombDir.Contains("U"))
            {
                maxy = Y0 - 1;
            }
            else if(bombDir.Contains("D"))
            {
                miny = Y0 + 1;
            }
            
            if(bombDir.Contains("L"))
            {
                maxx = X0 - 1;
            }
            else if(bombDir.Contains("R"))
            {
                minx = X0 + 1;
            }

            X0 = minx + (int)Math.Round((maxx - minx) / 2.0);
            Y0 = miny + (int)Math.Round((maxy - miny) / 2.0);
            
            Console.WriteLine($"{X0} {Y0}");
        }
    }
}