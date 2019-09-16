using System;
using System.Collections.Generic;

namespace Polycarp_at_the_Radio {
    class Program {
        static void Main(string[] args) {
            string[] a = Console.ReadLine().Split(' ');
            int len = Convert.ToInt32(a[0]);
            int m = Convert.ToInt32(a[1]); //1..m are liked
            List<int> pl = new List<int>();
            Dictionary<int, int> count = new Dictionary<int, int>();
            for (int j = 1; j <= m; j++) {
                count[j] = 0;
            }
            foreach (string s in Console.ReadLine().Split(' ')) {
                int val = Convert.ToInt32(s);
                pl.Add(val);
                try {
                    count[val] += 1;
                } catch (KeyNotFoundException e) {
                    count[val] = 1;
                }
            }
            int min = (int)Math.Floor((double)len / (double)m);
            int i = 0;
            int changes = 0;
            for (int b = 1; b <= m; b++) {
                while (count[b] < min) {
                    if (pl[i] > m || count[pl[i]] > min) {
                        count[pl[i]]--;
                        count[b]++;
                        pl[i] = b;
                        changes++;
                    }
                    i++;
                }
            }
            Console.WriteLine(min + " " + changes);
            Console.WriteLine(String.Join(" ", pl));

        }
    }
}
