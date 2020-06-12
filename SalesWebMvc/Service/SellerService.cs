using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Service.Exceptions;
using System.Runtime.CompilerServices;

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
        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }
        // Inserir Vendedor no banco
        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            // Confirmar a insercao
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Departament).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int Id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(Id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException("Can't delete seller because he/she has sales");
            }          
        }

        public async Task UpdateAsync(Seller obj)
        {   // Tem algum registro no banco (condicao)
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
               await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }
}
