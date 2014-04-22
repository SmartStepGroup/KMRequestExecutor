#region Usings

using System;
using System.Threading;

#endregion

namespace KMMedia.Console.Domain {
    public class Service {
        private readonly string name;

        private readonly TimeSpan responseTime;

        public Service(TimeSpan responseTime, string name) {
            this.name = name;
            this.responseTime = responseTime;
        }

        public string LoadData() {
            Thread.Sleep(responseTime);
            return string.Format("Data received from {0}", name);
        }
    }
}