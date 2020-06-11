using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Service;
using SalesWebMvc.Models.ViewModels;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        // Declaração de dependencia
        private readonly SellerService _sellerService;
        private readonly DepartamentService _departamentService;

        // Construtor de injeção de dependencia
        public SellersController(SellerService sellerService, DepartamentService departamentService)
        {
            _sellerService = sellerService;
            _departamentService = departamentService;
        }
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();

            return View(list);
        }
        public IActionResult Create()
        {
            var  departaments = _departamentService.FindAll();
            var viewModel = new SellerFormViewModel { Departaments = departaments };
            return View(viewModel);
        }

        // Indicação de post
        [HttpPost]

        // indicação anti  ataque csrf
        [ValidateAntiForgeryToken]

        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
        // tela de Confirmação de delete
        public IActionResult Delete(int? id)
        {
           // Verificar id nulo
            if (id == null)
            {
                return NotFound();
            }
            // Pegar obj no banco
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            // Verificar id nulo
            if (id == null)
            {
                return NotFound();
            }
            // Pegar obj no banco
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

    }
}