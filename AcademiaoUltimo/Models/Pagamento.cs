using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademiaoUltimo.Models
{
    public class Pagamento
    {
        public int Id { get; set; }

        // Relacionamento com Usuario
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        // Relacionamento com Plano
        public int PlanoId { get; set; }
        public Plano Plano { get; set; }

        public DateTime DataPagamento { get; set; } = DateTime.Now;
    }
}