using AnxisBot;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDiscordBot.commands
{
    internal class AdministrativeСommands : BaseCommandModule
    {
        [Command("ad1")]
        public async Task Test(CommandContext ctx)
        {
            var interactivity = Bot.Client.GetInteractivity();

            var messageToRetrieve = await interactivity.WaitForMessageAsync(message => message.Content == "Hello");

            if (messageToRetrieve.Result.Content == "Hello")
            {
                await ctx.Channel.SendMessageAsync($"{ctx.User.Username} said Hello");
            }
        }
    }
}
