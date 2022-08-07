using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWebMvc.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Vendedor> Vendedor { get; set; } = new List<Vendedor>();

        public Departamento()
        {
        }

        public Departamento(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AddVendedor(Vendedor vendedor)
        {
            Vendedor.Add(vendedor);
        }

        public double TotalVendas(DateTime inicial, DateTime final)
        {
            return Vendedor.Sum(vr => vr.TotalVendas(inicial, final));
        }
    }
}
