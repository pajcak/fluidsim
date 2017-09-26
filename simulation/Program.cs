using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using simulation.model;
using simulation.view;
using simulation.controller;

namespace simulation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SimModel model = new SimModel();
            SimView view = new SimView();
            SimController controller = new SimController(model, view);

            //start a new thread with controller.simulate()
            //throw new NotImplementedException();

            //Application.Run(view.mainWindow);
        }
    }
}
