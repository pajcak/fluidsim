using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simulation.model;
using simulation.controller;

namespace simulation.view
{
    public interface ISimView
    {
        MainWindow mainWindow { get; }
        void drawField(IField<float> field);
        void drawField(IField<Vector> field);
    }

}
