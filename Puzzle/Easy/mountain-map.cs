using System;
using System.Linq;

class Mountains
{
    static void Main(string[] args)
    {
        // Read the number of mountains
        int n = int.Parse(Console.ReadLine().Trim());
        
        // Read the heights of the mountains
        string[] inputHeights = Console.ReadLine().Trim().Split(' ');
        int[] heights = Array.ConvertAll(inputHeights, int.Parse);
        var (maxH, index) = heights.Select((n, i) => (n, i)).Max();
        
        PrintMountains(n, heights, maxH);
    }
    
    static void PrintMountains(int n, int[] heights, int maxH)
    {
        int maxHeight = maxH;
        
        int width = 0;
        foreach (int height in heights)        
            width += 2 * height;                    

        char[,] grid = new char[maxHeight, width];
        
        // Initialize grid with spaces
        for (int i = 0; i < maxHeight; i++)
        {
            for (int j = 0; j < width; j++)            
                grid[i, j] = ' ';
        }
        
        int currentPos = 0;

        for (int i = 0; i < n; i++)
        {
            int height = heights[i];

            // Draw the rising part of the mountain
            for (int j = 0; j < height; j++)
            {
                grid[maxHeight - 1 - j, currentPos + j] = '/';
            }

            currentPos += height;

            // Draw the falling part of the mountain
            for (int j = 0; j < height; j++)
            {
                grid[maxHeight - height + j, currentPos + j] = '\\';
            }

            currentPos += height;
        }
        
        // Print the grid without trailing spaces
        string line = "";
        
        for (int i = 0; i < maxHeight; i++)
        {
            line = "";
            for (int j = 0; j < width; j++)
            {
                line += grid[i, j];
            }
            Console.WriteLine(line.TrimEnd());
        }
    }
}
