namespace KMMedia.Console.Domain {
    public class Collector {
        private readonly Service googleService = new Service(5.Seconds(), "Google");
        private readonly Service microsoftService = new Service(1.Seconds(), "Microsoft");
        private readonly Service yandexService = new Service(3.Seconds(), "Yandex");
        private readonly RequestExecutor requestExecutor = new RequestExecutor(new Scheduler());

        public void ScheduleRequests() {
            requestExecutor.Add("Google", new Request(requestExecutor, googleService));
            requestExecutor.Add("Microsoft", new Request(requestExecutor, microsoftService));
            requestExecutor.Add("Yandex", new Request(requestExecutor, yandexService));

            requestExecutor.StartRequests();
        }
    }
}