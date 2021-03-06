﻿using MTD.CouchBot.Domain.Models.Twitch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTD.CouchBot.Managers
{
    public interface ITwitchManager
    {
        Task<TwitchStreamV5> GetStreamById(string twitchId);
        Task<TwitchFollowers> GetFollowersByName(string name);
        Task<string> GetTwitchIdByLogin(string name);
        Task<List<string>> GetTwitchIdsByLoginList(string twitchNameList);
        Task<TwitchStreamsV5> GetStreamsByIdList(List<string> twitchIdList);
        Task<TwitchStreamsV5> GetStreamsByIdList(string twitchIdList);
        Task<TwitchTeam> GetTwitchTeamByName(string name);
        Task<List<string>> GetDelimitedListOfTwitchMemberIds(string teamToken);
        Task<List<TwitchStreamsV5.Stream>> GetStreamsByGameName(string gameName);
        Task<TwitchGameSearchResponse> SearchForGameByName(string gameName);
        Task<TwitchChannelResponse> GetTwitchChannelById(string twitchId);
        Task<List<TwitchUser.User>> GetTwitchUsersByLoginList(string twitchNameList);
    }
}
