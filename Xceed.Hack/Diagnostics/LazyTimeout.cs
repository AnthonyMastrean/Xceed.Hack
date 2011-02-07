using System;

namespace Xceed.Hack.Diagnostics
{
    public class LazyTimeout
    {
        private readonly TimeSpan _duration;
        private readonly DateTime _start = DateTime.UtcNow;

        public bool HasExpired
        {
            get { return GetElapsedTime() > _duration; }
        }

        public LazyTimeout(TimeSpan duration)
        {
            _duration = duration;
        }

        public TimeSpan GetElapsedTime()
        {
            return DateTime.UtcNow - _start;
        }
    }
}