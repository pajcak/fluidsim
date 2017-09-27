﻿using System;
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
        private Grid velocityGrid;
        private int visibleX;
        private int visibleY;
        private int gridPadding;
        private Pen gridPen;
        private Pen vectorPen;

        private IField<Vector> list;

        public MainWindow(SimView v)
        {
            InitializeComponent(); // in the partial class created by designer
            this.view = v;
            this.visibleX = this.ClientSize.Width - 1;
            this.visibleY = this.ClientSize.Height - 1;
            gridPadding = 20;
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
            /*grid musi bejt furt videt celej, nezavisle na poctu rows a cols,
             ale zavisle na cellSize... takze cellSize se musi spocitat z 
             aktualni velikosti okna (pri OnPaint) a posledniho znamyho 
             (v budoucnu spis na zacatku fixne nastavenyho) poctu rows, cols*/
            this.list = new Field<Vector>(20,30);
            Random r = new Random();
            for (int i = 0; i < 20 * 30; i++)
            {
                //list[i].first = 0.5f;
                //    list[i].second = 0.0f;
                list[i].first = (float)r.NextDouble() * 200.0f;
                list[i].second = (float)r.NextDouble() * 200.0f;
            }
            list[1].first = 100.0f;
            list[1].second= 100.0f;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // calculate new cellSize in order to fit the window
            float newCellSize1 = (this.ClientSize.Width - 2 * gridPadding - (velocityGrid.cols + 1) * gridPen.Width) / velocityGrid.cols;
            float newCellSize2 = (this.ClientSize.Height- 2 * gridPadding - (velocityGrid.rows + 1) * gridPen.Width) / velocityGrid.rows;
            float newCellSize = newCellSize1 < newCellSize2 ? newCellSize1 : newCellSize2;
            velocityGrid.cellSize = newCellSize;
            velocityGrid.drawGrid(e.Graphics);
            velocityGrid.drawVectors(e.Graphics, ref list);
        }
    }
}
