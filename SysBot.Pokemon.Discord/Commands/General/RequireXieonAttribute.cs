using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace SysBot.Pokemon.Discord
{
    public class RequireXieonAttribute : PreconditionAttribute
    {
        private const ulong XieonID = 745733120510394466;

        public override Task<PreconditionResult> CheckPermissionsAsync(
            ICommandContext context,
            CommandInfo command,
            IServiceProvider services)
        {
            if (context.User.Id == XieonID)
                return Task.FromResult(PreconditionResult.FromSuccess());

            return Task.FromResult(
                PreconditionResult.FromError("You are not authorized to use this command.")
            );
        }
    }
}
