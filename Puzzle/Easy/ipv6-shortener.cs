using System;

class Solution
{
     static void Main()
    {
        string ip = Console.ReadLine();
        string finalIp = TransformIPv6(ip);
        Console.WriteLine(finalIp);
    }

    static string TransformIPv6(string ip)
    {
        string[] blocks = ip.Split(':');
        
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i] = blocks[i].TrimStart('0');
            if (blocks[i] == string.Empty)            
                blocks[i] = "0";
        }
        
        int mZeroSeqL = 0;
        int mZeroSeqI = -1;
        int currentZero = 0;
        int currentZeroIndex = -1;

        for (int i = 0; i < blocks.Length; i++)
        {
            if (blocks[i] == "0")
            {
                if (currentZero == 0)                
                    currentZeroIndex = i;
                currentZero++;
            }
            else
            {
                if (currentZero > mZeroSeqL)
                {
                    mZeroSeqL = currentZero;
                    mZeroSeqI = currentZeroIndex;
                }
                currentZero = 0;
            }
        }
        
        if (currentZero > mZeroSeqL)
        {
            mZeroSeqL = currentZero;
            mZeroSeqI = currentZeroIndex;
        }

        // Replace the longest sequence of zero blocks with ::
        if (mZeroSeqL > 1)
        {
            string[] newBlocks = new string[blocks.Length - mZeroSeqL + 1];
            Array.Copy(blocks, 0, newBlocks, 0, mZeroSeqI);
            newBlocks[mZeroSeqI] = string.Empty;
            Array.Copy(blocks, mZeroSeqI + mZeroSeqL, newBlocks, mZeroSeqI + 1, blocks.Length - mZeroSeqI - mZeroSeqL);
            blocks = newBlocks;
        }
        
        string compressedIp = string.Join(":", blocks);

        if (compressedIp.StartsWith(":"))        
            compressedIp = ":" + compressedIp;
        
        if (compressedIp.EndsWith(":"))
            compressedIp += ":";

        return compressedIp;
    }
}