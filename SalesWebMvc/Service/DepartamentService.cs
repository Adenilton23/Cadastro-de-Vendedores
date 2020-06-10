using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using SalesWebMvc.Models;

namespace SalesWebMvc.Service
{
    public class DepartamentService
    {
        private readonly SalesWebMvcContext _context;

        // Construtor injecao de dependencia
        public DepartamentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        // Metodo retorna lista Departamentos
        public List<Departament> FindAll()
        {
            return _context.Departament.OrderBy(x => x.Name).ToList();
        }
    }
}
