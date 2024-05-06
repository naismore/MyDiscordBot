using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace MyDiscordBot.commands
{
    public class TestCommands : BaseCommandModule
    {
        [Command("test")]
        public async Task MyFirstCommand(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync($"Hello {ctx.User.Mention}");
        }

        [Command("add")]
        public async Task Add(CommandContext ctx, int number1, int number2)
        {
            await ctx.Channel.SendMessageAsync($"{number1} + {number2} = {number1 + number2}");
        }
        [Command("embed")]
        public async Task EmbedMessage(CommandContext ctx)
        {
            var message = new DiscordMessageBuilder()
                .AddEmbed(new DiscordEmbedBuilder()
                .WithTitle("This My first Discord Embed")
                .WithDescription($"This command was executed by {ctx.User.Mention}")
                .WithColor(DiscordColor.Red));
            await ctx.Channel.SendMessageAsync(message);
        }

        [Command("embed1")]
        public async Task Embed1Message(CommandContext ctx)
        {
            var message = new DiscordEmbedBuilder
            {
                Title = "This My first Discord Embed",
                Description = $"This command was executed by {ctx.User.Mention}",
                Color = DiscordColor.Red,
            };
            await ctx.Channel.SendMessageAsync(message);
        }
    }
}
