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
        static List<int> FindMaxDifferences(IList<int> elements)
        {
            List<int> longestSeq = new List<int>();
            List<int> maxDiffs = new List<int>();

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
                    //New prepared sequence is having greater count than 0
                    if (longestSeq.Count() > 0)
                        maxDiffs.Add(longestSeq.Last() - longestSeq.First());                   
                    longestSeq.Clear();
                }

            }
            return maxDiffs;    //return the highest sub sequence list
        }
       
        static void Main(string[] args)
        {
            int[] arrPrices = { 7, 1, 5, 3, 6, 4 };   
            
            var totalProfit = FindMaxDifferences(arrPrices.ToList()).Sum(x => x);   
            
            Console.WriteLine($"Best profit : {totalProfit}");
        }
    }
}
