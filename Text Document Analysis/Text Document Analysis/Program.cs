using System;

namespace Text_Document_Analysis {
    class Program {
        static void Main(string[] args) {
            Console.ReadLine();
            int pCount = 0;
            int maxLen = 0;
            int len = 0;
            bool p = false;
            foreach (char c in Console.ReadLine()) {
                if (c != '_' && c != '(' && c != ')') {
                    len++;
                } else if (len != 0) {
                    if (p) { //in parentheses
                        len = 0;
                        pCount++;
                    } else {
                        maxLen = Math.Max(len, maxLen);
                        len = 0;
                    }
                }
                if (c == '(' || c == ')') {
                    p = !p;
                }
            }
            if (len != 0) {
                if (p) { //in parentheses
                    len = 0;
                    pCount++;
                } else {
                    maxLen = Math.Max(len, maxLen);
                    len = 0;
                }
            }
            Console.Write(maxLen + " " + pCount);
        }
    }
}
