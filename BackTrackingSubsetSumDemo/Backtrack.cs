using System;
using System.Linq;

namespace BackTrackingSubsetSumDemo
{
    internal class Backtrack
    {
        private readonly Action<object> _write;
        private readonly Data _p;
        private bool _maxSolutionsReachedExitBt;

        public Backtrack(Action<object> write, Data P)
        {
            _write = write;
            _p = P;
        }

        private void UndoUpdate(Data P, Candidate c, int depth)
        {
            P.Remove(c);
            if (P.Config.ShowProgress) { Print(P, c, depth); }
        }

        private void Update(Data P, Candidate c, int depth)
        {
            P.Add(c);
            if (P.Config.ShowProgress) { Print(P, c, depth); }
        }

        /*     
        wikipedia:
        http://en.wikipedia.org/wiki/Backtracking

        procedure bt(P,c)
            if reject(P,c) then return
            update(P,c) // update data
            if accept(P,c) then output(P,c)
            s ← first(P,c)
            while s ≠ Λ do
                bt(P,s)
                s ← next(P,s)
            end while 
            undoUpdate(P,c) // backtracking starts here
         end procedure
        */

        // O(?)
        private void BackTrackMethod(Data P, Candidate c, int depth)
        {
            if (Reject(P, c)) { return; }

            // Update data
            Update(P, c, depth);

            if (P.Config.ShowStatus) { ShowStatus(P, c); } // print status

            if (Accept(P, c)) { SaveResult(P, c); }

            if (_maxSolutionsReachedExitBt) { return; } // custom exit

            var s = First(P, c);

            while (s != null)
            {
                BackTrackMethod(P, s, depth + 1);
                s = Next(P, s);
            }

            if (_maxSolutionsReachedExitBt) { return; } // custom exit

            // Leaf, dead end, backtrack, roll back data
            UndoUpdate(P, c, depth);
        }

        // O(1)
        private bool Accept(Data P, Candidate c)
        {
            const float epsilon = 0.000001f;
            if (Math.Abs(P.Sum - P.WorkingSum) < epsilon) { return true; }

            return false;
        }

        // O(1)
        private bool Reject(Data P, Candidate c)
        {
            if (_maxSolutionsReachedExitBt) { return true; }

            if (c == null) { throw new ArgumentNullException("c"); }

            var i = P.Numbers[c.Index];

            // Optimization vs. iterate all combinations
            // Reject if rest of sorted list contains positive numbers
            if (i >= 0 && i + P.WorkingSum > P.Sum) { return true; }

            return false;
        }

        public void Run()
        {
            var setsum = _p.Numbers.Sum();
            if (_p.Sum > setsum)
            {
                _write(string.Format("Sum: {0} is bigger than set sum {1}, no solutions exists\n",
                    _p.Sum, setsum));
                return;
            }

            for (int i = 0; i < _p.Numbers.Length; i++)
            {
                BackTrackMethod(_p, new Candidate { Index = i }, 1);
            }
        }

        public void Show()
        {
            _write(string.Format("Max solutions: {0}\n", _p.Config.MaxSolutions));
            _write(string.Format("Sum: {0}\n", _p.Sum));
            _write(string.Format("Set:\n"));
            _p.Numbers.ToList().ForEach(a => _write(a + ", "));

            if (_p.Config.DisplaySolutions)
            {
                _write(string.Format("\n\n*** Solutions:\n\n"));
                _p.SolutionsList.ForEach(_write);
            }

            _write(string.Format("\nUnique Paths Tried: {0}\n", _p.PathsTried));
            _write(string.Format("Solutions count: {0}\n", _p.Solutions));
        }

        // O(n) where n is path length
        private void SaveResult(Data P, Candidate c)
        {
            P.Solutions++;

            if (P.Config.DisplaySolutions)
            {
                // Only save result data if to be displayed
                var list = P.Stack.ToList();
                list.Reverse();

                string numbers = list.Aggregate("", (a, b) => a + (P.Numbers[b] + ", "));
                string indexes = list.Aggregate("", (a, b) => a + (b + ", "));
                P.SolutionsList.Add(string.Format("Numbers: {0}\nIndexes: {1}\n\n", numbers, indexes));
            }


            if (P.Solutions >= P.Config.MaxSolutions) { _maxSolutionsReachedExitBt = true; }
        }

        // First valid child from path
        // O(1)
        private Candidate First(Data P, Candidate c)
        {
            int j = c.Index + 1;
            if (j >= P.Numbers.Length) { return null; }

            return new Candidate { Index = j };
        }

        // Next sibling from current leaf
        // O(1)
        private Candidate Next(Data P, Candidate c)
        {
            int j = c.Index + 1;
            if (j >= P.Numbers.Length) { return null; }

            return new Candidate { Index = j };
        }

        private void Print(Data P, Candidate c, int depth)
        {
            _write(string.Format("path: {0}  \tsum: {1}  \tdepth: {2}\n",
                P.Path.Get(), P.WorkingSum, depth));
        }

        private void ShowStatus(Data P, Candidate c)
        {
            // Debug
            if (P.PathsTried % 500000 == 0)
            {
                _write(string.Format("Paths tried: {0:n0}  \tSolutions: {1}  \tPath: {2}\n",
                    P.PathsTried, P.Solutions, P.Path.Get()));
            }
        }
    }
}
