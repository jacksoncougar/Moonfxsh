using System;
using System.Diagnostics;

namespace Sunfish.Forms
{
    public class SceneClock
    {
        public readonly Stopwatch timer = new Stopwatch( );
        public long totalTime;
        public float updateTime;
        public double accumulator;
        public double currentTime;
        public double frameTime;
        private float _newTime;
        private long _baseTick;
        public const double DeltaTime = 0.09f; //90ms
        public const double MinFrameTime = 0.001f;//1ms

        public void Tick( )
        {
#if DEBUG
            totalTime = timer.ElapsedTicks - _baseTick;
#endif
            _baseTick = timer.ElapsedTicks;
            _newTime = timer.ElapsedMilliseconds / 1000f;
            frameTime = _newTime - currentTime;
            if (frameTime > 0.25) frameTime = 0.25;
        }
        
        public void Tock( )
        {
            currentTime = _newTime;
            accumulator += frameTime;
        }

        public bool TimeForUpdate( ) => accumulator >= DeltaTime;

        public bool Sleep => frameTime < MinFrameTime;

        public void IntegrateUpdate( )
        {
#if DEBUG
            updateTime = (float)new TimeSpan( timer.ElapsedTicks - _baseTick ).TotalMilliseconds;
#endif
            accumulator -= DeltaTime;
        }
    }
}