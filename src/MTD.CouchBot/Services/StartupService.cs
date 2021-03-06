﻿using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Options;
using MTD.CouchBot.Domain.Models.Bot;
using MTD.CouchBot.Domain.Utilities;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace MTD.CouchBot.Services
{
    public class StartupService
    {
        private readonly DiscordShardedClient _discord;
        private readonly CommandService _commands;
        private readonly BotSettings _botSettings;
        private readonly IServiceProvider _serviceProvider;

        public StartupService(
            DiscordShardedClient discord,
            CommandService commands,
            IOptions<BotSettings> botSettings, 
            IServiceProvider serviceProvider)
        {
            _botSettings = botSettings.Value;
            _discord = discord;
            _commands = commands;
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync()
        {
            Logging.LogInfo("Logging In");

            var discordToken = _botSettings.KeySettings.DiscordToken;

            if (string.IsNullOrWhiteSpace(discordToken))
                throw new Exception("Please enter your bot's token into the `BotSettings.json` file found in the applications root directory.");

            await _discord.LoginAsync(TokenType.Bot, discordToken);     
            await _discord.StartAsync();                                

            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _serviceProvider);

            Logging.LogInfo("Completed - Logging In");
        }

    }
}
