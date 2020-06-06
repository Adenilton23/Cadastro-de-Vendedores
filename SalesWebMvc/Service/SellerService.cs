using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;

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
            obj.Departament = _context.Departament.First();
            _context.Add(obj);
            // Confirmar a insercao
            _context.SaveChanges();
        }



    }
}
