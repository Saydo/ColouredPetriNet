using System;
using System.Drawing;

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

    static public void getEquation(Point p1, Point p2, out double k, out double b)
    {
        k = (p1.Y - p2.Y) / (p1.X - p2.X);
        b = p1.Y - k * p1.X;
    }

    static public void getEquation(int x1, int y1, int x2, int y2, out double k, out double b)
    {
        k = (y1 - y2) / (x1 - x2);
        b = y1 - k * x1;
    }

    static public int inLineByY(Point p, double k, double b)
    {
        return (p.Y - (int)(k * p.X + b));
    }

    static public int inLineByX(Point p, double k, double b)
    {
        return (p.X - (int)((p.Y - b) / k));
    }

    static public int inLineByY(int x, int y, double k, double b)
    {
        return (y - (int)(k * x + b));
    }

    static public int inLineByX(int x, int y, double k, double b)
    {
        return (x - (int)((y - b) / k));
    }

    static public void extentLine(Point center, Point p, double extent)
    {
        int delta_x = center.X - p.X;
        int delta_y = center.Y - p.Y;
        double scale_factor = extent / System.Math.Sqrt(delta_x * delta_x + delta_y * delta_y);
        p.X += (int)(scale_factor * delta_x);
        p.Y += (int)(scale_factor * delta_y);
    }

    static public void resizeLine(Point center, Point p, double length)
    {
        int delta_x = center.X - p.X;
        int delta_y = center.Y - p.Y;
        double scale_factor = length / System.Math.Sqrt(delta_x * delta_x + delta_y * delta_y);
        p.X = center.X + (int)(scale_factor * delta_x);
        p.Y = center.Y + (int)(scale_factor * delta_y);
    }

    static public double triangleCos(double a, double b, double c)
    {
        return (b * b + c * c - a * a) / (double)(2 * b * c);
    }

    static public void expandTriangle(Point p1, Point p2, Point p3, int extent)
    {
        double r = incircleRadius(p1, p2, p3);
        Point incenter = triangleIncenter(p1, p2, p3, r, extent);
        double scale_factor = extent / r;
        p1.X += (int)(scale_factor * (incenter.X - p1.X));
        p1.Y += (int)(scale_factor * (incenter.Y - p1.Y));
        p2.X += (int)(scale_factor * (incenter.X - p2.X));
        p2.Y += (int)(scale_factor * (incenter.Y - p2.Y));
        p3.X += (int)(scale_factor * (incenter.X - p3.X));
        p3.Y += (int)(scale_factor * (incenter.Y - p3.Y));
    }

    static public Point[] getLineBorder(Point p1, Point p2, int extent)
    {
        Point[] line_border = new Point[4];
        for (int i = 0; i < 4; ++i)
        {
            line_border[i] = new Point();
        }
        if (((p2.X >= p1.X) && (p2.Y >= p1.Y)) || ((p2.X < p1.X) && (p2.Y < p1.Y)))
        {
            line_border[0].X = p1.X - 1;
            line_border[1].X = p2.X - 1;
            line_border[2].X = p2.X + 1;
            line_border[3].X = p1.X + 1;
        }
        else
        {
            line_border[0].X = p1.X + 1;
            line_border[1].X = p2.X + 1;
            line_border[2].X = p2.X - 1;
            line_border[3].X = p1.X - 1;
        }
        resizeLine(p1, line_border[0], extent);
        resizeLine(p1, line_border[1], extent);
        resizeLine(p2, line_border[2], extent);
        resizeLine(p2, line_border[3], extent);
        return line_border;
    }

    static public int MinX(Point[] points)
    {
        if (points.Length > 0)
        {
            int min_value = points[0].X;
            for (int i = 1; i < points.Length; ++i)
            {
                if (points[i].X < min_value)
                {
                    min_value = points[i].X;
                }
            }
            return min_value;
        }
        return Int32.MinValue;
    }

    static public int MinY(Point[] points)
    {
        if (points.Length > 0)
        {
            int min_value = points[0].Y;
            for (int i = 1; i < points.Length; ++i)
            {
                if (points[i].Y < min_value)
                {
                    min_value = points[i].Y;
                }
            }
            return min_value;
        }
        return Int32.MinValue;
    }

    static public int MaxX(Point[] points)
    {
        if (points.Length > 0)
        {
            int max_value = points[0].X;
            for (int i = 1; i < points.Length; ++i)
            {
                if (points[i].X > max_value)
                {
                    max_value = points[i].X;
                }
            }
            return max_value;
        }
        return Int32.MinValue;
    }

    static public int MaxY(Point[] points)
    {
        if (points.Length > 0)
        {
            int max_value = points[0].Y;
            for (int i = 1; i < points.Length; ++i)
            {
                if (points[i].Y > max_value)
                {
                    max_value = points[i].Y;
                }
            }
            return max_value;
        }
        return Int32.MinValue;
    }

    static public Point normalToLine(Point p1, Point p2, int length, bool over_line = true)
    {
        Point normal_point = new Point();
        normal_point.X = p2.X;
        normal_point.Y = p2.Y;
        double k1, b1, k2, b2;
        getEquation(p1, p2, out k1, out b1);
        k2 = 1 / k1;
        b2 = normal_point.X * (k1 - k2) + b1;
        if (((p2.X >= p1.X) && (p2.Y >= p1.Y)) || ((p2.X < p1.X) && (p2.Y < p1.Y)))
        {
            if (over_line)
            {
                --normal_point.X;
            }
            else
            {
                ++normal_point.X;
            }
        }
        else
        {
            if (over_line)
            {
                ++normal_point.X;
            }
            else
            {
                --normal_point.X;
            }
        }
        resizeLine(p2, normal_point, length);
        return normal_point;
    }

    static private double incircleRadius(Point p1, Point p2, Point p3)
    {
        double a = Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));
        double b = Math.Sqrt((p3.X - p2.X) * (p3.X - p2.X) + (p3.Y - p2.Y) * (p3.Y - p2.Y));
        double c = Math.Sqrt((p1.X - p3.X) * (p1.X - p3.X) + (p1.Y - p3.Y) * (p1.Y - p3.Y));
        double p = (a + b + c) / 2;
        return Math.Sqrt((p - a)*(p - b)*(p - c)/p);
    }

    static private Point triangleIncenter(Point p1, Point p2, Point p3, double r, int extent)
    {
        Point incenter = new Point();
        double a = Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));
        double b = Math.Sqrt((p3.X - p2.X) * (p3.X - p2.X) + (p3.Y - p2.Y) * (p3.Y - p2.Y));
        double c = Math.Sqrt((p1.X - p3.X) * (p1.X - p3.X) + (p1.Y - p3.Y) * (p1.Y - p3.Y));
        double cos_alpha;
        double beta;
        Point ps1, ps2, ps3;
        if ((a >= b) && (a >= c))
        {
            ps1 = p3;
            ps2 = p1;
            ps3 = p2;
            cos_alpha = triangleCos(a, b, c);
        }
        else if ((b > a) && (b >= c))
        {
            ps1 = p1;
            ps2 = p2;
            ps3 = p3;
            cos_alpha = triangleCos(b, a, c);
        }
        else
        {
            ps1 = p2;
            ps2 = p3;
            ps3 = p1;
            cos_alpha = triangleCos(c, a, b);
        }
        beta = Math.Acos(cos_alpha) * 90 / Math.PI;
        double s1 = (r + extent)/Math.Tan(beta*Math.PI/180);
        Point n_ps2 = new Point();
        n_ps2.X = ps2.X;
        n_ps2.Y = ps2.Y;
        resizeLine(ps1, n_ps2, s1);
        double e_k, e_b, r_k, r_b;
        getEquation(ps1, ps2, out e_k, out e_b);
        r_k = 1 / e_k;
        r_b = n_ps2.X * (e_k - r_k) + e_b;
        if (inLineByY(ps3, e_k, e_b) >= 0)
        {
            incenter.Y = n_ps2.Y + 1;
        }
        else
        {
            incenter.Y = n_ps2.Y - 1;
        }
        incenter.X = (int)((incenter.Y - r_b) / r_k);
        resizeLine(n_ps2, incenter, r + extent);
        return incenter;
    }
}
