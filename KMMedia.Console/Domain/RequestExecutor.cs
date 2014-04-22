#region Usings

using System;
using System.Collections.Generic;
using System.Threading;

#endregion

namespace KMMedia.Console.Domain {
    public class RequestExecutor {
        private readonly Dictionary<string, Request> requests = new Dictionary<string, Request>();
        protected readonly Dictionary<Service, Tuple<Response, bool>> responses = new Dictionary<Service, Tuple<Response, bool>>();
        private readonly Scheduler scheduler;
        private int pendingRequestsCount;

        public RequestExecutor(Scheduler scheduler) {
            this.scheduler = scheduler;
        }

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

        public void SetResponse(Service service, Response response, bool callFailed) {
            System.Console.WriteLine("pendingRequestsCount--");
            Interlocked.Decrement(ref pendingRequestsCount);
            responses[service] = new Tuple<Response, bool>(response, !callFailed);
        }

        public void Add(string serviceName, Request request) {
            requests[serviceName] = request;
        }
    }
}