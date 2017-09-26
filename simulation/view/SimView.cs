using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simulation.model;
using System.Windows.Forms;

namespace simulation.view
{
    public class SimView : ISimView
    {
        public MainWindow mainWindow { get; }
        public SimView()
        {
            this.mainWindow = new MainWindow(this);
        }
    }
}
