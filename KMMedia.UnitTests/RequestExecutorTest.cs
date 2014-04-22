using System;
using System.Threading;
using KMMedia.Console.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KMMedia.UnitTests {
    [TestClass]
    public class RequestExecutorTest {
        [TestMethod]
        [Timeout(2000)]
        public void CanExecuteOneRequest() {
            var requestExecutor = new RequestExecutor();
            var request = new RequestFake(requestExecutor, new Service(1.Seconds(), ""), 1);
            requestExecutor.Add("service", request);

//            requestExecutor.AsyncWait(2);
            requestExecutor.StartRequests();
            WaitWhileExecuting(request);

            Assert.IsTrue(request.IsExecuted);
        }

        private void WaitWhileExecuting(RequestFake request) {
            while (!request.IsExecuted) {
                Thread.Sleep(10);
            }
        }
    }

    public class RequestFake : Request {
        private readonly int sleepInSeconds;

        public RequestFake(RequestExecutor requestExecutor, Service service, int sleepInSeconds) : base(requestExecutor, service) {
            this.sleepInSeconds = sleepInSeconds;
        }

        public override void Execute() {
            Thread.Sleep(sleepInSeconds*1000);
            base.Execute();
            IsExecuted = true;
        }

        public bool IsExecuted { get; private set; }
    }
}