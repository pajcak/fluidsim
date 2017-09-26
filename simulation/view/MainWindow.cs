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
        public MainWindow(SimView v)
        {
            this.view = v;
            InitializeComponent(); // in the partial class created by designer
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
