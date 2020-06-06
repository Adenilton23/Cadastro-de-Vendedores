using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Service;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        // Declaração de dependencia
        private readonly SellerService _sellerService;

        // Construtor de injeção de dependencia
        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();

            return View(list);
        }
        public IActionResult Create()
        {
            return View();
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




    }
}