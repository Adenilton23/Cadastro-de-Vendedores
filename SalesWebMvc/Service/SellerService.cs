using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Service.Exceptions;

namespace SalesWebMvc.Service
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        // Construtor injecao de dependencia
        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }
        // Retorna lista todos vendedores
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
        // Inserir Vendedor no banco
        public void Insert(Seller obj)
        {            
            _context.Add(obj);
            // Confirmar a insercao
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Departament).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int Id)
        {
            var obj = _context.Seller.Find(Id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {   // Existe algum registro no banco (condicao)
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);               
            }
        } 

    }
}
