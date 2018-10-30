﻿using System;
using Discord;
using System.Threading.Tasks;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using MTD.CouchBot.Domain.Models;
using MTD.CouchBot.Domain;

namespace MTD.CouchBot.Services
{
    public class MessagingService : BaseService
    {
        private readonly DiscordSocketClient _discord;
        private readonly GuildInteractionService _guildInteractionService;
        private readonly IConfiguration _configuration;

        public MessagingService(DiscordSocketClient discord, GuildInteractionService guildInteractionService,
            IConfiguration configuration) : base(discord)
        {
            _discord = discord;
            _guildInteractionService = guildInteractionService;
            _configuration = configuration;
        }

        public async Task<BroadcastMessage> BuildMessage(string channel, string gameName, string title, string url,
            string avatarUrl, string thumbnailUrl, string platform, string channelId)
        {
            var embed = new EmbedBuilder();
            var author = new EmbedAuthorBuilder();
            var footer = new EmbedFooterBuilder();

            var botName = _discord.CurrentUser.Username;

            return new BroadcastMessage();
        }

        //public async Task<BroadcastMessage> BuildMessage(string channel,
        //    string gameName, string title, string url, string avatarUrl, string thumbnailUrl, string platform,
        //    string channelId, DiscordServer server, ulong discordChannelId, string teamName, bool owner,
        //    int? viewers = null, int? totalViews = null, int? followers = null)
        //{
        //    var embed = new EmbedBuilder();
        //    var author = new EmbedAuthorBuilder();
        //    var footer = new EmbedFooterBuilder();

        //    if (server.LiveMessage == null)
        //    {
        //        server.LiveMessage = "%CHANNEL% just went live with %GAME% - %TITLE% - %URL%";
        //    }

        //    var botName = _discord.CurrentUser.Username;

        //    try
        //    {
        //        botName = ((IGuildUser)_discord.GetGuild(server.Id).GetUser(ulong.Parse(_configuration["Ids:BotId"])))
        //            .Nickname;
        //    }
        //    catch (Exception)
        //    {
        //        // Nothing. It's fine. Everything is fine.
        //    }

        //    author.IconUrl = _discord.CurrentUser.GetAvatarUrl() + "?_=" + Guid.NewGuid().ToString().Replace("-", "");
        //    author.Name = botName;
        //    author.Url = url;
        //    footer.Text = "[" + platform + "] - " + DateTime.UtcNow.AddHours(server.TimeZoneOffset);
        //    embed.Author = author;

        //    var allowEveryone = false;

        //    if (platform.Equals(Constants.Mixer))
        //    {
        //        embed.Color = Constants.Blue;
        //        embed.ThumbnailUrl = avatarUrl != null ?
        //                avatarUrl + "?_=" + Guid.NewGuid().ToString().Replace("-", "") :
        //                "https://mixer.com/_latest/assets/images/main/avatars/default.jpg";
        //        footer.IconUrl = "http://couchbot.io/img/mixer2.png";
        //        allowEveryone = owner ? server.AllowMentionOwnerMixerLive : server.AllowMentionMixerLive;
        //    }
        //    else if (platform.Equals(Constants.YouTubeGaming))
        //    {
        //        embed.Color = Constants.Red;
        //        embed.ThumbnailUrl = avatarUrl + "?_=" + Guid.NewGuid().ToString().Replace("-", "");
        //        footer.IconUrl = "http://couchbot.io/img/ytg.jpg";
        //        allowEveryone = owner ? server.AllowMentionOwnerYouTubeLive : server.AllowMentionYouTubeLive;
        //    }
        //    else if (platform.Equals(Constants.Twitch))
        //    {
        //        embed.Color = Constants.Purple;
        //        embed.ThumbnailUrl = avatarUrl != null ?
        //                avatarUrl + "?_=" + Guid.NewGuid().ToString().Replace("-", "") :
        //                "https://static-cdn.jtvnw.net/jtv_user_pictures/xarth/404_user_70x70.png";
        //        footer.IconUrl = "http://couchbot.io/img/twitch.jpg";
        //        allowEveryone = owner ? server.AllowMentionOwnerTwitchLive : server.AllowMentionTwitchLive;
        //    }
        //    else if (platform.Equals(Constants.Smashcast))
        //    {
        //        embed.Color = Constants.Green;
        //        embed.ThumbnailUrl = avatarUrl + "?_=" + Guid.NewGuid().ToString().Replace("-", "");
        //        footer.IconUrl = "http://couchbot.io/img/smashcast2.png";
        //        allowEveryone = owner ? server.AllowMentionOwnerSmashcastLive : server.AllowMentionSmashcastLive;
        //    }
        //    else if (platform.Equals(Constants.Mobcrush))
        //    {
        //        embed.Color = Constants.Yellow;
        //        embed.ThumbnailUrl = avatarUrl + "?_=" + Guid.NewGuid().ToString().Replace("-", "");
        //        footer.IconUrl = "http://couchbot.io/img/mobcrush.jpg";
        //        allowEveryone = owner ? server.AllowMentionOwnerMobcrushLive : server.AllowMentionMobcrushLive;
        //    }

        //    embed.Description = server.LiveMessage
        //        .Replace("%CHANNEL%", Format.Sanitize(channel))
        //        .Replace("%GAME%", gameName)
        //        .Replace("%TITLE%", title)
        //        .Replace("%URL%", url);
        //    embed.Title = channel + (string.IsNullOrEmpty(teamName) ? "" : " from the team '" + teamName + "'") + " has gone live!";
        //    embed.ImageUrl = server.AllowThumbnails ? thumbnailUrl + "?_=" + Guid.NewGuid().ToString().Replace("-", "") : "";
        //    embed.Footer = footer;

        //    if (server.DisplayStreamStatistics)
        //    {
        //        if (!platform.Equals(Constants.YouTubeGaming) && !platform.Equals(Constants.YouTubeGaming))
        //        {
        //            if (!string.IsNullOrEmpty(gameName))
        //            {
        //                embed.Fields.Add(new EmbedFieldBuilder()
        //                {
        //                    IsInline = true,
        //                    Name = "Game",
        //                    Value = gameName
        //                });
        //            }
        //        }

        //        if (followers != null)
        //        {
        //            embed.Fields.Add(new EmbedFieldBuilder()
        //            {
        //                IsInline = true,
        //                Name = "Followers",
        //                Value = followers
        //            });
        //        }

        //        if (totalViews != null)
        //        {
        //            embed.Fields.Add(new EmbedFieldBuilder()
        //            {
        //                IsInline = true,
        //                Name = "Total Views",
        //                Value = totalViews
        //            });
        //        }
        //    }

        //    var message = "";

        //    var broadcastMessage = new BroadcastMessage()
        //    {
        //        GuildId = server.Id,
        //        ChannelId = discordChannelId,
        //        UserId = channelId,
        //        Message = message,
        //        Platform = platform,
        //        Embed = (!server.UseTextAnnouncements ? embed.Build() : null),
        //        DeleteOffline = server.DeleteWhenOffline
        //    };

        //    return broadcastMessage;
        //}
    }
}