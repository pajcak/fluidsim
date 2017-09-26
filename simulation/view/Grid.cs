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
        public Point origin { get; }
        public int cellSize { get; }
        public int rows { get; }
        public int cols { get; }
        private Pen pen;

        public Grid(Point _upperLeft, int _rows, int _cols, int _cellSize, Pen _pen)
        {
            this.origin = _upperLeft;
            this.pen = _pen;
            this.rows = _rows;
            this.cols = _cols;
            this.cellSize = _cellSize;
        }

        public void drawGrid(Graphics g)
        {
            int width = cols * cellSize + (cols - 1) * (int)pen.Width;
            int height = rows * cellSize + (rows - 1) * (int)pen.Width;
            g.DrawRectangle(pen, origin.X, origin.Y, width, height);
            for (int i = 0; i < cols - 1; i++)
            {
                int x = origin.X + (i + 1) * cellSize + i * (int)pen.Width + (int)(pen.Width / 2);
                Point topPoint = new Point(x, origin.Y);
                Point bottomPoint = new Point(x, origin.Y + height);
                g.DrawLine(pen, topPoint, bottomPoint);
            }
            for (int i = 0; i < rows - 1; i++)
            {
                int y = origin.Y + (i + 1) * cellSize + i * (int)pen.Width + (int)(pen.Width / 2);
                Point left = new Point(origin.X, y);
                Point bottomPoint = new Point(origin.X + width, y);
                g.DrawLine(pen, left, bottomPoint);
            }
        }
    }
}
