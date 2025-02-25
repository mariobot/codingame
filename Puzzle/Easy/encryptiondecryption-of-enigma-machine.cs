using System;
using System.Linq;
using System.Collections.Generic;

public const string dic = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

string operation = Console.ReadLine();
int RandomNumber = int.Parse(Console.ReadLine());
List<string> rotors = new List<string>();

for (int i = 0; i < 3; i++)
{
    string rotor = Console.ReadLine();
    rotors.Add(rotor);
}

string message = Console.ReadLine();
string R = "";

if(operation == "ENCODE")
{
    R = First(message, RandomNumber);
    R = EncodeRotor(R, rotors[0]);
    R = EncodeRotor(R, rotors[1]);
    R = EncodeRotor(R, rotors[2]);
}
else
{
    R = DecodeRotor(message, rotors[2]);
    R = DecodeRotor(R, rotors[1]);
    R = DecodeRotor(R, rotors[0]);
    R = DecodeLast(R, RandomNumber);
}

Console.WriteLine(R);
    

static string First(string input, int RandomNumber)
{
    string result = "";

    for(int i = 0; i < input.Length; i++)
    {
        int index = dic.IndexOf(input[i]) + RandomNumber + i;
        if(index >= 26)
            index = IndPoss(index);
        result += dic.Substring(index,1);
    }

    return result;
}

static string EncodeRotor(string input, string rotor)
{
    string result = "";

    for(int i = 0; i < input.Length; i++)
    {
        int index = dic.IndexOf(input[i]);
        result += rotor.Substring(index,1);
    }

    return result;
}

static string DecodeRotor(string input, string rotor)
{
    string result = "";

    for(int i = 0; i < input.Length; i++)
    {
        int index = rotor.IndexOf(input[i]);
        result += dic.Substring(index,1);
    }

    return result;
}

static string DecodeLast(string input, int RandomNumber)
{
    string result = "";

    for(int i = 0; i < input.Length; i++)
    {
        int index = dic.IndexOf(input[i]) - RandomNumber - i;
        if(index < 0)            
            index = IndNeg(index);
        if(index >= 26)
            index = IndPoss(index);

        result += dic.Substring(index,1);
    }

    return result;
}

static int IndPoss(int val)
{
    if(val >= 26)
    {
        val = val - 26;

        if(val >= 26)
            val = IndPoss(val);
    }

    return val;
}

static int IndNeg(int val)
{
    if(val < 0)
    {
        val = 26 + val;

        if(val < 0)
            val = IndNeg(val);
    }

    return val;
}