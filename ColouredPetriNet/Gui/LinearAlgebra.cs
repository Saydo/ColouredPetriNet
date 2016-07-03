using System;
using System.Drawing;

namespace ColouredPetriNet.Gui
{
    public static class LinearAlgebra
    {
        public enum EquationType { Common, ConstX, ConstY, Dot };

        /*
        public struct Equation
        {
            public double k;
            public double b;
            public EquationType type;

            public Equation(Point p1, Point p2)
            {
                if (p1.X == p2.X)
                {
                    if (p1.Y == p2.Y)
                    {
                        type = EquationType.Dot;
                    }
                    else
                    {
                        type = EquationType.ConstX;
                    }
                }
                else if (p1.Y == p2.Y)
                {
                    type = EquationType.ConstY;
                }
                else
                {
                    type = EquationType.Common;
                }
                //k = ;
            }

            public int getY(int x)
            {
                return (int)(k * x + b);
            }

            public int getX(int y)
            {
                return (int)((y - b)/ k);
            }
        }
        */

        static public void GetEquation(Point p1, Point p2, out double k, out double b)
        {
            k = (p1.Y - p2.Y) / (p1.X - p2.X);
            b = p1.Y - k * p1.X;
        }

        static public void GetEquation(int x1, int y1, int x2, int y2, out double k, out double b)
        {
            k = (y1 - y2) / (x1 - x2);
            b = y1 - k * x1;
        }

        static public int InLineByY(Point p, double k, double b)
        {
            return (p.Y - (int)(k * p.X + b));
        }

        static public int InLineByX(Point p, double k, double b)
        {
            return (p.X - (int)((p.Y - b) / k));
        }

        static public int InLineByY(int x, int y, double k, double b)
        {
            return (y - (int)(k * x + b));
        }

        static public int InLineByX(int x, int y, double k, double b)
        {
            return (x - (int)((y - b) / k));
        }

        static public void ExpandLine(Point center, Point p, double extent)
        {
            int dx = center.X - p.X;
            int dy = center.Y - p.Y;
            double scaleFactor = extent / Math.Sqrt(dx * dx + dy * dy);
            p.X += (int)(scaleFactor * dx);
            p.Y += (int)(scaleFactor * dy);
        }

        static public void ResizeLine(Point center, Point p, double length)
        {
            int dx = center.X - p.X;
            int dy = center.Y - p.Y;
            double scaleFactor = length / Math.Sqrt(dx * dx + dy * dy);
            p.X = center.X + (int)(scaleFactor * dx);
            p.Y = center.Y + (int)(scaleFactor * dy);
        }

        static public double GetTriangleCos(double a, double b, double c)
        {
            return (b * b + c * c - a * a) / (2 * b * c);
        }

        static public void ExpandTriangle(Point p1, Point p2, Point p3, int extent)
        {
            double r = GetIncircleRadius(p1, p2, p3);
            Point incenter = GetTriangleIncenter(p1, p2, p3, r, extent);
            double scaleFactor = extent / r;
            p1.X += (int)(scaleFactor * (incenter.X - p1.X));
            p1.Y += (int)(scaleFactor * (incenter.Y - p1.Y));
            p2.X += (int)(scaleFactor * (incenter.X - p2.X));
            p2.Y += (int)(scaleFactor * (incenter.Y - p2.Y));
            p3.X += (int)(scaleFactor * (incenter.X - p3.X));
            p3.Y += (int)(scaleFactor * (incenter.Y - p3.Y));
        }

        static public Point[] GetLineBorder(Point p1, Point p2, int extent)
        {
            Point[] lineBorder = new Point[4];
            for (int i = 0; i < 4; ++i)
            {
                lineBorder[i] = new Point();
            }
            if (((p2.X >= p1.X) && (p2.Y >= p1.Y)) || ((p2.X < p1.X) && (p2.Y < p1.Y)))
            {
                lineBorder[0].X = p1.X - 1;
                lineBorder[1].X = p2.X - 1;
                lineBorder[2].X = p2.X + 1;
                lineBorder[3].X = p1.X + 1;
            }
            else
            {
                lineBorder[0].X = p1.X + 1;
                lineBorder[1].X = p2.X + 1;
                lineBorder[2].X = p2.X - 1;
                lineBorder[3].X = p1.X - 1;
            }
            ResizeLine(p1, lineBorder[0], extent);
            ResizeLine(p1, lineBorder[1], extent);
            ResizeLine(p2, lineBorder[2], extent);
            ResizeLine(p2, lineBorder[3], extent);
            return lineBorder;
        }

