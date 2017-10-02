using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simulation.model;

namespace simulation
{
    public class Field<T> : IField<T>
    {
        private IList<T> field;
        public int rows { get; }
        public int cols { get; }

        public Field(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            int size = rows * cols;
            field = new List<T>(size);
            for (int i = 0; i < size; i++)
                field.Add(Activator.CreateInstance<T>());
        }

        public T this[int row, int col]
        {
            get
            {
                return this[row * rows + col];
            }
            set
            {
                this[row * rows + col] = value;
            }
        }

        public T this[int index]
        {
            get => field[index];
            set => field[index] = value;
        }

        public int Count => field.Count();

        public void Clear()
        {
            field.Clear();
        }

        // do not use - reorderes array!
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return field.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return field.GetEnumerator();
        }

        public bool IsReadOnly => field.IsReadOnly;

        T IList<T>.this[int index]
        {
            get => field[index];
            set => field[index] = value;
        }

        public void Add(T item)
        {
            field.Add(item);
        }

        public bool Contains(T item)
        {
            return field.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            field.CopyTo(array, arrayIndex);
        }

        public int IndexOf(T item)
        {
            return field.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            field.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return field.Remove(item);
        }

        public void addSource(ref Field<T> prevField, dynamic dt)
        {
            for (int i = 0; i < Count; i++)
            {
                field[i] += prevField[i] * dt;
            }
        }
        public void diffuse(int bounds, ref Field<T> prevField,
            dynamic diff, dynamic dt)
        {
            dynamic a = dt * diff * Count;
            for (int k = 0; k < 20 /*TODO constant*/; k++)
            {
                for (int i = 1; i <= rows; i++)
                {
                    for (int j = 1; j <= cols; j++)
                    {
                        this[i, j] = (prevField[i, j] +
                             ((dynamic)this[i - 1, j] + this[i + 1, j] + this[i, j - 1] + this[i, j + 1]) * a)
                            / (1 + 4 * a);
                    }
                }
                setBoundaries(bounds);
            }
        }

        public void advect(int bounds, ref Field<T> prevField,
            ref Field<Vector> velocities, dynamic dt)
        {
            int i0, j0, i1, j1;
            float x, y, s0, t0, s1, t1, dt0 = dt * (Count / 2);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    x = i - dt0 * velocities[i, j].first;
                    y = j - dt0 * velocities[i, j].second;
                    if (x < 0.5f) x = 0.5f;
                    if (x > (Count / 2) + 0.5f) x = (Count / 2) + 0.5f;
                    i0 = (int)x; i1 = i0 + 1;
                    if (y < 0.5f) y = 0.5f;
                    if (y > (Count / 2) + 0.5f) y = (Count / 2) + 0.5f;
                    j0 = (int)y; j1 = j0 + 1;
                    s1 = x - i0; s0 = 1 - s1; t1 = y - j0; t0 = 1 - t1;
                    this[i, j] = ((dynamic)prevField[i0, j0] * t0 + (dynamic)prevField[i0, j1] * t1) * s0 +
                                    ((dynamic)prevField[i1, j0] * t0 + (dynamic)prevField[i1, j1] * t1) * s1;
                }
            }
            setBoundaries(bounds);
        }

        public override String ToString()
        {
            String s = "";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    s += "[";
                    s += this[i, j].ToString();
                    if (j < cols - 1) s += ",";
                    else s += "]\n";
                }
            }
            return s;
        }
        public void setBoundaries(int bounds)
        {
            //TODO - implement to have field boundaries
            //throw new NotImplementedException();
        }
    }
}
