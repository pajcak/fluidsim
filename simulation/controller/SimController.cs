using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simulation.model;
using simulation.view;

namespace simulation.controller
{
    public class SimController : ISimController
    {
        public ISimModel model {get; }
        public ISimView view { get; set; }
        private bool simulating;

        public SimController(ISimModel model/*, ISimView view*/)
        {
            this.model = model;
            /*this.view = view;*/
            this.simulating = true;
        }
        public void simulate()
        {
            Console.WriteLine("ASDSADASDDASDSASDDS");
            while (simulating)
            {
                //manage input from view
                model.updateVelocities();
                //model.updateDensities();
                view.drawField(model.GetVelocityField());
                //view.drawField();
            }
        }
    }
}
