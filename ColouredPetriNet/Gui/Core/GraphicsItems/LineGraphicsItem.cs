using System.Drawing;

namespace ColouredPetriNet.Gui.Core.GraphicsItems
{
    public class LineGraphicsItem : GraphicsItem
    {
        protected Point _point1;
        protected Point _point2;
        protected Pen _pen;
        protected Point[] _extentPoints;

        public Point Point1
        {
            get { return _point1; }
            set
            {
                if ((value.X >= 0) && (value.Y >= 0))
                {
                    _point1 = value;
                    UpdateBorder();
                }
            }
        }

        public Point Point2
        {
            get { return _point2; }
            set
            {
                if ((value.X >= 0) && (value.Y >= 0))
                {
                    _point2 = value;
                    UpdateBorder();
                }
            }
        }

        public Pen Pen
        {
            get { return _pen; }
            set { _pen = value; }
        }

        public LineGraphicsItem() : this(-1, -1, new Point(), new Point())
        {
        }

        public LineGraphicsItem(int id, int typeId, Point p1, Point p2, int z = 0)
            : base(id, typeId, z)
        {
            _pen = new Pen(Color.FromArgb(0, 0, 0), 1.0F);
            _point1 = p1;
            _point2 = p2;
            _center.X = (p2.X + p1.X) / 2;
            _center.Y = (p2.Y + p1.Y) / 2;
            _extentPoints = new Point[4];
            for (int i = 0; i < _extentPoints.Length; ++i)
            {
                _extentPoints[i] = new Point();
            }
            System.Console.WriteLine("LineGraphicsItem(0): p1={0}, p2={1}", _point1, _point2);
            _extentPoints = LinearAlgebra.Algorithm.GetLineBorder(_point1, _point2,
                (_selected ? _extent : 2));
            System.Console.WriteLine("LineGraphicsItem(1): _ep[0]={0}, _ep[1]={1}, _ep[2]={2}, _ep[3]={3}",
                _extentPoints[0], _extentPoints[1], _extentPoints[2], _extentPoints[3]);
            System.Console.WriteLine("LineGraphicsItem(2): b[Left]={0}, b[Right]={1}, b[Bottom]={2}, b[Top]={3}",
                _borderPoints[(int)BorderSide.Left], _borderPoints[(int)BorderSide.Right],
                _borderPoints[(int)BorderSide.Bottom], _borderPoints[(int)BorderSide.Top]);
            base.SetBorder(LinearAlgebra.Algorithm.MinX(_extentPoints) - _center.X,
                LinearAlgebra.Algorithm.MaxX(_extentPoints) - _center.X,
                LinearAlgebra.Algorithm.MinY(_extentPoints) - _center.Y,
                LinearAlgebra.Algorithm.MaxY(_extentPoints) - _center.Y);
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(_pen, _point1, _point2);
            if (_selected)
            {
                graphics.DrawPolygon(_selectionPen, _extentPoints);
            }
        }

        public override void SetPosition(int x, int y)
        {
            int dx = x - _center.X;
            int dy = y - _center.Y;
            _point1.X += dx;
            _point1.Y += dy;
            _point2.X += dx;
            _point2.Y += dy;
            for (int i = 0; i < _extentPoints.Length; ++i)
            {
                _extentPoints[i].X += dx;
                _extentPoints[i].Y += dy;
            }
            _center.X = x;
            _center.Y = y;
        }

        public override void Move(int x, int y)
        {
            _point1.X += x;
            _point1.Y += y;
            _point2.X += x;
            _point2.Y += y;
            for (int i = 0; i < _extentPoints.Length; ++i)
            {
                _extentPoints[i].X += x;
                _extentPoints[i].Y += y;
            }
            _center.X += x;
            _center.Y += y;
        }

        public override bool InShape(int x, int y)
        {
            LinearAlgebra.Equation[] eq = new LinearAlgebra.Equation[4];
            eq[0] = new LinearAlgebra.Equation(_extentPoints[0], _extentPoints[1]);
            eq[1] = new LinearAlgebra.Equation(_extentPoints[1], _extentPoints[2]);
            eq[2] = new LinearAlgebra.Equation(_extentPoints[2], _extentPoints[3]);
            eq[3] = new LinearAlgebra.Equation(_extentPoints[3], _extentPoints[0]);
            if ((eq[0].InLineByY(x, y) <= 0) && (eq[1].InLineByX(x, y) <= 0)
               && (eq[2].InLineByY(x, y) >= 0) && (eq[3].InLineByX(x, y) >= 0))
            {
                System.Console.WriteLine("InShape(x, y) true");
                return true;
            }
            else
            {
                System.Console.WriteLine("InShape(x, y) false");
                return false;
            }
        }

        public override bool InShape(int x, int y, int w, int h, OverlapType overlap = OverlapType.Partial)
        {

            LinearAlgebra.Equation[] eq = new LinearAlgebra.Equation[4];
            eq[0] = new LinearAlgebra.Equation(_extentPoints[0], _extentPoints[1]);
            eq[1] = new LinearAlgebra.Equation(_extentPoints[1], _extentPoints[2]);
            eq[2] = new LinearAlgebra.Equation(_extentPoints[2], _extentPoints[3]);
            eq[3] = new LinearAlgebra.Equation(_extentPoints[3], _extentPoints[0]);
            if (overlap == OverlapType.Partial)
            {
                if ((eq[0].InLineByY(x + w, y) > 0) || (eq[1].InLineByX(x, y) > 0)
                    || (eq[2].InLineByY(x, y + h) < 0) || (eq[3].InLineByX(x + w, y + h) < 0))
                {
                    System.Console.WriteLine("InShape(x, y, w, h) overlap=Partical; false");
                    return false;
                }
                else
                {
                    System.Console.WriteLine("InShape(x, y, w, h) overlap=Partical; true");
                    return true;
                }
            }
            else
            {
                bool res = InBorder(x, y);
                System.Console.WriteLine("InShape(x, y, w, h) overlap=Full; {0}", res);
                return res;
            }
        }

        protected override void UpdateBorder()
        {
            _extentPoints = LinearAlgebra.Algorithm.GetLineBorder(_point1, _point2,
                (_selected ? _extent : 2));
            base.SetBorder(LinearAlgebra.Algorithm.MinX(_extentPoints) - _center.X,
                LinearAlgebra.Algorithm.MaxX(_extentPoints) - _center.X,
                LinearAlgebra.Algorithm.MinY(_extentPoints) - _center.Y,
                LinearAlgebra.Algorithm.MaxY(_extentPoints) - _center.Y);
        }
    }
}
