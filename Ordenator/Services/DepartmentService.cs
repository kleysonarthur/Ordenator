using Ordenator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ordenator.Services {
    public class DepartmentService {
        private readonly OrdenatorContext _context;

        public DepartmentService(OrdenatorContext context) {
            _context = context;
        }
        public async Task<List<Department>> FindAllAsync() {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
