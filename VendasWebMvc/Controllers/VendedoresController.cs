using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMvc.Services;
using VendasWebMvc.Models;
using VendasWebMvc.Models.ViewModels;
namespace VendasWebMvc.Controllers

{
    public class VendedoresController : Controller
    {
        private readonly VendedorServico _vendedorServico;
        private readonly DepartamentoServico _departamentoServico;

        public VendedoresController(VendedorServico vendedorServico, DepartamentoServico departamentoServico)
        {
            _vendedorServico = vendedorServico;
            _departamentoServico = departamentoServico;
        }

        public IActionResult Index()
        {
            var list = _vendedorServico.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departamentos = _departamentoServico.FindAll();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _vendedorServico.Inserir(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id )
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _vendedorServico.FindById(id.Value);
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
            _vendedorServico.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _vendedorServico.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}