using System;
using System.Threading;

namespace KMMedia.Console.Domain {
    public class Scheduler {
        private Action onTimeoutAction;
        private Timer timer;

        public virtual void Execute(Request request) {
            new Thread(request.Execute).Start();
        }

        public void ExecuteOnTimer(Action onTimeoutAction, int timeDurationInSeconds) {
            this.onTimeoutAction = onTimeoutAction;
            timer = new Timer(OnTimer, null, timeDurationInSeconds*1000, Timeout.Infinite);
        }

        private void OnTimer(Object stateInfo) {
            onTimeoutAction();
            timer.Dispose();
        }
    }
}