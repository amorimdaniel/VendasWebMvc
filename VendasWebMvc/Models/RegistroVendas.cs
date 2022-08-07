using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWebMvc.Models.Enums;

namespace VendasWebMvc.Models
{
    public class RegistroVendas
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Quantia { get; set; }
        public VendasStatus Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public RegistroVendas()
        {
        }

        public RegistroVendas(int id, DateTime data, double quantia, VendasStatus status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Quantia = quantia;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
