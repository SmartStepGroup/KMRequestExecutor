using System;
using System.Collections.Generic;
using KMMedia.Console.Domain;

namespace KMMedia.UnitTests {
    public class TestableRequestExecutor : RequestExecutor {
        public TestableRequestExecutor() : base(new SyncScheduler()) {}

        public Dictionary<Service, Tuple<Response, bool>> Responses {
            get { return responses; }
        }
    }
}