using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulation.model
{
    public class SimModel : ISimModel
    {
        private Field<Vector> velocityField;
        private Field<Vector> velocityFieldPrev;
        private Field<float> densityField;
        private Field<float> densityFieldPrev;
        private float dt;
        private float diff;
        private float visc;

        public SimModel()
        {
            this.velocityField = new Field<Vector>(20, 30);
            //this.velocityFieldPrev = new Field<Vector>(20,30);
            //this.densityField = new Field<float>(200, 300);
            //this.densityFieldPrev = new Field<float>(200, 300);

            // TODO set dt, diff and visc!!!!
            throw new NotImplementedException();
        }

        public void updateVelocities()
        {
            int TEST_BOUNDS = 0;
            velocityField.addSource(ref velocityFieldPrev, dt);
            swapVels(ref velocityFieldPrev, ref velocityField);
            velocityField.diffuse(TEST_BOUNDS, ref velocityFieldPrev, visc, dt);
            //project() TODO - implement this for more realistic fluid swirls
            swapVels(ref velocityFieldPrev, ref velocityField);

            /**/
            Field<Vector> oneSideVels = new Field<Vector>(velocityField.rows, velocityField.cols);
            /**/
            getVectListFirst(ref oneSideVels);
            velocityField.advect(TEST_BOUNDS, ref oneSideVels, ref velocityFieldPrev, dt);
            /**/
            getVectListSecond(ref oneSideVels);
            velocityField.advect(TEST_BOUNDS, ref oneSideVels, ref velocityFieldPrev, dt);
            //project() TODO - implement this for more realistic fluid swirls
        }

        private void getVectListFirst(ref Field<Vector> res)
        {
            for (int i = 0; i < velocityField.Count; i++)
            {
                res[i].first = velocityField[i].first;
                res[i].second = velocityFieldPrev[i].first;
            }
        }
        private void getVectListSecond(ref Field<Vector> res)
        {
            for (int i = 0; i < velocityField.Count; i++)
            {
                res[i].first = velocityField[i].second;
                res[i].second = velocityFieldPrev[i].second;
            }
        }

        public void updateDensities()
        {
            int TEST_BOUNDS = 0;
            densityField.addSource(ref densityFieldPrev, dt);
            swapDens(ref densityFieldPrev, ref densityField);
            densityField.diffuse(TEST_BOUNDS, ref densityFieldPrev, diff, dt);
            swapDens(ref densityFieldPrev, ref densityField);
            densityField.advect(TEST_BOUNDS,
                ref densityFieldPrev, ref velocityField, dt);
        }

        private void swapDens(ref Field<float> a, ref Field<float> b)
        {
            Field<float> tmp = a;
            a = b;
            b = tmp;
        }

        private void swapVels(ref Field<Vector> a, ref Field<Vector> b)
        {
            Field<Vector> tmp = a;
            a = b;
            b = tmp;
        }
    }
}
