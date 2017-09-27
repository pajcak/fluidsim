using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simulation.view
{
    class Grid
    {
        public PointF origin { get; }
        public float cellSize { get; set; }
        public int rows { get; }
        public int cols { get; }
        private Pen pen;

        public Grid(PointF _upperLeft, int _rows, int _cols, float _cellSize, Pen _pen)
        {
            this.origin = _upperLeft;
            this.pen = _pen;
            this.rows = _rows;
            this.cols = _cols;
            this.cellSize = _cellSize;
        }

        public void drawGrid(Graphics g)
        {
            float width = cols * cellSize + (cols - 1) * pen.Width;
            float height = rows * cellSize + (rows - 1) * pen.Width;
            g.DrawRectangle(pen, origin.X, origin.Y, width, height);
            for (int i = 0; i < cols - 1; i++)
            {
                float x = origin.X + (i + 1) * cellSize + i * pen.Width + (pen.Width / 2);
                PointF topPoint = new PointF(x, origin.Y);
                PointF bottomPoint = new PointF(x, origin.Y + height);
                g.DrawLine(pen, topPoint, bottomPoint);
            }
            for (int i = 0; i < rows - 1; i++)
            {
                float y = origin.Y + (i + 1) * cellSize + i * pen.Width + (pen.Width / 2);
                PointF left = new PointF(origin.X, y);
                PointF rightPoint = new PointF(origin.X + width, y);
                g.DrawLine(pen, left, rightPoint);
            }
        }
    }
}
