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
            var result = await _context.Codes
                .ToListAsync();
            return result;
        }
    }
}
