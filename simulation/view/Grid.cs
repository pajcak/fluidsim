using simulation.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simulation.view
{
    public class Grid
    {
        public PointF origin { get; }
        /*
        <see cref="cellSize"/>is the width/height of all the white pixels
        inside a cell, no matter how thick the <see cref="pen"/> is
        (the thicker the pen, the larger the grid)*/
        public float cellSize { get; set; }
        public int rows { get; }
        public int cols { get; }
        private Pen penBorder;
        private Pen penVector;
        private Pen penArrow;

        public Grid(PointF _upperLeft, int _rows, int _cols, float _cellSize,
                    Pen _penBorder, Pen _penVector)
        {
            this.origin = _upperLeft;
            this.cellSize = _cellSize;
            this.rows = _rows;
            this.cols = _cols;
            this.penBorder = _penBorder;
            this.penVector = _penVector;
            this.penArrow = new Pen(Color.Red, penVector.Width * 2f);
        }

        public void drawGrid(Graphics g)
        {
            float width = cols * cellSize + (cols - 1) * penBorder.Width + 2 * (penBorder.Width / 2);
            float height = rows * cellSize + (rows - 1) * penBorder.Width + 2 * (penBorder.Width / 2);
            g.DrawRectangle(penBorder, origin.X, origin.Y, width, height);
            for (int i = 0; i < cols - 1; i++)
            {
                float x = origin.X + (i + 1) * cellSize + i * penBorder.Width + 2 * (penBorder.Width / 2);
                PointF topPoint = new PointF(x, origin.Y);
                PointF bottomPoint = new PointF(x, origin.Y + height);
                g.DrawLine(penBorder, topPoint, bottomPoint);
            }
            for (int i = 0; i < rows - 1; i++)
            {
                float y = origin.Y + (i + 1) * cellSize + i * penBorder.Width + 2 * (penBorder.Width / 2);
                PointF left = new PointF(origin.X, y);
                PointF rightPoint = new PointF(origin.X + width, y);
                g.DrawLine(penBorder, left, rightPoint);
            }
        }

        public void drawVectors(Graphics g, ref IField<Vector> list)
        {
            if (list.rows != this.rows || list.cols != this.cols 
                || list.Count != this.rows * this.cols)
                throw new IndexOutOfRangeException();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    //OPTIMIZE: this can be precalculated only once at the beginning
                    float shiftX = origin.X + penBorder.Width / 2 + j * cellSize + j * penBorder.Width + cellSize / 2;
                    float shiftY = origin.Y + penBorder.Width / 2 + i * cellSize + i * penBorder.Width + cellSize / 2;
                    //ZERO VECTOR (cannot be normalized) -> draw point
                    if (list[i, j].first == 0.0f && list[i, j].second == 0.0f)
                    {
                        g.FillEllipse(penVector.Brush, shiftX, shiftY, penVector.Width, penVector.Width);
                        continue;
                    }
                    Vector v = Vector.normalized(list[i, j]);
                    //Console.WriteLine("{0}->{1}", list[i, j], v);
                    v.first *= cellSize/2; //resize to fit the cell
                    v.second *= cellSize/2;//resize to fit the cell

                    PointF p1 = new PointF(shiftX + v.first, shiftY - v.second);
                    PointF p2 = new PointF(shiftX - v.first, shiftY + v.second);
                    g.DrawLine(penVector, p1, p2);
                    g.FillEllipse(penArrow.Brush, p1.X - penArrow.Width/2, p1.Y- penArrow.Width/2, penArrow.Width, penArrow.Width);
                }
            }
        }
    }
}
