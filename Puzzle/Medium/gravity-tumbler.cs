using System;
using System.Linq;
using System.Collections.Generic;
class S
{
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int width = int.Parse(inputs[0]);
        int height = int.Parse(inputs[1]);
        int count = int.Parse(Console.ReadLine());
        List<string> list = new List<string>();
        Dictionary<string,int> model = new Dictionary<string, int>();
        
        for (int i = 0; i < height; i++)
        {
            string line = Console.ReadLine();
            list.Add(line);
        }
        
        for(int i = 0; i < width; i ++)
        {
            string column = "";
            foreach(string node in list)            
                column += node[i];
            
            int countH = column.ToCharArray().Count(x => x == '#');
            
            if(countH == 0)
                column = new string('.',height);
            else
            {
                int tch = height - countH;
                column = new string('.',tch)+new string('#',countH);
            }

            if(model.ContainsKey(column))            
                model[column] += 1;
            else
                model.Add(column, 1);
        }
        model = OrderModel(model, height);
        int resultCount = count % 2;
        if(resultCount == 1)        
            PrintOdd(model);        
        else
            PrintEven(model, height);
    }
    public static void PrintOdd(Dictionary<string,int> model)
    {
        foreach(KeyValuePair<string, int> vModel in model)
        {
            for(int i = 1; i < vModel.Value+1; i ++)
                Console.WriteLine(vModel.Key);
        }
    }
    public static void PrintEven(Dictionary<string,int> model,int height)
    {
        List<string> list = new List<string>();
        for(int i = 0; i < height; i++)        
            list.Add("");
        foreach(KeyValuePair<string, int> vModel in model)
        {
            for(int i = 0; i < vModel.Value; i ++)
            {
                for(int j = 0; j < height; j++)
                {
                    list[j] += vModel.Key[j];
                }
            }
        }
        for(int i = 0; i < height; i++)        
            Console.WriteLine(list[i]);
    }
    public static Dictionary<string,int> OrderModel(Dictionary<string,int> model, int heigth)
    {
        Dictionary<string,int> OrderModel = new Dictionary<string, int>();
        string zero = new string('.',heigth);
        if(model.ContainsKey(zero))
            OrderModel.Add(zero,model[zero]);
        
        for(int i = 1; i <= heigth; i++)
        {
            int points = heigth - i;
            string r = new string('.',points)+new string('#',i);
            if(model.ContainsKey(r))
                OrderModel.Add(r, model[r]);
        }
        return OrderModel;
    }
}