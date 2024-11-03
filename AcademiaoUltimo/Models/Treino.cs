using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademiaoUltimo.Models
{
    public class Treino
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataTreino { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public List<Aula> Aulas { get; set; } = new List<Aula>();
    }
}