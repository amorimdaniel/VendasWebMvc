using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace VendasWebMvc.Services
{
    public class SalesRecordService
    {
        private readonly VendasWebMvcContext _context;

        public SalesRecordService(VendasWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroVendas>> FindByDateAsync(DateTime? minData, DateTime? maxData)
        {
            var result = from obj in _context.RegistroVendas select obj;
            if (minData.HasValue)
            {
                result = result.Where(x => x.Data >= minData.Value);
            }
            if (maxData.HasValue)
            {
                result = result.Where(x => x.Data <= maxData.Value);
            }
            return await result
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Departamento, RegistroVendas>>> FindByDateGroupingAsync(DateTime? minData, DateTime? maxData)
        {
            var result = from obj in _context.RegistroVendas select obj;
            if (minData.HasValue)
            {
                result = result.Where(x => x.Data >= minData.Value);
            }
            if (maxData.HasValue)
            {
                result = result.Where(x => x.Data <= maxData.Value);
            }
            return await result
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .GroupBy(x => x.Vendedor.Departamento)
                .ToListAsync();
        }
    }
}
