using DSharpPlus;
using Microsoft.Extensions.Configuration;
using SuperDuperBot;

var source = new CancellationTokenSource();

var config = new ConfigurationBuilder()
    .AddUserSecrets(typeof(Program).Assembly, true)
    .Build();

var client = new DiscordClient(new DiscordConfiguration
{
    Token = config["discordtoken"],
    TokenType = TokenType.Bot
});

client.AddFritzbot();

var token = source.Token;
await client.ConnectAsync();

while (!token.IsCancellationRequested)
{
    await Task.Delay(100);
}
