using System;

namespace KMMedia.Console.Domain {
    public static class Extensions {
        public static TimeSpan Seconds(this int seconds) {
            return TimeSpan.FromSeconds(seconds);
        }
    }
}