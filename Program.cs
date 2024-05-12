using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.SlashCommands;
using MyDiscordBot.commands;
using MyDiscordBot.config;
using MyDiscordBot.slash;

namespace AnxisBot
{
    class Bot
    {
        public static DiscordClient Client { get; set; }
        public static CommandsNextExtension Commands { get; set; }
        static async Task Main(string[] args)
        {
            var jsonReader = new JSONReader();
            await jsonReader.ReadJSON();

            var discordConfig = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = jsonReader.token,
                TokenType = TokenType.Bot,
                AutoReconnect = true
            };

            Client = new DiscordClient(discordConfig);

            Client.UseInteractivity(new InteractivityConfiguration()
            {
                Timeout = TimeSpan.FromSeconds(15)
            });

            Client.Ready += Client_Ready;
            Client.GuildMemberAdded += MemberAddedHandler;

            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { jsonReader.prefix },
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = false,
            };

            Commands = Client.UseCommandsNext(commandsConfig);

            var slashCommandsConfig = Client.UseSlashCommands();


            //Commands.RegisterCommands<TestCommands>();
            slashCommandsConfig.RegisterCommands<BasicSL>();
            //Commands.RegisterCommands<AdministrativeСommands>(); 

            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private static async Task MemberAddedHandler(DiscordClient sender, DSharpPlus.EventArgs.GuildMemberAddEventArgs args)
        {
            await Task.CompletedTask;
        }

        private static Task Client_Ready(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}