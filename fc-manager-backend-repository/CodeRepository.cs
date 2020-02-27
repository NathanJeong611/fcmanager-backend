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
    public class CodeRepository : ICodeRepository
    {
        private FCMContext _context;
        public CodeRepository(FCMContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Code>> GetCodes()
        {
            return await _context.Codes
                .ToListAsync();
        }

        public async Task<IEnumerable<Code>> GetCodes(int parentId)
        {
            return await _context.Codes
                                .Where(c => c.DeletedAt == null && c.ParentCodeId == parentId)
                                .Include(c => c.ParentCode)
                                .ToListAsync();
        }
    }
}