        static public int MinX(Point[] points)
        {
            if (points.Length > 0)
            {
                int minValue = points[0].X;
                for (int i = 1; i < points.Length; ++i)
                {
                    if (points[i].X < minValue)
                    {
                        minValue = points[i].X;
                    }
                }
                return minValue;
            }
            return int.MinValue;
        }

        static public int MinY(Point[] points)
        {
            if (points.Length > 0)
            {
                int minValue = points[0].Y;
                for (int i = 1; i < points.Length; ++i)
                {
                    if (points[i].Y < minValue)
                    {
                        minValue = points[i].Y;
                    }
                }
                return minValue;
            }
            return int.MinValue;
        }

        static public int MaxX(Point[] points)
        {
            if (points.Length > 0)
            {
                int maxValue = points[0].X;
                for (int i = 1; i < points.Length; ++i)
                {
                    if (points[i].X > maxValue)
                    {
                        maxValue = points[i].X;
                    }
                }
                return maxValue;
            }
            return int.MinValue;
        }

        static public int MaxY(Point[] points)
        {
            if (points.Length > 0)
            {
                int maxValue = points[0].Y;
                for (int i = 1; i < points.Length; ++i)
                {
                    if (points[i].Y > maxValue)
                    {
                        maxValue = points[i].Y;
                    }
                }
                return maxValue;
            }
            return int.MinValue;
        }

        static public Point GetNormalToLine(Point p1, Point p2, int length, bool overLine = true)
        {
            Point normalPoint = new Point();
            normalPoint.X = p2.X;
            normalPoint.Y = p2.Y;
            double k1, b1, k2, b2;
            GetEquation(p1, p2, out k1, out b1);
            k2 = 1 / k1;
            b2 = normalPoint.X * (k1 - k2) + b1;
            if (((p2.X >= p1.X) && (p2.Y >= p1.Y)) || ((p2.X < p1.X) && (p2.Y < p1.Y)))
            {
                if (overLine)
                {
                    --normalPoint.X;
                }
                else
                {
                    ++normalPoint.X;
                }
            }
            else
            {
                if (overLine)
                {
                    ++normalPoint.X;
                }
                else
                {
                    --normalPoint.X;
                }
            }
            ResizeLine(p2, normalPoint, length);
            return normalPoint;
        }

        static private double GetIncircleRadius(Point p1, Point p2, Point p3)
        {
            double a = Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));
            double b = Math.Sqrt((p3.X - p2.X) * (p3.X - p2.X) + (p3.Y - p2.Y) * (p3.Y - p2.Y));
            double c = Math.Sqrt((p1.X - p3.X) * (p1.X - p3.X) + (p1.Y - p3.Y) * (p1.Y - p3.Y));
            double p = (a + b + c) / 2;
            return Math.Sqrt((p - a) * (p - b) * (p - c) / p);
        }

        static private Point GetTriangleIncenter(Point p1, Point p2, Point p3, double r, int extent)
        {
            Point incenter = new Point();
            double a = Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));
            double b = Math.Sqrt((p3.X - p2.X) * (p3.X - p2.X) + (p3.Y - p2.Y) * (p3.Y - p2.Y));
            double c = Math.Sqrt((p1.X - p3.X) * (p1.X - p3.X) + (p1.Y - p3.Y) * (p1.Y - p3.Y));
            double cosAlpha;
            double beta;
            Point ps1, ps2, ps3;
            if ((a >= b) && (a >= c))
            {
                ps1 = p3;
                ps2 = p1;
                ps3 = p2;
                cosAlpha = GetTriangleCos(a, b, c);
            }
            else if ((b > a) && (b >= c))
            {
                ps1 = p1;
                ps2 = p2;
                ps3 = p3;
                cosAlpha = GetTriangleCos(b, a, c);
            }
            else
            {
                ps1 = p2;
                ps2 = p3;
                ps3 = p1;
                cosAlpha = GetTriangleCos(c, a, b);
            }
            beta = Math.Acos(cosAlpha) * 90 / Math.PI;
            double s1 = (r + extent) / Math.Tan(beta * Math.PI / 180);
            Point nps2 = new Point();
            nps2.X = ps2.X;
            nps2.Y = ps2.Y;
            ResizeLine(ps1, nps2, s1);
            double k1, b1, k2, b2;
            GetEquation(ps1, ps2, out k1, out b1);
            k2 = 1 / k1;
            b2 = nps2.X * (k1 - k2) + b1;
            if (InLineByY(ps3, k1, b1) >= 0)
            {
                incenter.Y = nps2.Y + 1;
            }
            else
            {
                incenter.Y = nps2.Y - 1;
            }
            incenter.X = (int)((incenter.Y - b2) / k2);
            ResizeLine(nps2, incenter, r + extent);
            return incenter;
        }
    }
}
