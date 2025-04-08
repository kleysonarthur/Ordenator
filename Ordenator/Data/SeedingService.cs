using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ordenator.Models;
using Ordenator.Models.Enums;

namespace Ordenator.Data {
    public class SeedingService {
        private OrdenatorContext _context;
        public SeedingService(OrdenatorContext context) {
            _context = context;
        }
        public void Seed() {
            if(_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any()) {
                return; //DB já populado
            }
            Department d1 = new Department(1, "Administration"); ;

            Profile p1 = new Profile(1, "Administrator");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1, p1);

            _context.Department.AddRange(d1);
            _context.Seller.AddRange(s1);
            _context.Profile.AddRange(p1);

            _context.SaveChanges();
        }
    }
}
