using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simulation.model;
using System.Windows.Forms;
using simulation.controller;

namespace simulation.view
{
    public class SimView : ISimView
    {
        public MainWindow mainWindow { get; }
        public SimView()
        {
            this.mainWindow = new MainWindow(this);
        }

        public void drawField(IField<float> field)
        {
            throw new NotImplementedException();
        }

        public void drawField(IField<Vector> field)
        {
            mainWindow.velocityGrid.drawVectors(mainWindow.GetGraphics(), ref field);
        }

    }
}
