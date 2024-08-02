using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int c = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        List<Article> list = new List<Article>();
        for (int i = 0; i < c; i++)
        {
            string[] item = Console.ReadLine().Split(" ");
            Article article = new Article(item[0], item[1], Convert.ToInt32(item[2]));
            AddArticle(list, article, Convert.ToInt32(item[2]));
        }
        for (int i = 0; i < p; i++)
        {
            string[] order = Console.ReadLine().Split(" ");
            var item = list.Where(x => x.Name == order[0] && x.Size == order[1] && x.Prices.Count() > 0).FirstOrDefault();
            if(item != null)
            {
                var min = item.Prices.Min();
                Console.WriteLine(min);
                item.Prices.Remove(min);
            }
            else
                Console.WriteLine("NONE");
        }
    }
    
    public static void AddArticle(List<Article> list, Article article, int price)
    {
        var itemExist = list.Where(x => x.Name == article.Name && x.Size == article.Size).FirstOrDefault();
        if(itemExist != null)        
            itemExist.Prices.Add(price);
        else
            list.Add(article);
    }
}

public class Article
{
    public Article(string Name, string Size, int Price)
    {
        this.Name = Name;
        this.Size = Size;
        this.Prices = new List<int>() { Price };
    }
    public string Name { get; set; }
    public string Size { get; set; }
    public List<int> Prices { get; set; }
}