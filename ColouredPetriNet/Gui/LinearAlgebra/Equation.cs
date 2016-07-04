using System;
using System.Drawing;

namespace ColouredPetriNet.Gui.LinearAlgebra
{
    public enum EquationType { Common, ConstX, ConstY, Dot };

    [Flags]
    public enum PositionOnTheLine
    {
        InLine = 0, // 000
        OutLine = 7, // 111
        High = 7, // 111
        Low = 6, // 110
        Left = 5, // 101
        Right = 7, // 111
    }

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
                    k = p1.X;
                    b = p1.Y;
                }
                else
                {
                    type = EquationType.ConstX;
                    k = p1.X;
                    b = 0;
                }
            }
            else if (p1.Y == p2.Y)
            {
                type = EquationType.ConstY;
                k = p1.Y;
                b = 0;
            }
            else
            {
                type = EquationType.Common;
                k = (p1.Y - p2.Y) / (double)(p1.X - p2.X);
                b = p1.Y - k * p1.X;
            }
        }

        public Equation GetNormalEquation(Point p)
        {
            Equation equation = new Equation();
            if (type == EquationType.Dot)
            {
                equation.k = k;
                equation.b = b;
                equation.type = type;
                return equation;
            }
            else if (type == EquationType.ConstX)
            {
                equation.k = p.X;
                equation.b = 0;
                equation.type = EquationType.ConstY;
                return equation;
            }
            else if (type == EquationType.ConstY)
            {
                equation.k = p.Y;
                equation.b = 0;
                equation.type = EquationType.ConstX;
                return equation;
            }
            else
            {
                equation.k = -1 / k;
                equation.b = p.X * (k - equation.k) + b;
                equation.type = type;
                return equation;
            }
        }

        public Point GetPoint(Point p1, Point p2, double length)
        {
            if (length < 0)
            {
                length = -length;
            }
            Point resultPoint = new Point();
            if (type == EquationType.Dot)
            {
                resultPoint.X = (int)k;
                resultPoint.Y = (int)b;
            }
            else if (type == EquationType.ConstX)
            {
                resultPoint.X = (int)k;
                resultPoint.Y = p1.Y + (p2.Y >= p1.Y ? 1 : -1) * (int)length;
            }
            else if (type == EquationType.ConstY)
            {
                resultPoint.X = p1.X + (p2.X >= p1.X ? 1 : -1) * (int)length;
                resultPoint.Y = (int)k;
            }
            else
            {
                if (p2.X > p1.X)
                {
                    resultPoint.X = p1.X + 1;
                    resultPoint.Y = (int)(k * resultPoint.X + b);
                    Algorithm.ResizeLine(p1, ref resultPoint, -length);
                }
                else
                {
                    resultPoint.X = p1.X - 1;
                    resultPoint.Y = (int)(k * resultPoint.X + b);
                    Algorithm.ResizeLine(p1, ref resultPoint, -length);
                }
            }
            return resultPoint;
        }

        public Point GetPoint(Point p, double length)
        {
            Point resultPoint = new Point();
            if (type == EquationType.Dot)
            {
                resultPoint.X = (int)k;
                resultPoint.Y = (int)b;
            }
            else if (type == EquationType.ConstX)
            {
                resultPoint.X = (int)k;
                resultPoint.Y = p.Y + (int)length;
            }
            else if (type == EquationType.ConstY)
            {
                resultPoint.X = p.X + (int)length;
                resultPoint.Y = (int)k;
            }
            else
            {
                if (length >= 0)
                {
                    resultPoint.X = p.X + 1;
                    resultPoint.Y = (int)(k * resultPoint.X + b);
                    Algorithm.ResizeLine(p, ref resultPoint, length);
                }
                else
                {
                    resultPoint.X = p.X - 1;
                    resultPoint.Y = (int)(k * resultPoint.X + b);
                    Algorithm.ResizeLine(p, ref resultPoint, -length);
                }
            }
            return resultPoint;
        }

        public bool InLine(int x, int y)
        {
            return (GetPositionToLine(x, y) == 0);
        }

        public int GetPositionToLine(int x, int y)
        {
            int result = 0;
            if (type == EquationType.Dot)
            {
                if ((y != (int)b) || (x != (int)k))
                {
                    result |= (int)PositionOnTheLine.OutLine;
                    if (y > (int)b)
                    {
                        result |= (int)PositionOnTheLine.High;
                    }
                    if (x > (int)k)
                    {
                        result |= (int)PositionOnTheLine.Right;
                    }
                }
            }
            else if (type == EquationType.ConstX)
            {
                if (x != (int)k)
                {
                    result |= (int)PositionOnTheLine.OutLine;
                    if (x > (int)k)
                    {
                        result |= (int)PositionOnTheLine.Right;
                    }
                }
            }
            else if (type == EquationType.ConstY)
            {
                if (y != (int)k)
                {
                    result |= (int)PositionOnTheLine.OutLine;
                    if (y > (int)k)
                    {
                        result |= (int)PositionOnTheLine.High;
                    }
                }
            }
            else
            {
                int dy = y - (int)(k * x + b);
                int dx = x - (int)((y - b) / k);
                if ((dy != 0) || (dx != 0))
                {
                    result |= (int)PositionOnTheLine.OutLine;
                    if (dy > 0)
                    {
                        result |= (int)PositionOnTheLine.High;
                    }
                    if (dx > 0)
                    {
                        result |= (int)PositionOnTheLine.Right;
                    }
                }
            }
            return result;
        }

        public int InLineByY(int x, int y)
        {
            if (type == EquationType.Dot)
            {
                return (y - (int)b);
            }
            else if (type == EquationType.ConstX)
            {
                return 0;
            }
            else if (type == EquationType.ConstY)
            {
                return (y - (int)k);
            }
            else
            {
                return y - (int)(k * x + b);
            }
        }

        public int InLineByX(int x, int y)
        {
            if ((type == EquationType.Dot) || (type == EquationType.ConstX))
            {
                return (x - (int)k);
            }
            else if (type == EquationType.ConstY)
            {
                return 0;
            }
            else
            {
                return x - (int)((y - b) / k);
            }
        }
    }
}
