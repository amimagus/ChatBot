using DSharpPlus;

namespace SuperDuperBot;

public static class DiscordExtensions
{
    private static Fritzbot? _TheBot;

    public static DiscordClient AddFritzbot(this DiscordClient client)
    {

        _TheBot = new Fritzbot();
        _TheBot.initialize(client);

        return client;

    }

}