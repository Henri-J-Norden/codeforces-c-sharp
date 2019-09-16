using System;
using System.Collections.Generic;

namespace The_New_Year___Meeting_Friends {
    class Program {
        static void Main(string[] args) {
            List<int> houses = new List<int>();
            foreach (string s in Console.ReadLine().Split(' ')) {
                houses.Add(Convert.ToInt32(s));
            }
            houses.Sort();
            int mid = houses[1];
            Console.Write(Math.Abs(mid-houses[0])+Math.Abs(mid-houses[2]));
        }
    }
}
