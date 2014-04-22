#region Usings

using System.Collections.Generic;
using System.Threading;

#endregion

namespace KMMedia.Console.Domain {
    public class RequestExecutor {
        private readonly Dictionary<string, Request> requests = new Dictionary<string, Request>();
        private readonly Scheduler scheduler = new Scheduler();
        private int pendingRequestsCount;

        public bool IsTimedOut { get; private set; }

        public void AsyncWait(int timeDurationInSeconds) {
            scheduler.ExecuteOnTimer(AsyncOnTimer, timeDurationInSeconds);
        }

        private void AsyncOnTimer() {
            // Cancel pending requests
            IsTimedOut = true;
        }

        public void StartRequests() {
            foreach (var request in requests) {
                System.Console.WriteLine("pendingRequestsCount++");
                Interlocked.Increment(ref pendingRequestsCount);
                scheduler.Execute(request.Value);
            }
        }

        public void SetResponse() {
            System.Console.WriteLine("pendingRequestsCount--");
            Interlocked.Decrement(ref pendingRequestsCount);
        }

        public void Add(string serviceName, Request request) {
            requests[serviceName] = request;
        }
    }
}