using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityHelpers;
using Random = System.Random;

namespace UnityFortuneVoronoi
{
    public abstract class MathTools
    {
        public static double Dist(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }

        public static IList Shuffle(IList S, Random R, bool Copy)
        {
            IList E;
            E = S;
            if (Copy)
            {
                if (S is ICloneable)
                    E = ((ICloneable) S).Clone() as IList;
                else
                    throw new Exception("You want it copied, but it can't!");
            }
            int i, r;
            object Temp;
            for (i = 0; i < E.Count - 1; i++)
            {
                r = i + R.Next(E.Count - i);
                if (r == i)
                    continue;
                Temp = E[i];
                E[i] = E[r];
                E[r] = Temp;
            }
            return E;
        }

        public static void ShuffleIList(IList A, Random R)
        {
            Shuffle(A, R, false);
        }

        public static void ShuffleIList(IList A)
        {
            Shuffle(A, new Random((int) DateTime.Now.Ticks), false);
        }

        public static IList Shuffle(IList A, bool Copy)
        {
            return Shuffle(A, new Random((int) DateTime.Now.Ticks), Copy);
        }

        public static IList Shuffle(IList A)
        {
            return Shuffle(A, new Random((int) DateTime.Now.Ticks), true);
        }

        public static int[] GetIntArrayRange(int A, int B)
        {
            var E = new int[B - A + 1];
            int i;
            for (i = A; i <= B; i++)
                E[i - A] = i;
            return E;
        }

        public static int[] GetIntArrayConst(int A, int n)
        {
            var E = new int[n];
            int i;
            for (i = 0; i < n; i++)
                E[i] = A;
            return E;
        }

        public static int[] GetIntArray(params int[] P)
        {
            return P;
        }

        public static object[] GetArray(params object[] P)
        {
            return P;
        }

        public static Array CopyToArray(ICollection L, Type T)
        {
            var Erg = Array.CreateInstance(T, L.Count);
            L.CopyTo(Erg, 0);
            return Erg;
        }

        public static string[] HighLevelSplit(string S, params char[] C)
        {
            var Erg = new ArrayList();
            var CurrentBracket = new Stack();
            var Pos = 0;
            int i, c;

            for (i = 0; i < S.Length; i++)
            {
                if (S[i] == '(')
                {
                    CurrentBracket.Push(0);
                    continue;
                }
                if (S[i] == '[')
                {
                    CurrentBracket.Push(1);
                    continue;
                }
                if (S[i] == '{')
                {
                    CurrentBracket.Push(2);
                    continue;
                }
                if (S[i] == ')')
                {
                    if ((int) CurrentBracket.Pop() != 0)
                        throw new Exception("Formatfehler!");
                    continue;
                }
                if (S[i] == ']')
                {
                    if ((int) CurrentBracket.Pop() != 1)
                        throw new Exception("Formatfehler!");
                    continue;
                }
                if (S[i] == '}')
                {
                    if ((int) CurrentBracket.Pop() != 2)
                        throw new Exception("Formatfehler!");
                    continue;
                }
                if (CurrentBracket.Count > 0)
                    continue;
                c = Array.IndexOf(C, S[i]);
                if (c != -1)
                {
                    if (C[c] == '\n')
                    {
                        if (i - 2 >= Pos)
                            Erg.Add(S.Substring(Pos, i - Pos - 1));
                        Pos = i + 1;
                    }
                    else
                    {
                        if (i - 1 >= Pos)
                            Erg.Add(S.Substring(Pos, i - Pos));
                        Pos = i + 1;
                    }
                }
            }
            if (CurrentBracket.Count > 0)
                throw new Exception("Formatfehler!");
            if (i - 1 >= Pos)
                Erg.Add(S.Substring(Pos, i - Pos));
            return (string[]) CopyToArray(Erg, typeof(string));
        }

        public static Rect MaxRectangleFit(Rect Target, Vector2 Source)
        {
            float W, H;
            // 1. Auf höhe probieren
            H = Target.height;
            W = Target.height / Source.y * Source.x;
            if (W <= Target.width)
            {
                return new Rect(Target.x + Target.width / 2 - W / 2, Target.y, W, H);
            }
            // 2. Auf weite probieren
            W = Target.width;
            H = Target.width / Source.x * Source.y;
            return new Rect(Target.x, Target.y + Target.height / 2 - H / 2, W, H);
        }

