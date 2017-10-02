using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simulation.model;
using simulation.view;

namespace simulation.controller
{
    class SimController : ISimController
    {
        private ISimModel model;
        private ISimView view;
        private bool simulating;

        public SimController(ISimModel model, ISimView view)
        {
            this.model = model;
            this.view = view;
            this.simulating = true;
        }
        public void simulate()
        {
            while (simulating)
            {
                //manage input from view
                model.updateVelocities();
                model.updateDensities();
                view.drawField(model.GetVelocityField());
                //view.drawField();
            }
        }
    }
}
