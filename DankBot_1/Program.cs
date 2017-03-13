using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace DankBot_1
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Start();
        }
        
        private DiscordClient _client;

        public void Start()
        {
            _client = new DiscordClient();

            _client.MessageReceived += async (s, e) =>
            {
                if (!e.Message.IsAuthor) // so the bot doesn't trigger on it's own messages
                {
                    // just repeat back what the message was
                    await e.Channel.SendMessage(e.Message.Text);
                }
            };

            // basic console logging
            _client.Log.Message += (s, e) => {
                Console.WriteLine($"[{e.Severity}] {e.Source}: {e.Message}");
            };

            _client.ExecuteAndWait(async () => {
                // DankBot_1#2746
                // currently have an app assigned to my account, but you register your own https://discordapp.com/developers/applications/me
                // grab the client ID then authorize the bot for your channel replacing the client ID
                // https://discordapp.com/oauth2/authorize?client_id=CLIENT_ID_GOES_HERE&scope=bot&permissions=0
                // remember to grant permissions to the bot account (either by setting the parameter to something or manually when it's in the channel
                
                // on the application page, reveal the token and replace below
                await _client.Connect("TOKEN_GOES_HERE", TokenType.Bot);
            });
        }
    }
}
