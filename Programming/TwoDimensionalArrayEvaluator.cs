using System;
using System.Collections.Generic;

namespace Programming {

    public class TwoDimensionalArrayEvaluator : TwoDimensionalArrayEvaluator<int> {
        public TwoDimensionalArrayEvaluator(int[,] grid, int threshold) : base(grid, threshold) {
        }

        internal override bool IsValueGreaterThanThreshold(int x, int y) =>
            this.Grid[x, y] > this.threshold;        

        public override void SetCenterOfMasses() {

            foreach (var subRegion in this.SubRegions) {
                double mass = 0,
                    sumX = 0,
                    sumY = 0;
                foreach (var signal in subRegion.Signals) {
                    mass += signal.Value;
                    sumX += signal.X * signal.Value;
                    sumY += signal.Y * signal.Value;
                }                
                subRegion.CenterOfMass = new CenterOfMass(sumX / mass, sumY / mass);
            }
        }
    }

    public abstract class TwoDimensionalArrayEvaluator<T> where T : IComparable {

        int rows;
        int columns;
        bool[,] visited;
        protected T threshold;
        public List<SubRegion<T>> SubRegions { get; private set; }
        T[,] m_grid;
        protected T[,] Grid {
            get { return m_grid; }
            set {
                m_grid = value;
                rows = m_grid.GetLength(0);
                columns = m_grid.GetLength(1);
                this.visited = new bool[rows, columns];
                this.SubRegions = new List<SubRegion<T>>();
            }
        }

        public TwoDimensionalArrayEvaluator(T[,] grid, T threshold) {
            this.threshold = threshold;
            this.Grid = grid;
            var queue = new Queue<Tuple<int, int>>();
            for (int x = 0; x < rows; x++) {
                for (int y = 0; y < columns; y++) {
                    if (!visited[x, y] &&
                        IsValueGreaterThanThreshold(x, y)) {
                        var newSubRegion = new SubRegion<T>() { RegionIndex = SubRegions.Count };
                        SubRegions.Add(newSubRegion);
                        queue.Enqueue(new Tuple<int, int>(x, y));
                        while (queue.Count > 0) {
                            var top = queue.Dequeue();
                            visited[top.Item1, top.Item2] = true;
                            RunSurroundingPoints(top.Item1, top.Item2, queue, newSubRegion);
                        }
                    }
                    visited[x, y] = true;
                }
            }
            this.SetCenterOfMasses();
        }
            

        private void RunSurroundingPoints(int x, int y, Queue<Tuple<int, int>> queue, SubRegion<T> subRegion) {
            subRegion.Signals.Add(new Signal<T>(x, y, this.Grid[x, y]));
            CheckPointAgainstThreshold(x - 1, y - 1, queue);
            CheckPointAgainstThreshold(x - 1, y, queue);
            CheckPointAgainstThreshold(x - 1, y + 1, queue);
            CheckPointAgainstThreshold(x, y + 1, queue);
            CheckPointAgainstThreshold(x + 1, y + 1, queue);
            CheckPointAgainstThreshold(x + 1, y, queue);
            CheckPointAgainstThreshold(x + 1, y - 1, queue);
            CheckPointAgainstThreshold(x, y - 1, queue);
        }

        private void CheckPointAgainstThreshold(int x, int y, Queue<Tuple<int, int>> queue) {
            if (x > 0 &&
                y > 0 &&
                x < rows &&
                y < columns &&
                !visited[x, y] &&
                IsValueGreaterThanThreshold(x, y) &&
                !queue.Contains(new Tuple<int, int>(x, y))) {
                queue.Enqueue(new Tuple<int, int>(x, y));
            }
        }

        internal virtual bool IsValueGreaterThanThreshold(int x, int y) => Comparer<T>.Default.Compare(this.Grid[x, y], threshold) > 0;

        public abstract void SetCenterOfMasses();

    }

    public class SubRegion<T>
        where T : IComparable {
        public int RegionIndex { get; set; }
        public List<Signal<T>> Signals = new List<Signal<T>>();
        public CenterOfMass CenterOfMass;
    }

    public class Signal<T> where T : IComparable {

        public Signal(int x, int y, T value) {
            this.X = x;
            this.Y = y;
            this.Value = value;
        }
        public int X { get; private set; }
        public int Y { get; private set; }

        public T Value { get; private set; }

    }

    public class CenterOfMass {

        public CenterOfMass(double x, double y) {
            this.X = x;
            this.Y = y;
        }
        public double X { get; private set; }
        public double Y { get; private set; }

    }
    

}
