using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KMMedia.UnitTests {
    [TestClass]
    public class RequestExecutorTest {
        [TestMethod]
        public void CanExecuteOneRequest() {
            var requestExecutor = new TestableRequestExecutor();
            var request = new RequestFake(requestExecutor);
            requestExecutor.Add("service", request);

            requestExecutor.StartRequests();

            var requestWasSuccessfullyExecuted = requestExecutor.Responses[request.Service].Item2;
            Assert.IsTrue(requestWasSuccessfullyExecuted);
        }
    }
}