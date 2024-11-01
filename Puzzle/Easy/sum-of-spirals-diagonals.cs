using System;

class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[][] matrix = new int[n][];
        for (int i = 0; i < n; i++)        
            matrix[i] = new int[n];

        FillSpiralMatrix(matrix, n);
        //PrintMatrix(matrix, n);

        Console.WriteLine(SumDiagonals(matrix,n));
    }

    static void FillSpiralMatrix(int[][] matrix, int n)
    {
        int value = 1;
        int top = 0, bottom = n - 1;
        int left = 0, right = n - 1;

        while (top <= bottom && left <= right)
        {
            for (int i = left; i <= right; i++)
                matrix[top][i] = value++;
            top++;

            for (int i = top; i <= bottom; i++)
                matrix[i][right] = value++;
            right--;

            if (top <= bottom)
            {
                for (int i = right; i >= left; i--)
                    matrix[bottom][i] = value++;
                bottom--;
            }

            if (left <= right)
            {
                for (int i = bottom; i >= top; i--)
                    matrix[i][left] = value++;
                left++;
            }
        }
    }

    static void PrintMatrix(int[][] matrix, int n)
    {
        for (int i = 0; i < n; i++)        
            for (int j = 0; j < n; j++)            
                Console.Write(matrix[i][j] + "\t");            
            Console.WriteLine();
    }

    static long SumDiagonals(int[][] matrix, int n)
    {
        long sum = 0;
        int negj = n - 1;
        int negi = 0;
        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if(i == j)
                    sum += matrix[i][j];

                if(i == negi && j == negj)
                {
                    sum += matrix[i][j];
                    negj -=1;
                    negi +=1;
                }
            }
        }

        if(n % 2 != 0)
        {
            int x = n / 2;
            int y = n / 2;
            sum = sum - matrix[x][y];
        }

        return sum;
    }
}