using System;

namespace BTs
{
    // succeed if any children succeeds
    // fail if all children fail

    public class ParallelOr : Parallel
    {
        public ParallelOr() : base() { }
        public ParallelOr(string name) : base(name) { }

        public ParallelOr(params ITickable[] tasks) : base()
        {
            foreach (ITickable t in tasks)
            {
                this.AddChild(t);
            }
        }
        public ParallelOr(string name, params ITickable[] tasks) : base(name)
        {
            foreach (ITickable t in tasks)
            {
                this.AddChild(t);
            }
        }


        public override Status OnTick()
        {
            if (status == Status.FAILED || status == Status.SUCCEEDED)
                throw new Exception("ParellelOr ticked in " + status.ToString() + " status");

            // Actual policy implemented by base class
            return base.OrBased_OnTick();
        }
    }
}