        public static double DASkalar(double[] A, double[] B)
        {
            if (A.Length != B.Length)
                throw new Exception("Error in Skalar!");
            double E = 0;
            int i;
            for (i = 0; i < A.Length; i++)
            {
                E += A[i] * B[i];
            }
            return E;
        }

        public static double[] DAMult(double[] A, double r)
        {
            var E = new double[A.Length];
            int i;
            for (i = 0; i < E.Length; i++)
            {
                E[i] = A[i] * r;
            }
            return E;
        }

        public static double[] DAAdd(double[] A, double[] B)
        {
            if (A.Length != B.Length)
                throw new Exception("Error in Skalar!");
            var E = new double[A.Length];
            int i;
            for (i = 0; i < A.Length; i++)
            {
                E[i] += A[i] + B[i];
            }
            return E;
        }

        public static double DADist(double[] A, double[] B)
        {
            if (A.Length != B.Length)
                throw new Exception("Unterschiedliche Längen!");
            int i;
            double E = 0;
            for (i = 0; i < A.Length; i++)
                E += (A[i] - B[i]) * (A[i] - B[i]);
            return E;
        }

        public static double DASum(double[] A)
        {
            double Erg = 0;
            foreach (var D in A)
            {
                Erg += D;
            }
            return Erg;
        }

        public static double DAMean(double[] A)
        {
            return DASum(A) / A.Length;
        }

        public static double DAStdv(double[] A, double M)
        {
            double Erg = 0;
            foreach (var D in A)
                Erg += (M - D) * (M - D);
            return Erg / A.Length;
        }

        private static int doubleToInt(double f)
        {
            if (f >= 2.147484E+09f)
            {
                return 2147483647;
            }
            if (f <= -2.147484E+09f)
            {
                return -2147483648;
            }
            return ((int) f);
        }

        /* 0: minimum, +: rising, -: falling, 1: maximum. */

        private static readonly char[][] HSB_map = new char[6][]
        {
            new[]
            {
                '1',
                '+',
                '0'
            },
            new[]
            {
                '-',
                '1',
                '0'
            },
            new[]
            {
                '0',
                '1',
                '+'
            },
            new[]
            {
                '0',
                '-',
                '1'
            },
            new[]
            {
                '+',
                '0',
                '1'
            },
            new[]
            {
                '1',
                '0',
                '-'
            }
        };

        public static double[] HSBtoRGB(int hue, int saturation, int brightness, double[] OldCol)
        {
            /* Clip hue at 360: */
            if (hue < 0)
                hue = 360 - (-hue % 360);
            hue = hue % 360;

            int i = (int) Math.Floor(hue / 60.0), j;
            double[] C;
            if (OldCol == null || OldCol.Length != 3)
                C = new double[3];
            else
                C = OldCol;

            var min = 127.0 * (240.0 - saturation) / 240.0;
            var max = 255.0 - 127.0 * (240.0 - saturation) / 240.0;
            if (brightness > 120)
            {
                min = min + (255.0 - min) * (brightness - 120) / 120.0;
                max = max + (255.0 - max) * (brightness - 120) / 120.0;
            }
            if (brightness < 120)
            {
                min = min * brightness / 120.0;
                max = max * brightness / 120.0;
            }

            for (j = 0; j < 3; j++)
            {
                switch (HSB_map[i][j])
                {
                    case '0':
                        C[j] = min;
                        break;
                    case '1':
                        C[j] = max;
                        break;
                    case '+':
                        C[j] = (min + (hue % 60) / 60.0 * (max - min));
                        break;
                    case '-':
                        C[j] = (max - (hue % 60) / 60.0 * (max - min));
                        break;
                }
            }
            return C;
        }

        public static Color HSBtoRGB(int hue, int saturation, int brightness)
        {
            var C = HSBtoRGB(hue, saturation, brightness, null);
            return new Color((int) C[0], (int) C[1], (int) C[2]);
        }

