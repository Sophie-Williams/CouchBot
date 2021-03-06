﻿using Discord.Commands;
using Microsoft.Extensions.Options;
using MTD.CouchBot.Domain.Models.Bot;
using MTD.CouchBot.Domain.Utilities;
using MTD.CouchBot.Services;
using System.Threading.Tasks;

namespace MTD.CouchBot.Modules
{
    [Group("allow"), Summary("Subset of Commands to configure server settings.")]
    public class Allow : BaseModule
    {
        private readonly FileService _fileService;

        public Allow(IOptions<BotSettings> botSettings, FileService fileService) : base (botSettings)
        {
            _fileService = fileService;
        }

        [Command("mention"), Summary("Sets use of a mention tag.")]
        public async Task Mention(string trueFalse)
        {
            if (!IsAdmin)
            {
                return;
            }

            var server = _fileService.GetConfiguredServerById(Context.Guild.Id);

            server.AllowEveryone = bool.Parse(trueFalse);

            server.AllowMentionMixerLive = bool.Parse(trueFalse);
            server.AllowMentionMobcrushLive = bool.Parse(trueFalse);
            server.AllowMentionPicartoLive = bool.Parse(trueFalse);
            server.AllowMentionPiczelLive = bool.Parse(trueFalse);
            server.AllowMentionSmashcastLive = bool.Parse(trueFalse);
            server.AllowMentionTwitchLive = bool.Parse(trueFalse);
            server.AllowMentionYouTubeLive = bool.Parse(trueFalse);
            server.AllowMentionOwnerLive = bool.Parse(trueFalse);
            server.AllowMentionOwnerMixerLive = bool.Parse(trueFalse);
            server.AllowMentionOwnerMobcrushLive = bool.Parse(trueFalse);
            server.AllowMentionOwnerPicartoLive = bool.Parse(trueFalse);
            server.AllowMentionOwnerPiczelLive = bool.Parse(trueFalse);
            server.AllowMentionOwnerSmashcastLive = bool.Parse(trueFalse);
            server.AllowMentionOwnerTwitchLive = bool.Parse(trueFalse);
            server.AllowMentionOwnerYouTubeLive = bool.Parse(trueFalse);
            server.AllowMentionYouTubePublished = bool.Parse(trueFalse);
            server.AllowMentionOwnerYouTubePublished = bool.Parse(trueFalse);

            await _fileService.SaveDiscordServer(server, Context.Guild);
            await Context.Channel.SendMessageAsync("Allow everyone has been set to: " + trueFalse);
        }

