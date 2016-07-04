using System;
using System.Drawing;

namespace ColouredPetriNet.Gui.LinearAlgebra
{
    public static class Algorithm
    {
        static public void ExpandLine(Point center, ref Point p, double extent)
        {
            int dx = center.X - p.X;
            int dy = center.Y - p.Y;
            double scaleFactor = extent / Math.Sqrt(dx * dx + dy * dy);
            p.X += (int)(scaleFactor * dx);
            p.Y += (int)(scaleFactor * dy);
        }

        static public void ResizeLine(Point center, ref Point p, double length)
        {
            int dx = center.X - p.X;
            int dy = center.Y - p.Y;
            if ((dx == 0) && (dy == 0))
            {
                return;
            }
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
            Equation eq1 = new Equation(p1, p2);
            Equation eq2 = eq1.GetNormalEquation(p1);
            Equation eq3 = eq1.GetNormalEquation(p2);
            if (((p2.X >= p1.X) && (p2.Y >= p1.Y)) || ((p2.X < p1.X) && (p2.Y < p1.Y)))
            {
                lineBorder[0] = eq2.GetPoint(p1, -extent);
                lineBorder[1] = eq3.GetPoint(p2, -extent);
                lineBorder[2] = eq3.GetPoint(p2, extent);
                lineBorder[3] = eq2.GetPoint(p1, extent);
            }
            else
            {
                lineBorder[0] = eq2.GetPoint(p1, extent);
                lineBorder[1] = eq3.GetPoint(p2, extent);
                lineBorder[2] = eq3.GetPoint(p2, -extent);
                lineBorder[3] = eq2.GetPoint(p1, -extent);
            }
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

        static public Point GetNormalToLine(Point p1, Point p2, int length)
        {
            Equation eq1 = new Equation(p1, p2);
            Equation eq2 = eq1.GetNormalEquation(p2);
            return eq2.GetPoint(p2, length);
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
            ResizeLine(ps1, ref nps2, s1);
            Equation eq1 = new Equation(ps1, ps2);
            Equation eq2 = eq1.GetNormalEquation(nps2);
            eq2.GetPoint(nps2, r + extent);
            return incenter;
        }
    }
}
