using System;
using System.Threading;
using KMMedia.Console.Domain;

namespace KMMedia.UnitTests {
    public class FailedRequest : Request {
        public FailedRequest(RequestExecutor requestExecutor) : base(requestExecutor, new Service(TimeSpan.Zero, "Fake service")) {}

        public override void Execute() {
            requestExecutor.SetResponse(Service, new Response(), true);
        }
    }
}