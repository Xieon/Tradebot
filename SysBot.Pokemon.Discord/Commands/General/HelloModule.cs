using Discord.Commands;
using System.Threading.Tasks;

namespace SysBot.Pokemon.Discord
{
    public class HelloModule : ModuleBase<SocketCommandContext>
    {
        private const ulong XieonID = 745733120510394466;

        [Command("hello")]
        [Alias("hi")]
        [Summary("Say hello to the bot and get a response.")]
        public async Task PingAsync()
        {
            // Only allow Xieon to run this command
            if (Context.User.Id != XieonID)
            {
                await ReplyAsync("You are not authorized to use this command.").ConfigureAwait(false);
                await Context.Message.DeleteAsync();
                return;
            }

            var str = SysCordSettings.Settings.HelloResponse;
            var msg = string.Format(str, Context.User.Mention);

            await ReplyAsync(msg).ConfigureAwait(false);
            await Context.Message.DeleteAsync();
        }
    }
}
