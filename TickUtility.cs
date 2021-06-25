using System;
using UnityEngine;

namespace xOrfe.Utilities
{
    public class TickUtility : SingletonUtility<TickUtility>
    {
        private int tick = 0;
        private bool started = false;
        public int Tick => tick;
        private void FixedUpdate()
        {
            if (started) tick++;
        }
        public void StartCounting()
        {
            started = true;
        }
        public void StopCounting()
        {
            started = false;
        }
    }
}
