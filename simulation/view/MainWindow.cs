using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using simulation.model;

namespace simulation.view
{
    public partial class MainWindow : Form
    {
        private SimView view;
        public Grid velocityGrid { get; }
        private int visibleX;
        private int visibleY;
        private int gridPadding;
        private Pen gridPen;
        private Pen vectorPen;
        private Graphics graphics;

        private IField<Vector> list;

        public MainWindow(SimView v)
        {
            InitializeComponent(); // in the partial class created by designer
            this.view = v;
            this.visibleX = this.ClientSize.Width - 1;
            this.visibleY = this.ClientSize.Height - 1;
            gridPadding = 5;
            //cellsize should be derived from windows size 
            //and num of rows and cols passed to drawField
            float cellSize = 15f;
            gridPen = new Pen(Color.Black, 1f);
            vectorPen = new Pen(Color.Blue, 1.5f);
            this.velocityGrid = new Grid(
                new Point(gridPadding, gridPadding),
                20, 30,
                cellSize,
                gridPen,
                vectorPen
                );
            this.list = new Field<Vector>(20,30);
            Random r = new Random();
            for (int i = 0; i < 20 * 30; i++)
            {
                //list[i].first = 1.0f;
                //list[i].second = 0.0f;
                list[i].first = (float)r.NextDouble() * 200.0f;
                list[i].second = (float)r.NextDouble() * 200.0f;
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.graphics = e.Graphics;
            // calculate new cellSize in order to fit the window
            float newCellSize1 = (this.ClientSize.Width - 2 * gridPadding - (velocityGrid.cols + 1) * gridPen.Width) / velocityGrid.cols;
            float newCellSize2 = (this.ClientSize.Height- 2 * gridPadding - (velocityGrid.rows + 1) * gridPen.Width) / velocityGrid.rows;
            float newCellSize = newCellSize1 < newCellSize2 ? newCellSize1 : newCellSize2;
            velocityGrid.cellSize = newCellSize;
            velocityGrid.drawGrid(this.graphics);
            velocityGrid.drawVectors(this.graphics, ref list);
        }
        public Graphics GetGraphics()
        {
            return this.graphics;
        }
    }
}
