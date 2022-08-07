using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWebMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public double BaseSalario { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public ICollection<RegistroVendas> Vendas { get; set; } = new List<RegistroVendas>();

        public Vendedor()
        {
        }

        public Vendedor(int id, string nome, string email, DateTime dataNascimento, double baseSalario, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            BaseSalario = baseSalario;
            Departamento = departamento;
        }

        public void AddVenda(RegistroVendas sr )
        {
            Vendas.Add(sr);
        }

        public void RemoverVenda(RegistroVendas sr)
        {
            Vendas.Remove(sr);
        }

        public double TotalVendas(DateTime inicial, DateTime final)
        {
            return Vendas.Where(sr => sr.Data >= inicial && sr.Data <= final).Sum(sr => sr.Quantia);        
        }
    }
}
