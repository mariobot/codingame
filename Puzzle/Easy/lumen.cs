using System;

int N = int.Parse(Console.ReadLine());
int L = int.Parse(Console.ReadLine());
char[][] table = new char[N][];        

for (int i = 0; i < N; i++)
{
    string[] inputs = Console.ReadLine().Split(' ');
    char[] chars = new char[N];
    for (int j = 0; j < N; j++)
    {
        string cell = inputs[j];
        chars[j] = Convert.ToChar(cell);
    }
    table[i] = chars;
}

for (int i = 0; i < N; i++)
{
    for (int j = 0; j < N; j++)
    {
        if(table[i][j] == 'C')
        {
            int iCoord = i;
            int jCoord = j;
            int deep = L - 1;

            for (int dx = -deep; dx <= deep; dx++)
            {
                for (int dy = -deep; dy <= deep; dy++)
                {
                    if (dx != 0 || dy != 0)
                    {
                        int newI = iCoord + dx;
                        int newJ = jCoord + dy;

                        if(IsPositionValid(table,newI,newJ))
                        {
                            if(table[newI][newJ] != 'C')
                                table[newI][newJ] = '_';
                        }
                    }
                }
            }
        }
    }
}

int sum = 0;
for (int i = 0; i < N; i++)
{
    for (int j = 0; j < N; j++)            
        if(table[i][j] == 'X')
            sum += 1;
}

Console.WriteLine(sum);

public static bool IsPositionValid(char[][] matrix, int rows, int columns)
{
    int numRows = matrix.Length;
    int numCols = matrix[0].Length;
    bool state = (columns >= 0 && columns < numCols) && (rows >= 0 && rows < numRows);
    return state;
}