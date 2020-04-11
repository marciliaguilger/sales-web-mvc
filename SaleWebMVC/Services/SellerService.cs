using SaleWebMVC.Data;
using SaleWebMVC.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SaleWebMVC.Services.Exceptions;

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
        
        public Seller FindById(int id)
        {
           //Eager loading com Include (adicionar objetos associados)
            return _context.Seller.Include(obj => obj.Department).
                FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj); //removido do dbset
            _context.SaveChanges();  //salvando as alterações no banco de dados
        }

        public void Insert(Seller obj)
        {

            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if(!_context.Seller.Any(x =>  x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                //relançando uma exceção do nivel de acesso a dados para a camada de serviço
                //segregação de camadas
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
