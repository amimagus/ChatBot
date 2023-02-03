using DSharpPlus;
using DSharpPlus.EventArgs;

namespace SuperDuperBot;

public class Fritzbot
{

    public void initialize(DiscordClient client)
    {

        client.MessageCreated += OnMessageCreated;

    }

    private HashSet<string> _UsersAcknowledged = new();

    private async Task OnMessageCreated(DiscordClient client, MessageCreateEventArgs args)
    {

        if (args.Message.Content.StartsWith("ping"))
        {
            if (_UsersAcknowledged.Contains(args.Author.Username))
            {
                await client.SendMessageAsync(args.Channel,
                $"Stop bugging me, {args.Author.Username}!");
            }
            else
            {
                _UsersAcknowledged.Add(args.Author.Username);
                await client.SendMessageAsync(args.Channel,
                $"Hey, don't ping me, {args.Author.Username}.");
            }
        }

    }
}