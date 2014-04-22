#region Usings

using KMMedia.Console.Domain;

#endregion

namespace KMMedia.Console {
    internal class Program {
        private static void Main(string[] args) {
            new Collector().ScheduleRequests();

            System.Console.ReadKey();
        }
    }
}