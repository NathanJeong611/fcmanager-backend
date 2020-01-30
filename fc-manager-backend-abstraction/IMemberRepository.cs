using System.Collections;
using System;
using System.Collections.Generic;
using fc_manager_backend_da.Models;
using System.Threading.Tasks;

namespace fc_manager_backend_abstraction
{
    public interface IMemberRepository
    {
        Task<Member> GetMember(int id);
        Task<IEnumerable<Member>> GetMembers();
        void Add(Member member);
        void Remove(Member member);
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
