using SaleWebMVC.Data;
using SaleWebMVC.Models;
using System.Collections.Generic;
using System.Linq;


namespace SaleWebMVC.Services
{
    public class SellerService
    {
        private readonly SaleWebMVCContext _context; //injeção de dependencia

        public SellerService(SaleWebMVCContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            obj.Department = _context.Department.First(); // provisório
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
