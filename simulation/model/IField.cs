using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulation.model
{
    public interface IField<T> : IList<T>
    {
        int rows { get; }
        int cols { get; }
        T this[int row, int col] { get; set; }
    }
}
