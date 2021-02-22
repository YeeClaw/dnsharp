using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace devSharp.Modules
{
    public class PublicModule : ModuleBase<SocketCommandContext>
    {
        // Dependency Injection will fill this value in for us

        [Command("ping")]
        [Alias("pong", "hello")]
        public async Task PingAsync()
        {
            long time = DateTime.Now.Millisecond;
            
            var message = await Context.Channel.SendMessageAsync("> Pong! :ping_pong:");
            await message.ModifyAsync(msg => msg.Content = "> Pong! :ping_pong:\n" + (DateTime.Now.Millisecond - time) + "ms");
        }

        // Get info on a user, or the user who invoked the command if one is not specified
        [Command("userinfo")]
        public async Task UserInfoAsync(IUser user = null)
        {
            user = user ?? Context.User;

            await ReplyAsync(user.ToString());
        }
    }
}