        [Command("mention"), Summary("Sets use of a mention tag.")]
        public async Task Mention(string platform, string type, string trueFalse)
        {
            if (!IsAdmin)
            {
                return;
            }

            var platformLower = platform.ToLower();
            var typeLower = type.ToLower();
            
            if (!platformLower.Equals("mixer") && !platformLower.Equals("mobcrush") && !platformLower.Equals("picarto")
                && !platformLower.Equals("twitch") && !platformLower.Equals("youtube")
                 && !platformLower.Equals("smashcast"))
            {
                await Context.Channel.SendMessageAsync("Invalid platform. Provide one of the following: mixer, mobcrush, picarto, smashcast, twitch, or youtube.");

                return;
            }

            if (!typeLower.Equals("live") && !typeLower.Equals("published") && !typeLower.Equals("ownerlive") && !typeLower.Equals("ownerpublished"))
            {
                await Context.Channel.SendMessageAsync("Invalid type. Provide one of the following: live, published, ownerlive, or ownerpublished.");

                return;
            }

            if (!trueFalse.IsBoolean())
            {
                await Context.Channel.SendMessageAsync("Pass true or false when configuring AllowEveryone. (ie: !cb config AllowEveryone true)");
                return;
            }

            var server = _fileService.GetConfiguredServerById(Context.Guild.Id);

            switch (platformLower)
            {
                case "mixer":
                    if(typeLower.Equals("ownerlive"))
                    {
                        server.AllowMentionOwnerMixerLive = bool.Parse(trueFalse);
                    }
                    else if (typeLower.Equals("live"))
                    {
                        server.AllowMentionMixerLive = bool.Parse(trueFalse);
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("The only valid type for this platform is live or ownerlive. Try again.");
                        return;
                    }
                    break;
                case "mobcrush":
                    if (typeLower.Equals("ownerlive"))
                    {
                        server.AllowMentionOwnerMobcrushLive = bool.Parse(trueFalse);
                    }
                    else if (typeLower.Equals("live"))
                    {
                        server.AllowMentionMobcrushLive = bool.Parse(trueFalse);
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("The only valid type for this platform is live or ownerlive. Try again.");
                        return;
                    }
                    break;
                case "picarto":
                    if (typeLower.Equals("ownerlive"))
                    {
                        server.AllowMentionOwnerPicartoLive = bool.Parse(trueFalse);
                    }
                    else if (typeLower.Equals("live"))
                    {
                        server.AllowMentionPicartoLive = bool.Parse(trueFalse);
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("The only valid type for this platform is live or ownerlive. Try again.");
                        return;
                    }
                    break;
                case "piczel":
                    if (typeLower.Equals("ownerlive"))
                    {
                        server.AllowMentionOwnerPiczelLive = bool.Parse(trueFalse);
                    }
                    else if (typeLower.Equals("live"))
                    {
                        server.AllowMentionPiczelLive = bool.Parse(trueFalse);
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("The only valid type for this platform is live or ownerlive. Try again.");
                        return;
                    }
                    break;
                case "smashcast":
                    if (typeLower.Equals("ownerlive"))
                    {
                        server.AllowMentionOwnerSmashcastLive = bool.Parse(trueFalse);
                    }
                    else if (typeLower.Equals("live"))
                    {
                        server.AllowMentionSmashcastLive = bool.Parse(trueFalse);
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("The only valid type for this platform is live or ownerlive. Try again.");
                        return;
                    }
                    break;
                case "twitch":
                    if (typeLower.Equals("ownerlive"))
                    {
                        server.AllowMentionOwnerTwitchLive = bool.Parse(trueFalse);
                    }
                    else if(typeLower.Equals("live"))
                    {
                        server.AllowMentionTwitchLive = bool.Parse(trueFalse);
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("The only valid type for this platform is live or ownerlive. Try again.");
                        return;
                    }
                    break;
                case "youtube":
                    if (typeLower.Equals("ownerlive"))
                    {
                        server.AllowMentionOwnerYouTubeLive = bool.Parse(trueFalse);
                    }
                    else if (typeLower.Equals("live"))
                    {
                        server.AllowMentionYouTubeLive = bool.Parse(trueFalse);
                    }
                    else if (typeLower.Equals("ownerpublished"))
                    {
                        server.AllowMentionOwnerYouTubePublished = bool.Parse(trueFalse);
                    }
                    else if (typeLower.Equals("published"))
                    {
                        server.AllowMentionYouTubePublished = bool.Parse(trueFalse);
                    }
                    break;
            }

            await _fileService.SaveDiscordServer(server, Context.Guild);
            await Context.Channel.SendMessageAsync("Allow mention on '" + platform + " - " + type + "' has been set to: " + trueFalse);
        }

        [Command("thumbnails"), Summary("Sets use of thumbnails.")]
        public async Task Thumbnails(string trueFalse)
        {
            if (!IsAdmin)
            {
                return;
            }

            if (!trueFalse.IsBoolean())
            {
                await Context.Channel.SendMessageAsync("Pass true or false when configuring AllowThumbnails. (ie: !cb config AllowThumbnails true)");
                return;
            }

            var server = _fileService.GetConfiguredServerById(Context.Guild.Id);

            server.AllowThumbnails = bool.Parse(trueFalse);
            await _fileService.SaveDiscordServer(server, Context.Guild);
            await Context.Channel.SendMessageAsync("Allow thumbnails has been set to: " + trueFalse);
        }

