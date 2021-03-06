﻿using MTD.CouchBot.Dals;
using MTD.CouchBot.Domain.Models.Twitch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTD.CouchBot.Managers.Implementations
{
    public class TwitchManager : ITwitchManager
    {
        private readonly ITwitchDal _twitchDal;

        public TwitchManager(ITwitchDal twitchDal)
        {
            _twitchDal = twitchDal;
        }

        public async Task<TwitchStreamV5> GetStreamById(string twitchId)
        {
            return await _twitchDal.GetStreamById(twitchId);
        }

        public async Task<TwitchFollowers> GetFollowersByName(string name)
        {
            return await _twitchDal.GetFollowersByName(name);
        }

        public async Task<string> GetTwitchIdByLogin(string name)
        {
            return await _twitchDal.GetTwitchIdByLogin(name);
        }

        public async Task<TwitchStreamsV5> GetStreamsByIdList(List<string> twitchIdList)
        {
            var list = "";
            foreach (var id in twitchIdList)
            {
                list += id + ",";
            }

            list = list.TrimEnd(',');

            return await _twitchDal.GetStreamsByIdList(list);
        }

        public async Task<TwitchStreamsV5> GetStreamsByIdList(string twitchIdList)
        {
            return await _twitchDal.GetStreamsByIdList(twitchIdList);
        }
        
        public async Task<TwitchTeam> GetTwitchTeamByName(string name)
        {
            return await _twitchDal.GetTwitchTeamByName(name);
        }

        public async Task<List<string>> GetDelimitedListOfTwitchMemberIds(string teamToken)
        {
            return await _twitchDal.GetDelimitedListOfTwitchMemberIds(teamToken);
        }

        public async Task<List<TwitchStreamsV5.Stream>> GetStreamsByGameName(string gameName)
        {
            return await _twitchDal.GetStreamsByGameName(gameName);
        }

        public async Task<TwitchGameSearchResponse> SearchForGameByName(string gameName)
        {
            return await _twitchDal.SearchForGameByName(gameName);
        }

        public async Task<TwitchChannelResponse> GetTwitchChannelById(string twitchId)
        {
            return await _twitchDal.GetTwitchChannelById(twitchId);
        }

        public async Task<List<string>> GetTwitchIdsByLoginList(string twitchNameList)
        {
            return await _twitchDal.GetTwitchIdsByLoginList(twitchNameList);
        }

        public async Task<List<TwitchUser.User>> GetTwitchUsersByLoginList(string twitchNameList)
        {
            return await _twitchDal.GetTwitchUsersByLoginList(twitchNameList);
        }
    }
}
