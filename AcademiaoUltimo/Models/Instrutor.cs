using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademiaoUltimo.Models
{
    public class Instrutor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }

        public List<Aula> Aulas { get; set; } = new List<Aula>();
    }
}