        [Command("live"), Summary("Sets announcing of published content.")]
        public async Task Live(string trueFalse)
        {
            if (!IsAdmin)
            {
                return;
            }

            if (!trueFalse.IsBoolean())
            {
                await Context.Channel.SendMessageAsync("Pass true or false when configuring allow live. (ie: !cb allow live true)");
                return;
            }

            var server = _fileService.GetConfiguredServerById(Context.Guild.Id);

            server.AllowLive = bool.Parse(trueFalse);
            await _fileService.SaveDiscordServer(server, Context.Guild);
            await Context.Channel.SendMessageAsync("Allow live has been set to: " + trueFalse);
        }

        [Command("published"), Summary("Sets announcing of published content.")]
        public async Task Published(string trueFalse)
        {
            if (!IsAdmin)
            {
                return;
            }

            if (!trueFalse.IsBoolean())
            {
                await Context.Channel.SendMessageAsync("Pass true or false when configuring allow published. (ie: !cb allow published true)");
                return;
            }

            var server = _fileService.GetConfiguredServerById(Context.Guild.Id);

            server.AllowPublished = bool.Parse(trueFalse);
            await _fileService.SaveDiscordServer(server, Context.Guild);
            await Context.Channel.SendMessageAsync("Allow published has been set to: " + trueFalse);
        }

        [Command("vodcast"), Alias("vodcasts")]
        public async Task Vodcast(string trueFalse)
        {
            if (!IsAdmin)
            {
                return;
            }

            if (!trueFalse.IsBoolean())
            {
                await Context.Channel.SendMessageAsync("Pass true or false when configuring allow live. (ie: !cb allow vodcast true)");
                return;
            }

            var server = _fileService.GetConfiguredServerById(Context.Guild.Id);

            server.AllowVodcasts = bool.Parse(trueFalse);
            await _fileService.SaveDiscordServer(server, Context.Guild);
            await Context.Channel.SendMessageAsync("Allow vodcast has been set to: " + trueFalse);
        }

        [Command("all")]
        public async Task All(string trueFalse)
        {
            if (!IsAdmin)
            {
                return;
            }

            if (!trueFalse.IsBoolean())
            {
                await Context.Channel.SendMessageAsync("Pass true or false when configuring allow all. (ie: !cb allow all true)");
                return;
            }

            var server = _fileService.GetConfiguredServerById(Context.Guild.Id);

            server.AllowLive = bool.Parse(trueFalse);
            server.AllowPublished = bool.Parse(trueFalse);

            await _fileService.SaveDiscordServer(server, Context.Guild);
            await Context.Channel.SendMessageAsync("Allow all (Live and Published) has been set to: " + trueFalse);
        }

        [Command("streamstats"), Summary("Allows or disallows stream stats during stream announcements.")]
        public async Task StreamStats(string trueFalse)
        {
            if (!IsAdmin)
            {
                return;
            }

            if (!trueFalse.IsBoolean())
            {
                await Context.Channel.SendMessageAsync("Pass true or false when configuring StreamStats. (ie: !cb allow streamstats true)");
                return;
            }

            var server = _fileService.GetConfiguredServerById(Context.Guild.Id);

            server.DisplayStreamStatistics = bool.Parse(trueFalse);
            await _fileService.SaveDiscordServer(server, Context.Guild);
            await Context.Channel.SendMessageAsync("Allow StreamStats has been set to: " + trueFalse);
        }

        [Command("mature")]
        public async Task Mature(string trueFalse)
        {
            if (!IsAdmin)
            {
                return;
            }

            if (!trueFalse.IsBoolean())
            {
                await Context.Channel.SendMessageAsync("Pass true or false when configuring Mature. (ie: !cb allow mature true)");
                return;
            }

            var server = _fileService.GetConfiguredServerById(Context.Guild.Id);

            server.AllowMature = bool.Parse(trueFalse);
            await _fileService.SaveDiscordServer(server, Context.Guild);
            await Context.Channel.SendMessageAsync("Allow Mature has been set to: " + trueFalse);
        }
    }
}
