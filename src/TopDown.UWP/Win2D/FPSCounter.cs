using System;
using System.Diagnostics;

namespace TopDown.UWP
{
    public class FPSCounter
    {
        private const int SampleSize = 10;
        private double _fps = 60;
        private readonly Stopwatch _sw = Stopwatch.StartNew();
        private long _lastElapsed = -1;
        public double FPS => Math.Round(_fps, 2);

        public void Frame()
        {
            if(_lastElapsed < 0)
            {
                _lastElapsed = _sw.ElapsedMilliseconds;
                return;
            }

            long current = _sw.ElapsedMilliseconds;
            long diff = current - _lastElapsed;
            double currentFps = 1000.0 / diff;
            _fps = (_fps * (SampleSize - 1) + currentFps) / SampleSize;
            _lastElapsed = current;
        }
    }
}
