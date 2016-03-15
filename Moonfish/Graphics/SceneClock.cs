using System.Diagnostics;

namespace Moonfish.Forms
{
    public class SceneClock
    {
        public readonly Stopwatch timer = new Stopwatch( );
        public long totalTime;
        public long updateTime;
        public double accumulator;
        public double currentTime;
        public double frameTime;
        private float _newTime;
        private long _baseTick;
        public const double DeltaTime = 0.09f;
        public const double MinFrameTime = 0.001f;

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

        public SceneClock( )
        {
        }

        public void IntegrateUpdate( )
        {
#if DEBUG
            updateTime = timer.ElapsedTicks - _baseTick;
#endif
            accumulator -= DeltaTime;
        }
    }
}