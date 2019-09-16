using System;
using System.Collections.Generic;

namespace Lakes_in_Berland {
    class Program {
        static void Main(string[] args) {
            int x, y, lakes;
            string[] s = Console.ReadLine().Split(' ');
            y = Convert.ToInt32(s[0]);
            x = Convert.ToInt32(s[1]);
            lakes = Convert.ToInt32(s[2]);
            List<char[]> map = new List<char[]>();
            for (int i = 0; i < y; i++) {
                map.Add(Console.ReadLine().ToCharArray());
            }
            List<List<List<int>>> l = new List<List<List<int>>>();
            List<List<int>> known = new List<List<int>>();
            for (int y_ = 0; y_ < y; y_++) {
                for (int x_=0; x_<x; x_++) {
                    if (map[y_][x_] == '.') { //look for lake
                        bool valid = true;
                        foreach (List<int> coord in known) {
                            if (coord[0] == x_ && coord[1] == y_) {
                                valid = false;
                                break;
                            }
                        }
                        if (!valid) {
                            continue;
                        }
                        List<List<int>> lake = new List<List<int>>();
                        lake.Add(new List<int> { 1, 1 });
                        List<List<int>> coords = getLake(x_, y_, map, lake);
                        if (coords[0][0] == 0) { //is ocean
                            for (int i = 1; i<coords.Count; i++) {
                                known.Add(coords[i]);
                            }
                        } else {
                            coords.RemoveAt(0);
                            for (int i = 0; i < coords.Count; i++) {
                                known.Add(coords[i]);
                            }
                            l.Add(coords);
                        }
                    }
                }
            }
            //determine which lakes to remove
            List<List<List<int>>> remove = new List<List<List<int>>>();
            int fill = 0;
            while (l.Count > lakes) {
                int iMin = 0;
                for (int i = 1; i < l.Count; i++) {
                    if (l[i].Count < l[iMin].Count) {
                        iMin = i;
                    }
                }
                fill += l[iMin].Count;
                remove.Add(l[iMin]);
                l.RemoveAt(iMin);
            }
            //remove lakes
            foreach (List<List<int>> lake in remove) {
                foreach (List<int> coord in lake) {
                    map[coord[1]][coord[0]] = '*';
                }
            }
            //output
            Console.WriteLine(fill);
            foreach(char[] line in map) {
                Console.WriteLine(String.Join("", line));
            }
            //Console.ReadKey();

        }

        static List<List<int>> getLake(int x, int y, List<char[]> map, List<List<int>> lake) {
            if (x == 0 || y == 0 || y == map.Count-1 || x == map[0].Length-1) {
                lake[0] = new List<int> { 0, 0 };
            }
            lake.Add(new List<int> { x, y });
            /*foreach (List<int> coord in lake) {
                Console.Write(coord[0] + ":" + coord[1] + ";");
            }
            Console.WriteLine();
            Console.ReadKey();*/
            for (int o = -1; o < 2; o += 2) {
                if (x + o >= 0 && x + o < map[0].Length && map[y][x + o] == '.') {
                    bool valid = true;
                    foreach (List<int> coord in lake) {
                        if (coord[0] == x + o && coord[1] == y) {
                            valid = false;
                            break;
                        }
                    }
                    if (valid) {
                        lake = getLake(x + o, y, map, lake);
                    }
                }
                if (y + o >= 0 && y + o < map.Count && map[y+o][x] == '.') {
                    bool valid = true;
                    foreach (List<int> coord in lake) {
                        if (coord[0] == x && coord[1] == y + o) {
                            valid = false;
                            break;
                        }
                    }
                    if (valid) {
                        lake = getLake(x, y + o, map, lake);
                    }
                }
            }
            return lake;
        }

    }
}

