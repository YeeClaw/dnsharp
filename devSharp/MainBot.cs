using System;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace devSharp
{
    class MainBot
    {
        private readonly DiscordSocketClient _client;
        private readonly String token = Config.getToken();
        public static void Main(string[] args)
        {

            new MainBot().MainAsync().GetAwaiter().GetResult();
        }

        public MainBot()
        {

            // Dispose of client when done with this bot
            _client = new DiscordSocketClient();

            _client.Log += LogAsync;
            _client.Ready += ReadyAsync;
            _client.MessageReceived += MessageReceivedAsync;
        }

        public async Task MainAsync()
        {
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // Block program until it's closed
            await Task.Delay(Timeout.Infinite);
        }

        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }

        private Task ReadyAsync()
        {
            Console.WriteLine($"{_client.CurrentUser} is connected!");
            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(SocketMessage message)
        {
            if (message.Author.Id == _client.CurrentUser.Id)
                return;

            if (message.Content == "!ping")
                await message.Channel.SendMessageAsync("pong! :ping_pong:");
        }
    }
}
