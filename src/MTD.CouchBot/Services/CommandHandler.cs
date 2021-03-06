﻿using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Options;
using MTD.CouchBot.Domain.Models.Bot;
using System;
using System.Threading.Tasks;

namespace MTD.CouchBot.Services
{
    public class CommandHandler
    {
        private readonly DiscordShardedClient _discord;
        private readonly CommandService _commands;
        private readonly BotSettings _botSettings;
        private readonly IServiceProvider _provider;
        private readonly FileService _fileService;
        private readonly CustomCommandService _customCommandService;

        public CommandHandler(
            DiscordShardedClient discord,
            CommandService commands,
            IOptions<BotSettings> botSettings,
            IServiceProvider provider,
            FileService fileService,
            CustomCommandService customCommandService)
        {
            _discord = discord;
            _commands = commands;
            _botSettings = botSettings.Value;
            _provider = provider;
            _fileService = fileService;
            _customCommandService = customCommandService;

            _discord.MessageReceived += OnMessageReceivedAsync;
        }


        private async Task OnMessageReceivedAsync(SocketMessage s)
        {
            if (!(s is SocketUserMessage msg)) return;
            if (msg.Author == _discord.CurrentUser) return;

            var context = new ShardedCommandContext(_discord, msg);
            var argPos = 0;
            var server = _fileService.GetConfiguredServerById(context.Guild.Id);
            var prefix = server.Prefix ?? _botSettings.BotConfig.Prefix;

            if (msg.HasStringPrefix($"{prefix} ", ref argPos))
            {
                await _commands.ExecuteAsync(context, argPos, _provider);
            }
            else
            {
                await _customCommandService.ProcessRoleCommands(server, msg, context);
                await _customCommandService.ProcessCustomCommands(server, msg, context);
            }
        }
    }
}
