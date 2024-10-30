using System;

class Solution
{
    static void Main(string[] args)
    {
        int rows = int.Parse(Console.ReadLine());
        char[][] data = new char[rows][]; 
        string result = "";

        for (int i = 0; i < rows; i++)
        {
            string row = Console.ReadLine().Replace(" ","");
            
            for(int j = 0; j < row.Length; j++)            
                data[i] = row.ToCharArray();
        }
        
        string input = Console.ReadLine();

        foreach(char c in input.ToCharArray())
        {
            Tuple<int, int> search = FindValue(data, c);
            result += search.Item1;
            result += search.Item2;
        }

        Console.WriteLine(result);
    }

    static Tuple<int, int> FindValue(char[][] matrix, char target)
    {
        for (int row = 0; row < matrix.Length; row++)        
            for (int col = 0; col < matrix[row].Length; col++)            
                if (matrix[row][col] == target)                
                    return Tuple.Create(row, col);

        return null;
    }
}