using System;
using System.Text;


string input = Console.ReadLine();
int maxCount = 0;

for(int i = 0; i < input.Length; i++)
{
    if(input[i] == '1')
        continue;
    else
    {
        StringBuilder newInput = new StringBuilder(input);
        newInput[i] = '1'; 

        int count = FindMaxConsecutiveOnes(newInput.ToString());
        if(count > maxCount)
            maxCount = count;
    }
}

Console.WriteLine(maxCount);

public static int FindMaxConsecutiveOnes(string nums)
{
    int maxCount = 0;
    int currentCount = 0;

    foreach (char num in nums)
    {
        if (num == '1')
        {
            currentCount++;
            maxCount = Math.Max(maxCount, currentCount);
        }
        else
        {
            currentCount = 0;
        }
    }

    return maxCount;
}
