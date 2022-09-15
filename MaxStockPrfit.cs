using System;
using System.Linq;
using System.Collections.Generic;

namespace TestStock
{
    class TestStock
    {
        /// <summary>
        /// Read all sub arrays of continues increase
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        static List<List<int>> FindIncreasingSequences(IList<int> elements)
        {
            List<int> longestSeq = new List<int>();
            List<List<int>> LongestSubSeqs = new List<List<int>>();

            for (var i = 0; i < elements.Count; i++)
            {
                //traverse the sequence until last element to find the longest sub-sequence
                if (i != elements.Count - 1 && elements[i + 1] > elements[i])
                {
                    //Prepare sub sequence list
                    if (longestSeq.Count == 0)
                        longestSeq.Add(elements[i]);
                    longestSeq.Add(elements[i + 1]);
                }
                else
                {
                    //New prepared sequence is having greater count than existing count
                    if (longestSeq.Count() > 0)                   
                        LongestSubSeqs.Add(longestSeq.ToList());                   
                    longestSeq.Clear();
                }

            }
            return LongestSubSeqs;    //return the highest sub sequence list
        }
        static int CalcDiff(int[] stocks)
        {  
            return stocks[stocks.Length - 1] - stocks[0];
        }
        static void Main(string[] args)
        {
            int[] arrPrices = { 7, 1, 5, 3, 6, 4 };   
            
            var totalProfit = FindIncreasingSequences(arrPrices.ToList()).Sum(x => CalcDiff(x.ToArray()));   
            
            Console.WriteLine($"Best profit : {totalProfit}");
        }
    }
}
