using System;
using System.Collections.Generic;

namespace ProjetoMySQL.Models
{
    public partial class Eleitor
    {
        public int Id { get; set; }
        public string Cpf { get; set; } = null!;
        public string Nome { get; set; } = null!;
    }
}
