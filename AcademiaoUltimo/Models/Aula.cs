using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademiaoUltimo.Models
{
    public class Aula
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public string Local { get; set; }

        // Relacionamento com Instrutor
        public int InstrutorId { get; set; }
        public Instrutor Instrutor { get; set; }

        // Relacionamento com Treinos
        public List<Treino> Treinos { get; set; } = new List<Treino>();
    }
}