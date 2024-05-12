using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

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
    }
}
