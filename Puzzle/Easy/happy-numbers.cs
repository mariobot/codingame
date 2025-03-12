using System;
using System.Collections.Generic;
using System.Numerics;


int N = int.Parse(Console.ReadLine());
for (int i = 0; i < N; i++)
{
    string x = Console.ReadLine();
    if(IsHappy(BigInteger.Parse(x)))
        Console.WriteLine($"{x} :)");
    else
        Console.WriteLine($"{x} :(");
}
    
static bool IsHappy(BigInteger number)
{
    HashSet<BigInteger> seenNumbers = new HashSet<BigInteger>();

    while (number != 1 && !seenNumbers.Contains(number))
    {
        seenNumbers.Add(number);
        number = SumOfSquaresOfDigits(number);
    }

    return number == 1;
}

static BigInteger SumOfSquaresOfDigits(BigInteger number)
{
    BigInteger sum = 0;

    while (number > 0)
    {
        BigInteger digit = number % 10;
        sum += digit * digit;
        number /= 10;
    }

    return sum;
}