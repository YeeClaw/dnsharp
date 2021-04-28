using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using System.IO;

namespace devSharp.Modules
{
    public class PublicModule : ModuleBase<SocketCommandContext>
    {
        // Dependency Injection will fill this value in for us

        private string path = Config.getPath();
        
        [Command("ping")]
        [Alias("pong", "hello")]
        public async Task PingAsync(String pong = null)
        {
            if (pong == "pong")
            {
                await Context.Channel.SendMessageAsync("That's not how this works");
            }
            else
            {
                long time = DateTime.Now.Millisecond;
            
                var message = await Context.Channel.SendMessageAsync("> Pong! :ping_pong:");
                await message.ModifyAsync(msg => msg.Content = "> Pong! :ping_pong:\n" + (DateTime.Now.Millisecond - time) + "ms");
            }
            
        }
        
        // WIP. Build off of this base template with more information !
        [Command("userinfo")]
        public async Task UserInfoAsync(IUser user = null)
        {
            user ??= Context.User;

            await ReplyAsync(user.ToString());
        }

        [Command("+pp")]
        public async Task ProudPointsAsync(IGuildUser user, int amount)
        {
            if (Context.User.Id == 190525744907157505)
            {
                await Context.Channel.SendMessageAsync(user + " has gained " + amount + " proud point(s)!");
                
                /*
                string scoreformat = "" + user.ToString() + "; " + amount;
                await File.WriteAllTextAsync(path + "\\ProudPointsScore.txt", scoreformat);
                */
            }
            else
            {
                await Context.Channel.SendMessageAsync("You don't have permission to use this command");
            }
        }

        [Command("ppamount")]
        public async Task CallPointsAsync(IGuildUser user)
        {
            //await Context.Channel.SendMessageAsync(user + " has " + amount + " proud point(s)");
        }
    }
}
