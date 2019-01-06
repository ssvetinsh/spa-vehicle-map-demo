using System.Net;
using System.Text;

namespace SpaVehicleMapDemo.BusinessLogic.Helpers
{
    public static class WebRequestHelper
    {
        public static string GetUrlResponseData(string url)
        {
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                return client.DownloadString(url);
            }
        }
    }
}
