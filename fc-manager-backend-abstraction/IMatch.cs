using System;
using System.Collections.Generic;

namespace fc_manager_backend_abstraction
{
    public interface IMatchRepository
    {
        List<ScheduleInfo> GetMatches(int clubId, DateTime? BeginingAt);
    }

    public class ScheduleInfo
    {
        public DateTime ScheduledOn { get; set; }
        public List<MatchInfo> matches { get; set; }
    }
    public class MatchInfo
    {
        public int Id { get; set; }
        public string HomeTeamName { get; set; }
        public string HomeTeamLogoUrl { get; set; }
        public string AwayTeamName { get; set; }
        public string AwayTeamLogoUrl { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public string Location { get; set; }
        public DateTime ScheduledAt { get; set; }

    }
}
