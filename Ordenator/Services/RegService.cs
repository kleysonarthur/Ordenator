using Microsoft.EntityFrameworkCore;
using Ordenator.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordenator.Services
{
    public class RegService
    {
        private readonly OrdenatorContext _context;

        public RegService(OrdenatorContext context)
        {
            _context = context;
        }
        public async Task<List<Profile>> FindAllAsync()
        {
            return await _context.Profile.OrderBy(x => x.Name).ToListAsync();
        }
    }
}

