using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming {


    public class TwoDimensionalArrayEvaluatorThreaded : TwoDimensionalArrayEvaluatorThreaded<int> {
        public TwoDimensionalArrayEvaluatorThreaded(int[,] grid, int threshold) : base(grid, threshold) {
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

    //make a 'subarray' definition - areas within the array to operate on 
    //then can loop through those would have to keep in mind that if its row 0 in the split then we cannot
    //cannot while processing within a defined area below or above the defined area 
    //then once done take each of those subarray definitions 1=>n and merge the subregions 
    //while subarray definition >1 merge 1 into 0
    //the merge process being getting subregions put together
    public abstract class TwoDimensionalArrayEvaluatorThreaded<T> where T : IComparable {

        int rows;
        int columns;
        ConcurrentDictionary<Tuple<int, int>, bool> visited;
        ConcurrentQueue<Tuple<int, int>> queue;
        protected T threshold;
        public List<SubRegion<T>> SubRegions { get; private set; }
        T[,] m_grid;
        protected T[,] Grid {
            get { return m_grid; }
            set {
                m_grid = value;
                rows = m_grid.GetLength(0);
                columns = m_grid.GetLength(1);
                this.visited = new ConcurrentDictionary<Tuple<int, int>, bool>();
                this.SubRegions = new List<SubRegion<T>>();
            }
        }

        public TwoDimensionalArrayEvaluatorThreaded(T[,] grid, T threshold) {
            this.threshold = threshold;
            this.Grid = grid;
            queue = new ConcurrentQueue<Tuple<int, int>>();
            for (int x = 0; x < rows; x++) {
                for (int y = 0; y < columns; y++) {
                    var key = new Tuple<int, int>(x, y);
                    if (!haveVisited(x, y) &&
                        IsValueGreaterThanThreshold(x, y)) {
                        var newSubRegion = new SubRegion<T>() { RegionIndex = SubRegions.Count };
                        SubRegions.Add(newSubRegion);
                        queue.Enqueue(new Tuple<int, int>(x, y));
                        while (queue.Count > 0) {
                            Tuple<int, int> top;
                            if (queue.TryDequeue(out top)) {                             
                                key = new Tuple<int, int>(top.Item1, top.Item2);
                                visited[key] = true;
                                RunSurroundingPoints(top.Item1, top.Item2, queue, newSubRegion);
                            }
                        }
                    }
                    visited[key] = true;
                }
            }
            this.SetCenterOfMasses();
        }

        private bool haveVisited(int x, int y) => this.visited.ContainsKey(new Tuple<int, int>(x, y));
        
        private void RunSurroundingPoints(int x, int y, ConcurrentQueue<Tuple<int, int>> queue, SubRegion<T> subRegion) {
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

        private void CheckPointAgainstThreshold(int x, int y, ConcurrentQueue<Tuple<int, int>> queue) {
            if (x > 0 &&
                y > 0 &&
                x < rows &&
                y < columns &&
                !haveVisited(x, y) &&
                IsValueGreaterThanThreshold(x, y) &&
                !queue.Contains(new Tuple<int, int>(x, y))) {
                queue.Enqueue(new Tuple<int, int>(x, y));
            }
        }

        internal virtual bool IsValueGreaterThanThreshold(int x, int y) => Comparer<T>.Default.Compare(this.Grid[x, y], threshold) > 0;

        public abstract void SetCenterOfMasses();

    }
}
