using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int w = int.Parse(inputs[0]);
        int h = int.Parse(inputs[1]);
        List<char> listLSB = new List<char>();
        
        for (int i = 0; i < h; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            for (int j = 0; j < w; j++)
            {
                int pixel = int.Parse(inputs[j]);
                string binaryString = Convert.ToString(pixel, 2).PadLeft(8, '0');
                listLSB.Add(binaryString.LastOrDefault());
            }
        }

        var LSB = GetBytesFromBinaryString(string.Join("",listLSB));
        var result = Encoding.ASCII.GetString(LSB);

        Console.WriteLine(result);
    }

    public static Byte[] GetBytesFromBinaryString(String binary)
    {
        var list = new List<Byte>();

        for (int i = 0; i < binary.Length; i += 8)
        {
            String t = binary.Substring(i, 8);

            list.Add(Convert.ToByte(t, 2));
        }

        return list.ToArray();
    }
}