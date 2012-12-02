using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;

namespace AlgoVisualization
{
    public class Algorithms
    {
        static int[,] m;
        public static int x, y, x1, y1, x2, y2;
        public static Graphics g;

        public static void Solve(Graphics g ,int x, int y, int x1, int y1, int x2, int y2)
        {
            Algorithms.x = x;
            Algorithms.y = y;
            Algorithms.x1 = x1;
            Algorithms.y1 = y1;
            Algorithms.x2 = x2;
            Algorithms.y2 = y2;
            Algorithms.g = g;
            g.Clear(Color.DarkGray);
            m = new int[x+1, y+1];

            for (int i = 0; i <= x; i++)
                for (int j = 0; j <= y; j++)
                    m[i,j] = -2;

            for (int i = 1; i < x1; i++)
                for (int j = 1; j < y1; j++)
                    m[i,j] = i * j;
            for (int i = 1; i < x2; i++)
                for (int j = 1; j < y2; j++)
                    m[i, j] = i * j;

            m[x1,y1] = 0;
            m[x2,y2] = 0;
            m[y1, x1] = 0;
            m[y2, x2] = 0;

            int anss = ans(x, y, 1, 1);
        }

        static int ans(int a, int b, int w, int h)
        {
            if (m[a, b] != -2)
                ComputingHelper.Visualizate(g, a, b, w, h, m[a,b]);
            if (m[a,b] >= 0)
            {
                return m[a, b]; 
            }
            
            m[a,b] = a * b + 1;
            for (int dx = 1; dx <= a / 2; dx++)
                m[a,b] = Math.Min(m[a,b], ans(dx, b, w, h) + ans(a - dx, b, w + dx, h));
            for (int dy = 1; dy <= b / 2; dy++)
                m[a,b] = Math.Min(m[a,b], ans(a, dy, w, h) + ans(a, b - dy, w, h + dy));
            return m[a, b];
        }
    }
}
