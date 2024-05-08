using DSharpPlus.SlashCommands;

namespace MyDiscordBot.slash
{
    public class BasicSL : ApplicationCommandModule
    {
        [SlashCommand("test", "First test command")]
        public async Task TestCommand(InteractionContext ctx)
        {
            
        }
    }
}
