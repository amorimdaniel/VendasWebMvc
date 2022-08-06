using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMvc.Models;

namespace VendasWebMvc.Controllers
{
    public class DepartamentoController : Controller
    {
        public IActionResult Index()
        {
            List<Departamento> List = new List<Departamento>();
            List.Add(new Departamento { Id = 1, Nome = "Eletrônico" });
            List.Add(new Departamento { Id = 2, Nome = "Festa" });

            return View(List);
        }
    }
}