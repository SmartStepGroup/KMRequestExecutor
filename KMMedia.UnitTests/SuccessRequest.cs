using System;
using System.Threading;
using KMMedia.Console.Domain;

namespace KMMedia.UnitTests {
    public class SuccessRequest : Request {
        public SuccessRequest(RequestExecutor requestExecutor) : base(requestExecutor, new Service(TimeSpan.Zero, "Fake service")) {}

        public override void Execute() {
            base.Execute();
            IsExecuted = true;
        }

        public bool IsExecuted { get; private set; }
    }
}