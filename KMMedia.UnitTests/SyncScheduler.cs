using KMMedia.Console.Domain;

namespace KMMedia.UnitTests {
    public class SyncScheduler : Scheduler {
        public override void Execute(Request request) {
            request.Execute();
        }
    }
}