namespace KMMedia.Console.Domain {
    public class Collector {
        private readonly Service googleService = new Service(5.Seconds(), "Google");

        private readonly Service microsoftService = new Service(1.Seconds(), "Microsoft");

        private readonly Service yandexService = new Service(3.Seconds(), "Yandex");

        private readonly RequestExecutor requestExecutor = new RequestExecutor();

        public void ScheduleRequests() {
            var requests = new[] {
                      new Request(googleService), 
                      new Request(microsoftService), 
                      new Request(yandexService)
                  };

            foreach (var request in requests) {
                requestExecutor.Execute(request);
            }
        }
    }
}