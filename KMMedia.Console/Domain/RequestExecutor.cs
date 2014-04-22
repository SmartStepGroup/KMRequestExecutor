#region Usings

using System.Threading.Tasks;

#endregion

namespace KMMedia.Console.Domain {
    public class RequestExecutor {
        public void Execute(Request request) {
            Task.Factory.StartNew(request.Execute);
        }
    }
}