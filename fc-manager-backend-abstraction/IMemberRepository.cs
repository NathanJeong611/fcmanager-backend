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
}
