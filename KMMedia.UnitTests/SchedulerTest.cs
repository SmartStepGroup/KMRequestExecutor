using System.Threading;
using KMMedia.Console.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KMMedia.UnitTests {
    [TestClass]
    public class SchedulerTest {
        private bool timedOutExecuted;

        [TestMethod]
        [Timeout(2000)]
        public void CanScheduleTimer() {
            var scheduler = new Scheduler();
            timedOutExecuted = false;

            scheduler.ExecuteOnTimer(() => timedOutExecuted = true, 1);
            WaitForTimeout();

            Assert.IsTrue(timedOutExecuted);
        }

        private void WaitForTimeout() {
            while (!timedOutExecuted) {
                Thread.Sleep(100);
                System.Console.WriteLine("Waiting for timer ...");
            }
        }
    }
}