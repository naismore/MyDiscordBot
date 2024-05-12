using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace MyDiscordBot.serverconfig
{
    public class ServerConfig
    {
        public string weclomeMessage { get; set; }
        public ulong welcomeRole { get; set; }

        public async Task SaveConfigFile(ulong serverID)
        {
            ServerConfigStruct data = new ServerConfigStruct();
            data.welcomeRole = welcomeRole;
            data.weclomeMessage = weclomeMessage;
            string serverConfig = JsonConvert.SerializeObject(data);

            using (StreamWriter sw = new StreamWriter("..//" + Convert.ToString(serverID) + ".json"))
            {
                sw.WriteLine(serverConfig);
            }
            
        }

        public async Task SetWelcomeMessage(string welcomeMessage)
        {
            this.weclomeMessage = welcomeMessage;
            await Task.CompletedTask;
        }

        public async Task SetWelcomeRole(ulong roleID)
        {
            this.welcomeRole = roleID;
            await Task.CompletedTask;
        }
    }

    internal sealed class ServerConfigStruct
    {
        public string weclomeMessage { get; set; }
        public ulong welcomeRole { get; set; }
    }
}
