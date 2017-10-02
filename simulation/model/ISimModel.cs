using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulation.model
{
    public interface ISimModel
    {
        void updateVelocities();
        void updateDensities();
        IField<Vector> GetVelocityField();
    }
}
