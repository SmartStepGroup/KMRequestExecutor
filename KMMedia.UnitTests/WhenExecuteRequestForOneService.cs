#region Usings

using KMMedia.Console.Domain;

using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace KMMedia.UnitTests {
    [TestClass]
    public class WhenExecuteRequestForOneService {
        private TestableRequestExecutor requestExecutor;
        private SuccessRequest successRequest;
        private const string serviceName = "service";

        [TestInitialize]
        public void Initialize() {
            requestExecutor = new TestableRequestExecutor();
            successRequest = new SuccessRequest(requestExecutor);
        }

        [TestMethod]
        public void SuccessfullyExecuteSingleRequest() {
            Schedule(successRequest);

            requestExecutor.StartRequests();

            var requestWasSuccessfullyExecuted = requestExecutor.Responses[successRequest.Service].Item2;
            Assert.IsTrue(requestWasSuccessfullyExecuted);
        }

        private void Schedule(params Request[] requests) {
            foreach (var request in requests) {
                requestExecutor.Add(serviceName, request);
            }
        }
    }
}