using AnxisBot;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;

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

        [Command("voting")]
        public async Task Voting(CommandContext ctx, string option1, string option2, string option3, string option4, [RemainingText] string votingTitle)
        {
            var interactivity = Bot.Client.GetInteractivity();

            DiscordEmoji[] emojiOptions = { DiscordEmoji.FromName(Bot.Client, ":one:"),
                                            DiscordEmoji.FromName(Bot.Client, ":two:"),
                                            DiscordEmoji.FromName(Bot.Client, ":three:"),
                                            DiscordEmoji.FromName(Bot.Client, ":four:") };

            string optionDescribtion = $"{emojiOptions[0]} | {option1} \n" +
                                        $"{emojiOptions[1]} | {option2} \n" +
                                        $"{emojiOptions[2]} | {option3} \n" +
                                        $"{emojiOptions[3]} | {option4} \n";


            var votingMessage = new DiscordEmbedBuilder
            {
                Color = DiscordColor.Red,
                Title = votingTitle,
                Description = optionDescribtion,
            };

            var sentVoting = await ctx.Channel.SendMessageAsync(embed: votingMessage);

            foreach (var emoji in emojiOptions)
            {
                await sentVoting.CreateReactionAsync(emoji);
            }
        }
    }
}
