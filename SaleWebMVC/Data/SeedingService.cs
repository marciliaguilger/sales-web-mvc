using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaleWebMVC.Models;
using SaleWebMVC.Models.Enums;

namespace SaleWebMVC.Data
{
    public class SeedingService
    {
        private SaleWebMVCContext _context;
        public SeedingService(SaleWebMVCContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || 
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return; // banco de dados já foi populado
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Bob", "bob@bob.com", new DateTime(1994, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Maria", "Maria@bob.com", new DateTime(1994, 4, 21), 1000.0, d1);
            Seller s3 = new Seller(3, "Antonio", "Antonio@bob.com", new DateTime(1994, 4, 21), 1000.0, d1);
            Seller s4 = new Seller(4, "José", "jose@bob.com", new DateTime(1994, 4, 21), 1000.0, d1);
            Seller s5 = new Seller(5, "Bob", "bob@bob.com", new DateTime(1994, 4, 21), 1000.0, d1);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2020, 03, 30), 11000.0, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2020, 03, 30), 11000.0, SaleStatus.Billed, s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2020, 03, 30), 11000.0, SaleStatus.Billed, s3);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2020, 03, 30), 11000.0, SaleStatus.Billed, s4);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5);
            _context.SalesRecord.AddRange(r1, r2, r3, r4);

            _context.SaveChanges();



        }

    }
}
