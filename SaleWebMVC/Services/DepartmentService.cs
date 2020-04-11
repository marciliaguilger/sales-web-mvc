using SaleWebMVC.Data;
using SaleWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebMVC.Services
{
    public class DepartmentService
    {
        private readonly SaleWebMVCContext _context; //injeção de dependencia

        public DepartmentService(SaleWebMVCContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
