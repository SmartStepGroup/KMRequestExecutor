using System.Threading;
using KMMedia.Console.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KMMedia.UnitTests {
    [TestClass]
    public class RequestExecutorTest {
        [TestMethod]
        [Timeout(2000)]
        public void CanExecuteOneRequest() {
            var requestExecutor = new RequestExecutor(new Scheduler());
            var request = new RequestFake(requestExecutor, 1.Seconds());
            requestExecutor.Add("service", request);

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
}