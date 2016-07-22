using System;
using System.Drawing;

namespace ColouredPetriNet.Container.GraphicsPetriNet.LinearAlgebra
{
    public static class Algorithm
    {
        public static void ExpandLine(Point center, ref Point p, double extent)
        {
            int dx = p.X - center.X;
            int dy = p.Y - center.Y;
            double scaleFactor = extent / Math.Sqrt(dx * dx + dy * dy);
            p.X += (int)(scaleFactor * dx);
            p.Y += (int)(scaleFactor * dy);
        }

        public static void ResizeLine(Point center, ref Point p, double length)
        {
            int dx = p.X - center.X;
            int dy = p.Y - center.Y;
            if ((dx == 0) && (dy == 0))
            {
                return;
            }
            double scaleFactor = length / Math.Sqrt(dx * dx + dy * dy);
            p.X = center.X + (int)(scaleFactor * dx);
            p.Y = center.Y + (int)(scaleFactor * dy);
        }

        public static double GetTriangleCos(double a, double b, double c)
        {
            return (b * b + c * c - a * a) / (2 * b * c);
        }

        public static double GetTriangleOuterRadius(double a, double b, double c)
        {
            double cosAlpha = GetTriangleCos(a, b, c);
            return a / (2 * Math.Sqrt(1 - cosAlpha * cosAlpha));
        }

        public static double GetTriangleOuterRadius(Point p1, Point p2, Point p3)
        {
            double a = Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));
            double b = Math.Sqrt((p3.X - p2.X) * (p3.X - p2.X) + (p3.Y - p2.Y) * (p3.Y - p2.Y));
            double c = Math.Sqrt((p1.X - p3.X) * (p1.X - p3.X) + (p1.Y - p3.Y) * (p1.Y - p3.Y));
            return GetTriangleOuterRadius(a, b, c);
        }

        public static double GetTriangleInnerRadius(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt((p - a) * (p - b) * (p - c) / p);
        }

        public static double GetTriangleInnerRadius(Point p1, Point p2, Point p3)
        {
            double a = Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));
            double b = Math.Sqrt((p3.X - p2.X) * (p3.X - p2.X) + (p3.Y - p2.Y) * (p3.Y - p2.Y));
            double c = Math.Sqrt((p1.X - p3.X) * (p1.X - p3.X) + (p1.Y - p3.Y) * (p1.Y - p3.Y));
            return GetTriangleInnerRadius(a, b, c);
        }

        public static Point GetTriangleOutcenter(Point p1, Point p2, Point p3)
        {
            Equation eq1 = new Equation(p1, p2);
            Equation eq2 = new Equation(p1, p3);
            Point middlePoint1 = new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
            Point middlePoint2 = new Point((p1.X + p3.X) / 2, (p1.Y + p3.Y) / 2);
            Equation eq3 = eq1.GetNormalEquation(middlePoint1);
            Equation eq4 = eq2.GetNormalEquation(middlePoint2);
            return eq3.GetIntersectionPoint(eq4);
        }

        public static Point GetTriangleIncenter(Point p1, Point p2, Point p3)
        {
            double a = Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));
            double b = Math.Sqrt((p3.X - p2.X) * (p3.X - p2.X) + (p3.Y - p2.Y) * (p3.Y - p2.Y));
            double c = Math.Sqrt((p1.X - p3.X) * (p1.X - p3.X) + (p1.Y - p3.Y) * (p1.Y - p3.Y));
            double innerRadius = GetTriangleInnerRadius(a, b, c);
            double cosAlpha = GetTriangleCos(a, b, c);
            double halfAlpha = Math.Asin(Math.Sqrt(1 - cosAlpha * cosAlpha)) / 2;
            double normalSide = innerRadius * Math.Sin(Math.PI / 2 - halfAlpha) / Math.Sin(halfAlpha);
            Point normalPoint = p1;
            ResizeLine(p3, ref normalPoint, normalSide);
            Equation eq1 = new Equation(p1, p3);
            Equation eq2 = eq1.GetNormalEquation(normalPoint);
            return eq2.GetPoint(normalPoint, p2, innerRadius);
        }

        public static void ExpandTriangle(ref Point p1, ref Point p2, ref Point p3, int extent)
        {
            double r = GetTriangleInnerRadius(p1, p2, p3);
            Point incenter = GetTriangleIncenter(p1, p2, p3, r);
            double scaleFactor = extent / r;
            p1.X += (int)(scaleFactor * (p1.X - incenter.X));
            p1.Y += (int)(scaleFactor * (p1.Y - incenter.Y));
            p2.X += (int)(scaleFactor * (p2.X - incenter.X));
            p2.Y += (int)(scaleFactor * (p2.Y - incenter.Y));
            p3.X += (int)(scaleFactor * (p3.X - incenter.X));
            p3.Y += (int)(scaleFactor * (p3.Y - incenter.Y));
        }

        public static Point[] GetLineBorder(Point p1, Point p2, int extent)
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

        public static int MinX(Point[] points)
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

        public static int MinY(Point[] points)
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

        public static int MaxX(Point[] points)
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

        public static int MaxY(Point[] points)
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

        public static Point GetNormalToLine(Point p1, Point p2, int length)
        {
            Equation eq1 = new Equation(p1, p2);
            Equation eq2 = eq1.GetNormalEquation(p2);
            return eq2.GetPoint(p2, length);
        }

        private static Point GetTriangleIncenter(Point p1, Point p2, Point p3, double innerRadius)
        {
            double a = Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));
            double b = Math.Sqrt((p3.X - p2.X) * (p3.X - p2.X) + (p3.Y - p2.Y) * (p3.Y - p2.Y));
            double c = Math.Sqrt((p1.X - p3.X) * (p1.X - p3.X) + (p1.Y - p3.Y) * (p1.Y - p3.Y));
            double cosAlpha = GetTriangleCos(a, b, c);
            double halfAlpha = Math.Asin(Math.Sqrt(1 - cosAlpha * cosAlpha)) / 2;
            double normalSide = innerRadius * Math.Sin(Math.PI / 2 - halfAlpha) / Math.Sin(halfAlpha);
            Point normalPoint = p1;
            ResizeLine(p3, ref normalPoint, normalSide);
            Equation eq1 = new Equation(p1, p3);
            Equation eq2 = eq1.GetNormalEquation(normalPoint);
            return eq2.GetPoint(normalPoint, p2, innerRadius);
        }
    }
}
