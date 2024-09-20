using System;

class Solution
{
    static void Main(string[] args)
    {
        int w = int.Parse(Console.ReadLine());
        int h = int.Parse(Console.ReadLine());
        char[][] table = new char[h][];
        
        for (int i = 0; i < h; i++)
        {
            string line = Console.ReadLine();
            table[i] = line.ToCharArray();
        }
        
        for (int i = 0; i < h; i++)
        {
            for(int j = 0; j < w; j++)
            {
                if(table[i][j] == '.')
                {
                    int iCoord = i;
                    int jCoord = j;

                    int sum = 0;

                    for (int dx = -1; dx <= 1; dx++)
                    {
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            if (dx != 0 || dy != 0)
                            {
                                int newI = iCoord + dx;
                                int newJ = jCoord + dy;

                                if(IsPositionValid(table,newI,newJ))
                                {
                                    if(table[newI][newJ] == 'x')
                                            sum += 1;
                                }   
                            }
                        }
                    }

                    if(sum > 0)
                    {
                        table[i][j] = Convert.ToChar(sum + '0');
                        sum = 0;
                    }

                    /*
                    xCoord-1 yCoord-1
                    xCoord-1 yCoord
                    xCoord-1 yCoord+1

                    xCoord yCoord-1
                    xCoord yCoord
                    xCoord yCoord+1

                    xCoord+1 yCoord-1
                    xCoord+1 yCoord
                    xCoord+1 yCoord+1
                    */
                }
            }
        }

        string finalLine = "";
        for (int i = 0; i < h; i++)
        {
            for(int j = 0; j < w; j++)
            {
                if(table[i][j] == 'x')
                    finalLine += '.';
                else    
                    finalLine += table[i][j];
            }
                
            Console.WriteLine(finalLine);
            finalLine = string.Empty;
        }
    }

    public static bool IsPositionValid(char[][] matrix, int rows, int columns)
    {
        int numRows = matrix.Length;
        int numCols = matrix[0].Length;
        bool state = (columns >= 0 && columns < numCols) && (rows >= 0 && rows < numRows);
        return state;
    }
}