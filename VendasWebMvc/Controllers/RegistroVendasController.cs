using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasWebMvc.Services;

namespace VendasWebMvc.Controllers
{
    public class RegistroVendasController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public RegistroVendasController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minData, DateTime? maxData)
        {  
            var result = await _salesRecordService.FindByDateAsync(minData, maxData);
            return View(result);
        }

        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}