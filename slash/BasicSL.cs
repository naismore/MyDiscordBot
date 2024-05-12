using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using MyDiscordBot.serverconfig;

namespace MyDiscordBot.slash
{
    public class BasicSL : ApplicationCommandModule
    {
        [SlashCommand("add", "First test command")]
        public async Task TestCommand(InteractionContext ctx)
        {
            await ctx.Interaction.CreateResponseAsync(DSharpPlus.InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("HelloWorld!"));
        }

        [SlashCommand("setwm", "Set the welcome message for new members")]
        public async Task SetWelcomeMessage(InteractionContext ctx, [Option("message", "Type the welcome message")] string welcomeMessage) 
        {
            await ctx.DeferAsync();

            var welcomeMessageNotification = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Purple,
                Title = "The welcome message has been changed",
                Description = "Now: " + welcomeMessage
            };

            await ctx.EditResponseAsync(new DiscordWebhookBuilder().AddEmbed(welcomeMessageNotification));
        }
        [SlashCommand("save", "Save server config to JSON file")]
        public async Task SaveServerConfig(InteractionContext ctx)
        {
            ServerConfig sc = new ServerConfig();

            await sc.SetWelcomeMessage("Hello!");
            await sc.SetWelcomeRole(123);
            await sc.SaveConfigFile(ctx.Guild.Id);
            await ctx.CreateResponseAsync(DSharpPlus.InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("Конфиг сервера был сохранен"));
        }
    }
}
