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
        private Grid velocityGrid;
        private int visibleX;
        private int visibleY;

        public MainWindow(SimView v)
        {
            InitializeComponent(); // in the partial class created by designer
            this.view = v;
            this.visibleX = this.ClientSize.Width - 1;
            this.visibleY = this.ClientSize.Height - 1;
            int padding = 20;
            //cellsize should be derived from windows size 
            //and num of rows and cols passed to drawField
            int cellSize = 15;
            this.velocityGrid = new Grid(
                new Point(padding, padding),
                20, 30,
                cellSize,
                new Pen(Color.Black, 1f)
                );
            /*grid musi bejt furt videt celej, nezavisle na poctu rows a cols,
             ale zavisle na cellSize... takze cellSize se musi spocitat z 
             aktualni velikosti okna (pri OnPaint) a posledniho znamyho 
             (v budoucnu spis na zacatku fixne nastavenyho) poctu rows, cols*/
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            velocityGrid.drawGrid(e.Graphics);
        }
    }
}
