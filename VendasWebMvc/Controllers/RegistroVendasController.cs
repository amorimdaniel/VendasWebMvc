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
            if (!minData.HasValue)
            {
                minData = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxData.HasValue)
            {
                maxData = DateTime.Now;
            }
            ViewData["minData"] = minData.Value.ToString("yyyy-MM-dd");
            ViewData["maxData"] = maxData.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordService.FindByDateAsync(minData, maxData);
            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minData, DateTime? maxData)
        {
            
            return View();
        }

        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}