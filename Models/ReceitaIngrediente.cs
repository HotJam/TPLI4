using System;
using System.Collections.Generic;

namespace Assistente.Models
{
    public partial class ReceitaIngrediente
    {
        public int ReceitaIngredienteId { get; set; }
        public int ReceitaId { get; set; }
        public int IngredienteId { get; set; }

        public Ingrediente Ingrediente { get; set; }
        public Receita Receita { get; set; }
    }
}
