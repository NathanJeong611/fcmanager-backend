using System.Collections;
using System.Security.Cryptography.X509Certificates;
using fc_manager_backend_da.Models;
using fc_manager_backend_abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace fc_manager_backend_repository
{
    public class MemberRepository : IMemberRepository
    {
        private FCMContext _context;
        public MemberRepository(FCMContext context)
        {
            _context = context;
        }

        public  IEnumerable<MemberInfo> GetClubMembers(int clubId)
        {
            return _context.Members.Where(m=>m.ClubId == clubId && m.DeletedAt == null)
            .Select(m=> new MemberInfo{ Id = m.Id,   }).ToList();
        }

        public IEnumerable<MemberInfo> GetLeagueMembers(int leagueId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MemberInfo> GetTeamMembers(int teamId)
        {
            throw new NotImplementedException();
        }

        public void Add(Member member)
        {
            _context.Members.Add(member);
        }

        public void Remove(Member member)
        {
            _context.Members.Remove(member);
        }

        public async Task<Member> GetMember(int id)
        {
            return await _context.Members.FindAsync(id);
        }

        public async Task<IEnumerable<Member>> GetMembers()
        {
            var result = await _context.Members
                .Include(m => m.Club)
                .Include(m => m.Role)
                .Include(m => m.TeamMembers)
                    .ThenInclude(x => x.Team)
                .ToListAsync();
            return result;
        }
    }
}
