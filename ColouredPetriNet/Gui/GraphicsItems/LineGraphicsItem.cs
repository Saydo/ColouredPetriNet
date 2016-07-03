using System.Drawing;

namespace ColouredPetriNet.Gui.GraphicsItems
{
    public class LineGraphicsItem : GraphicsItem
    {
        protected Point _point1;
        protected Point _point2;
        protected Pen _pen;
        protected Point[] _extentPoint;

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
            : base(id, typeId, 0, 0, z)
        {
            _point1 = new Point();
            _point2 = new Point();
            if ((!ReferenceEquals(p1, null)) && (!ReferenceEquals(p2, null)))
            {
                _x = (p2.X + p1.X) / 2;
                _y = (p2.Y + p1.Y) / 2;
                _point1.X = p1.X;
                _point1.Y = p1.Y;
                _point2.X = p2.X;
                _point2.Y = p2.Y;
            }
            _extentPoint = new Point[4];
            for (int i = 0; i < _extentPoint.Length; ++i)
            {
                _extentPoint[i] = new Point();
            }
            UpdateBorder();
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(_pen, _point1, _point2);
            if (_selected)
            {
                graphics.DrawPolygon(_selectionPen, _extentPoint);
            }
        }

        public override bool InShape(int x, int y)
        {
            double[] k = new double[4];
            double[] b = new double[4];
            LinearAlgebra.GetEquation(_extentPoint[0], _extentPoint[1], out k[0], out b[0]);
            LinearAlgebra.GetEquation(_extentPoint[1], _extentPoint[2], out k[1], out b[1]);
            LinearAlgebra.GetEquation(_extentPoint[2], _extentPoint[3], out k[2], out b[2]);
            LinearAlgebra.GetEquation(_extentPoint[3], _extentPoint[0], out k[3], out b[3]);
            if ((LinearAlgebra.InLineByY(x, y, k[0], b[0]) <= 0) && (LinearAlgebra.InLineByX(x, y, k[1], b[1]) <= 0)
               && (LinearAlgebra.InLineByY(x, y, k[2], b[2]) >= 0) && (LinearAlgebra.InLineByX(x, y, k[3], b[3]) >= 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool InShape(int x, int y, int w, int h, OverlapType overlap = OverlapType.Partial)
        {
            double[] k = new double[4];
            double[] b = new double[4];
            LinearAlgebra.GetEquation(_extentPoint[0], _extentPoint[1], out k[0], out b[0]);
            LinearAlgebra.GetEquation(_extentPoint[1], _extentPoint[2], out k[1], out b[1]);
            LinearAlgebra.GetEquation(_extentPoint[2], _extentPoint[3], out k[2], out b[2]);
            LinearAlgebra.GetEquation(_extentPoint[3], _extentPoint[0], out k[3], out b[3]);
            if (overlap == OverlapType.Partial)
            {
                if ((LinearAlgebra.InLineByY(x + w, y, k[0], b[0]) > 0) || (LinearAlgebra.InLineByY(x, y, k[1], b[1]) > 0)
                    || (LinearAlgebra.InLineByY(x, y + h, k[2], b[2]) < 0)
                    || (LinearAlgebra.InLineByY(x + w, y + h, k[3], b[3]) < 0))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if ((LinearAlgebra.InLineByY(x, y + h, k[0], b[0]) <= 0)
                    && (LinearAlgebra.InLineByY(x + w, y + h, k[1], b[1]) <= 0)
                    && (LinearAlgebra.InLineByY(x + w, y, k[2], b[2]) >= 0)
                    && (LinearAlgebra.InLineByY(x, y, k[3], b[3]) >= 0))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        protected override void UpdateBorder()
        {
            _extentPoint = LinearAlgebra.GetLineBorder(_point1, _point2, (_selected ? _extent : 1));
            base.SetBorder(LinearAlgebra.MinX(_extentPoint), LinearAlgebra.MaxX(_extentPoint),
                LinearAlgebra.MinY(_extentPoint), LinearAlgebra.MaxY(_extentPoint));
        }
    }
}
