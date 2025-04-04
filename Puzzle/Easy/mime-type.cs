using System;
using System.Linq;
using System.Collections.Generic;


int N = int.Parse(Console.ReadLine());
int Q = int.Parse(Console.ReadLine());
Dictionary<string, string> mimeTypes = new Dictionary<string, string>();

for (int i = 0; i < N; i++)
{
    string[] inputs = Console.ReadLine().Split(' ');
    string extension = inputs[0].ToLower();
    string mimeType = inputs[1];
    if (!mimeTypes.ContainsKey(extension))
    {
        mimeTypes.Add(extension, mimeType);
    }
}

for (int i = 0; i < Q; i++)
{
    string fileName = Console.ReadLine();
    string[] fileParts = fileName.Split('.');
    string extension = fileParts.Length >= 2 ? fileParts.Last().ToLower() : "empty";
    if (mimeTypes.TryGetValue(extension, out string mimeType))
    {
        Console.WriteLine(mimeType);
    }
    else
    {
        Console.WriteLine("UNKNOWN");
    }
}