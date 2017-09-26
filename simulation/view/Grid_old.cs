using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simulation.view
{
    class Grid_Old
    {
        private Rectangle area { get; }
        private int rows;
        private int cols;
        private Pen pen;

        public Grid_Old(Rectangle _area, int _rows, int _cols, Pen _pen)
        {
            this.area = _area;
            this.pen = _pen;
            this.rows = _rows;
            this.cols = _cols;
        }

        public void drawGrid(Graphics g)
        {
            g.DrawRectangle(pen, area);
            int cellW = (area.Width - (cols - 1) * (int)pen.Width) / cols;
            int cellH = (area.Height - (rows - 1) * (int)pen.Width) / rows;
            for (int i = 0; i < cols - 1; i++)
            {
                int x = area.X + (i + 1) * cellW + i * (int)pen.Width + (int)(pen.Width / 2);
                Point topPoint = new Point(x, area.Y);
                Point bottomPoint = new Point(x, area.Y + area.Height);
                g.DrawLine(pen, topPoint, bottomPoint);
            }
            for (int i = 0; i < rows - 1; i++)
            {
                int y = area.Y + (i + 1) * cellH + i * (int)pen.Width + (int)(pen.Width / 2);
                Point leftPoint = new Point(area.X, y);
                Point rightPoint = new Point(area.X + area.Width, y);
                g.DrawLine(pen, leftPoint, rightPoint);
            }
        }
    }
}
