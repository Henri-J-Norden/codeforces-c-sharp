using System;
using System.Collections.Generic;

namespace anatoly_and_cockroaches {
    class Program {
        static void Main(string[] args) {
            List<char> r0 = new List<char>(Convert.ToInt16(Console.ReadLine()));
            foreach (char ch in Console.ReadLine()) {
                roaches.Add(ch);
            }
            int b = Sort(roaches, 'b');
            int r = Sort(roaches, 'r');
            Console.WriteLine(Math.Min(r, b));
            Console.Write("b:" + b + "; r:" + r);
            Console.ReadKey();
        }

        static int Sort(List<char> r, char c) {
            //List<char> n = new List<char>(r.Capacity);
            int ops = 0;
            for (int i = 0; i < r.Capacity; i++) {
                if (r[i] != c) { // not correct
                    int j = i;
                    while (j < r.Capacity) {

                    }
                    ops++;
                    if (i+1 < r.Capacity && r[i+1] == c) { //next also not correct
                        //n.Add(not(c));
                        i++; //skip next
                        continue; //c remains the same
                    }
                } else {
                    //n.Add(c);
                }
                c = not(c);
            }
            
            /*foreach (char ch in n) {
                Console.Write(ch);
            }
            Console.WriteLine();*/
            return ops;
        }

        static char not(char c) {
            if (c == 'b') {
                return 'r';
            } else {
                return 'b';
            }
        }
    }
}
