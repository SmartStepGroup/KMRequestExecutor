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

            Assert.IsTrue(requestExecutor.Responses[request.Service].Item2);
        }
    }
}