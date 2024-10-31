using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademiaoUltimo.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Idade { get; set; }

        // Relacionamento com Plano
        public List<Plano> Planos { get; set; } = new List<Plano>();

        // Relacionamento com Pagamento
        public List<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
    }
}