namespace KMMedia.Console.Domain {
    public class Request {
        private readonly RequestExecutor requestExecutor;
        private readonly Service service;

        public Request(RequestExecutor requestExecutor, Service service) {
            this.requestExecutor = requestExecutor;
            this.service = service;
        }

        public virtual void Execute() {
            requestExecutor.SetResponse();
        }
    }
}