        public static double GetAngle(double x, double y)
        {
            if (x == 0)
            {
                if (y > 0)
                    return Math.PI / 2.0;
                if (y == 0)
                    return 0;
                if (y < 0)
                    return Math.PI * 3.0 / 2.0;
            }
            var atan = Math.Atan(y / x);
            if (x > 0 && y >= 0)
                return atan;
            if (x > 0 && y < 0)
                return 2 * Math.PI + atan;
            return Math.PI + atan;
        }

        public static double GetAngleTheta(double x, double y)
        {
            double dx, dy, ax, ay;
            double t;
            dx = x;
            ax = Math.Abs(dx);
            dy = y;
            ay = Math.Abs(dy);
            t = (ax + ay == 0) ? 0 : dy / (ax + ay);
            if (dx < 0) t = 2 - t;
            else if (dy < 0) t = 4 + t;
            return t * 90.0;
        }

        public static int ccw(Point P0, Point P1, Point P2, bool PlusOneOnZeroDegrees)
        {
            int dx1, dx2, dy1, dy2;
            dx1 = P1.x - P0.x;
            dy1 = P1.y - P0.y;
            dx2 = P2.x - P0.x;
            dy2 = P2.y - P0.y;
            if (dx1 * dy2 > dy1 * dx2) return +1;
            if (dx1 * dy2 < dy1 * dx2) return -1;
            if ((dx1 * dx2 < 0) || (dy1 * dy2 < 0)) return -1;
            if ((dx1 * dx1 + dy1 * dy1) < (dx2 * dx2 + dy2 * dy2) && PlusOneOnZeroDegrees)
                return +1;
            return 0;
        }

        public static int ccw(double P0x, double P0y, double P1x, double P1y, double P2x, double P2y, bool PlusOneOnZeroDegrees)
        {
            double dx1, dx2, dy1, dy2;
            dx1 = P1x - P0x;
            dy1 = P1y - P0y;
            dx2 = P2x - P0x;
            dy2 = P2y - P0y;
            if (dx1 * dy2 > dy1 * dx2) return +1;
            if (dx1 * dy2 < dy1 * dx2) return -1;
            if ((dx1 * dx2 < 0) || (dy1 * dy2 < 0)) return -1;
            if ((dx1 * dx1 + dy1 * dy1) < (dx2 * dx2 + dy2 * dy2) && PlusOneOnZeroDegrees)
                return +1;
            return 0;
        }

        public static bool intersect(Point P11, Point P12, Point P21, Point P22)
        {
            return ccw(P11, P12, P21, true) * ccw(P11, P12, P22, true) <= 0
                   && ccw(P21, P22, P11, true) * ccw(P21, P22, P12, true) <= 0;
        }

        public static Vector2 IntersectionPoint(Point P11, Point P12, Point P21, Point P22)
        {
            double Kx = P11.x, Ky = P11.y, Mx = P21.x, My = P21.y;
            double Lx = (P12.x - P11.x), Ly = (P12.y - P11.y), Nx = (P22.x - P21.x), Ny = (P22.y - P21.y);
            double a = double.NaN, b = double.NaN;
            if (Lx == 0)
            {
                if (Nx == 0)
                    throw new Exception("No intersect!");
                b = (Kx - Mx) / Nx;
            }
            else if (Ly == 0)
            {
                if (Ny == 0)
                    throw new Exception("No intersect!");
                b = (Ky - My) / Ny;
            }
            else if (Nx == 0)
            {
                if (Lx == 0)
                    throw new Exception("No intersect!");
                a = (Mx - Kx) / Lx;
            }
            else if (Ny == 0)
            {
                if (Ly == 0)
                    throw new Exception("No intersect!");
                a = (My - Ky) / Ly;
            }
            else
            {
                b = (Ky + Mx * Ly / Lx - Kx * Ly / Lx - My) / (Ny - Nx * Ly / Lx);
            }
            if (!double.IsNaN(a))
            {
                return new Vector2((float) (Kx + a * Lx), (float) (Ky + a * Ly));
            }
            if (!double.IsNaN(b))
            {
                return new Vector2((float) (Mx + b * Nx), (float) (My + b * Ny));
            }
            throw new Exception("Error in IntersectionPoint");
        }
    }
}