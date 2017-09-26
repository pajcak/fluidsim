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

            //ISimModel model = new SimModel();
            ISimView view = new SimView();
            //ISimController controller = new SimController(model, view);

            //start a new thread with controller.simulate()
            //throw new NotImplementedException();

            Application.Run(view.mainWindow);
        }
    }
}
