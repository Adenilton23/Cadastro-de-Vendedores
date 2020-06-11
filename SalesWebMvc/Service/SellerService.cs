using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}
