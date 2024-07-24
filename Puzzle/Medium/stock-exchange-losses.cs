using System;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string[] inputs = Console.ReadLine().Split(' ');
        StockHistory stockHistory = new StockHistory();
        
        for (int f = 0; f < n; f++)
        {
            int v = int.Parse(inputs[f]);
            stockHistory.addNumber(v);
        }
        
       Console.WriteLine(stockHistory.biggestLoss);
    }

    public class StockHistory
    {
        public List<int> historyValues { get; set; }
        public int lastMaximum { get; set; }
        public int biggestLoss { get; set; }

        public StockHistory()
        {
            this.historyValues = new List<int>();
		    this.biggestLoss = 0;
		    this.lastMaximum = int.MinValue;
        }

        public int getCurrentLostWith(int addNumber)
        {
            return addNumber - this.lastMaximum;
        }

        public void recordMaximunIfReched(int addNumber)
        {
            if(addNumber > this.lastMaximum)
                this.lastMaximum = addNumber;
        }

        public void addNumber(int addNumber)
        {
            this.historyValues.Add(addNumber);
            this.recordMaximunIfReched(addNumber);

            var newLoss = this.getCurrentLostWith(addNumber);
            if(newLoss < this.biggestLoss)
                this.biggestLoss = newLoss;
        }

        public int getLength()
        {
            return this.historyValues.Count-1;
        }
    }   
}