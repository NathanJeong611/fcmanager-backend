using System.Collections;
using System;
using System.Collections.Generic;

namespace fc_manager_backend_abstraction
{
    public interface IMember
    {
        IEnumerable<MemberInfo> GetClubMembers(int clubId);
        IEnumerable<MemberInfo> GetTeamMembers(int teamId);
        IEnumerable<MemberInfo> GetLeagueMembers(int leagueId);
    }

    public class MemberInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime StartedOn { get; set; }
        public string Role { get; set; }

        public DateTime? DOB { get; set; }
        public string Position { get; set; }
        public int TeamId { get; set; }
        public string Team { get; set; }
    }
}
