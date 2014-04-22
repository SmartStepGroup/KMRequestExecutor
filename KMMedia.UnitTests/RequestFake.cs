using System;
using System.Threading;
using KMMedia.Console.Domain;

namespace KMMedia.UnitTests {
    public class RequestFake : Request {
        private readonly TimeSpan sleepTime;

        public RequestFake(RequestExecutor requestExecutor, TimeSpan sleepTime) : base(requestExecutor, new Service(TimeSpan.Zero, "Fake service")) {
            this.sleepTime = sleepTime;
        }

        public override void Execute() {
            Thread.Sleep(sleepTime.Milliseconds);
            base.Execute();
            IsExecuted = true;
        }

        public bool IsExecuted { get; private set; }
    }
}