using System;
using System.Linq;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var inputs = Console.ReadLine().Split(' ').Select(Int32.Parse).ToList<int>();
        int r = 0;
        Console.Error.WriteLine(n);
        for (int i = 1; i < n - 1; i++)
            if (inputs[i].CompareTo(inputs[i + 1]) == inputs[i - 1].CompareTo(inputs[i]) || inputs[i] == inputs[i + 1] || inputs[i] == inputs[i - 1])
            {
                inputs.RemoveAt(i);
                i--;
                n--;
            }
        Console.Error.WriteLine(n);
        while(true)
        {
            int max = inputs.IndexOf(inputs.Max());
            var input = inputs.GetRange(max, inputs.Count - max);
            if(max!=inputs.Count-1)
            { 
            int min = input.IndexOf(input.Min());
            if (inputs[max] - input[min] > r)
                r = inputs[max] - input[min];
            inputs.RemoveAt(max);
            inputs.RemoveRange(min+1, inputs.Count - min-1);
            }
            if (inputs.Count <= 2)
                break;
        }
        //for (int i = 1; i < n; i += 2)
        //{
        //    var max = inputs.Zip(inputs.Skip(i), (a, b) => a - b).Max();
        //    Console.Error.WriteLine(i + ":" + r + ":" + max);
        //    if (max > r)
        //    {
        //        r = max;
        //    }
        //    //for(j=0;j<n;j++)
        //    //    if(inputs[j]-inputs.Min()<r)
        //}
        Console.WriteLine(r <= 0 ? "0" : "-{0}", r);
    }
}