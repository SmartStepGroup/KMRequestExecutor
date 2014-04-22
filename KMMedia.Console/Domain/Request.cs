namespace KMMedia.Console.Domain {
    public class Request {
        protected readonly RequestExecutor requestExecutor;

        public Request(RequestExecutor requestExecutor, Service service) {
            this.requestExecutor = requestExecutor;
            Service = service;
        }

        public Service Service { get; private set; }

        public virtual void Execute() {
            requestExecutor.SetResponse(Service, new Response(), false);
        }
    }
}