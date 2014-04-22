using System;
using KMMedia.Console.Domain;

namespace KMMedia.UnitTests {
    public class SuccessfulRequest : Request {
        public SuccessfulRequest(RequestExecutor requestExecutor)
            : base(requestExecutor, new Service(TimeSpan.Zero, "Fake service")) {}
    }
}