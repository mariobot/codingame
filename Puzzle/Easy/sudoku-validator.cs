using System;
using System.Linq;

class Solution
{
    static void Main(string[] args)
    {
        int[,] matrix = new int[9,9];

        for (int i = 0; i < 9; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            for (int j = 0; j < 9; j++)
            {
                int n = int.Parse(inputs[j]);                
                matrix[i,j] = n;
            }
        }

        var rows = CheckRow(matrix);
        var columns = CheckColumn(matrix);
        var areas = CheckArea(matrix);
        var result = rows && columns && areas;

        Console.WriteLine(result.ToString().ToLower());
    }

    public static bool CheckRow(int[,] matrix)
    {
        int[] line = new int[9];
        bool flag = true;

        for(int i = 0; i < 9; i++)
        {
            for(int j = 0; j < 9; j++)            
                line[j] = matrix[i,j];            

            flag = CheckLine(line);

            if(!flag)
                return false;
        }

        return flag;
    }

    public static bool CheckColumn(int[,] matrix)
    {
        int[] line = new int[9];
        bool flag = true;

        for(int i = 0; i < 9; i++)
        {
            for(int j = 0; j < 9; j++)            
                line[j] = matrix[j,i];            

            flag = CheckLine(line);

            if(!flag)
                return false;
        }

        return flag;
    }

    public static bool CheckArea(int[,] matrix)
    {
        int[] line = new int[9];

        bool flag = true;

        for(int i = 0; i < 9; i = i +3)
        {   
            for(int j = 0; j < 9; j = j+ 3)
            {
                line = new int[9];
                int count = 0;

                for(int k = i; k < i+3; k++ )
                {
                    for(int g = j; g < j+3; g++)
                    {
                        line[count] = matrix[k,g];
                        count += 1;
                    }
                }

                flag = CheckLine(line);

                if(!flag)
                    return false;
            }
        }

        return flag;
    }

    public static bool CheckLine(int[] line)
    {
        bool flag = true;

        for(int i = 1; i <= 9; i++)
        {
            if(!line.Contains(i))
            {
                flag = false;
                break;
            }
        }

        return flag;
    }
}