using System.Threading.Tasks;
using System.Net.Http;

namespace DnsShutDown
{
    public class ShutDowner
    {
        public string username { get; set; }
        public string password { get; set; }
        public string ip { get; set; }

        private string base_url;
        private string shutdown_url;

        public ShutDowner()
        {
            username = "admin";
            password = "xxx";
            ip = "192.168.0.154";

            base_url = string.Format(@"http://{0}/goform/formLogin?f_login_type=0&f_LOGIN_NAME={1}&f_LOGIN_PASSWD={2}",
                ip, username, password);

            shutdown_url = string.Format(@"http://{0}/goform/sysShutDown?shootdown", ip);
        }

        public async Task shutAsync()
        {
            var client = new HttpClient();
            await client.GetStringAsync(base_url);
            await client.GetStringAsync(shutdown_url);

        }
    }

}

