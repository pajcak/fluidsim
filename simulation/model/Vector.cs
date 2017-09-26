using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulation.model
{
    public class Vector
    {
        public float first { get; set; }
        public float second { get; set; }

        public Vector(float a, float b)
        {
            first = a;
            second = b;
        }
        public Vector()
        {
            first = 0.0f;
            second = 0.0f;
        }
        public static Vector operator *(Vector a, Vector b)
        {
            a.first *= b.first;
            a.second *= b.second;
            return a;
        }
        public static Vector operator +(Vector a, Vector b)
        {
            a.first += b.first;
            a.second += b.second;
            return a;
        }

        public override string ToString()
        {
            return String.Format("[{0:N};{1:N}]", first, second);
        }
    }
}
