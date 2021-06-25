using UnityEngine;

namespace xOrfe.Utilities
{
    public class RandomUtility
    {
        private Random.State _randomState;
        public float LoadRandomValue()
        {
            Random.state = _randomState;
            float val = Random.value;
            _randomState = Random.state;
            Random.InitState(System.Environment.TickCount);
            return val;
        }
        public void SetRandomState(int seed)
        {
            Random.state = _randomState;
            Random.InitState(seed);
            _randomState = Random.state;
            Random.InitState(System.Environment.TickCount);
        }
    }
}
