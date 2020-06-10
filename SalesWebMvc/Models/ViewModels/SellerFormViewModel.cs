using System;
using System.Collections.Generic;


namespace SalesWebMvc.Models.ViewModels
{
    // Tela cadastro de Vendedores
    public class SellerFormViewModel
    {       
        public Seller Seller{ get; set; }
        // Lista de Departamentos
        public ICollection<Departament> Departaments { get; set; }
    }
}
