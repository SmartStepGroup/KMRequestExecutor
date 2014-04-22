using System;

namespace KMMedia.Console.Domain {
    public class Request {
        private readonly Service service;

        public Request(Service service) {
            this.service = service;
        }

        public void Execute() {
            System.Console.WriteLine(service.LoadData());
        }
    }
}