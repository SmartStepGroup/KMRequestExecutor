#region Usings

using System;
using KMMedia.Console.Domain;

using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace KMMedia.UnitTests {
    [TestClass]
    public class WhenExecuteRequest {
        private TestableRequestExecutor requestExecutor;
        private SuccessfulRequest successfulRequest;
        private FailedRequest failedRequest;

        [TestInitialize]
        public void Initialize() {
            requestExecutor = new TestableRequestExecutor();
            successfulRequest = new SuccessfulRequest(requestExecutor);
            failedRequest = new FailedRequest(requestExecutor);
        }

        [TestMethod]
        public void SuccessfullyExecuteSingleRequest() {
            Schedule(successfulRequest);

            requestExecutor.StartRequests();

            var requestWasSuccessfullyExecuted = requestExecutor.Responses[successfulRequest.Service].Item2;
            Assert.IsTrue(requestWasSuccessfullyExecuted);
        }

        [TestMethod]
        public void SuccessfullyExecuteFirstRequestAndFailSecondRequest() {
            Schedule(successfulRequest, failedRequest);

            requestExecutor.StartRequests();

            var firstRequestWasSuccessfullyExecuted = requestExecutor.Responses[successfulRequest.Service].Item2;
            var secondRequestWasSuccessfullyExecuted = requestExecutor.Responses[failedRequest.Service].Item2;
            Assert.IsTrue(firstRequestWasSuccessfullyExecuted);
            Assert.IsFalse(secondRequestWasSuccessfullyExecuted);
        }

        private void Schedule(params Request[] requests) {
            foreach (var request in requests) {
                requestExecutor.Add(Guid.NewGuid().ToString(), request);
            }
        }
    }
}