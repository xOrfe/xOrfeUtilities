using UnityEngine;

namespace xOrfe.Utilities
{
    public class StepUtility
    {
        private int step = 0;
        private int bookedStep = 0;
        
        public int Step => step;
        public int BookedStep => bookedStep;

        public int BookAStep()
        {
            return bookedStep++;
        }
        public int TakeAStep()
        {
            return step++;
        }
    }
}
