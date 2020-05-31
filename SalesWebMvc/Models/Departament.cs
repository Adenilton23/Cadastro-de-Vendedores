using System;
using System.Collections.Generic;
using System.Linq;
namespace SalesWebMvc.Models

{
    public class Departament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Departament()
        {

        }

        public Departament(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // Adiciona Funcionario Tabela Departamento
        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            // Somar total de vendas na Tabela de vendedores por periodo
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
