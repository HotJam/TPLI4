using System;
using System.Collections.Generic;

namespace Assistente.Models
{
    public partial class Ingrediente
    {
        public Ingrediente()
        {
            InventarioIngrediente = new HashSet<InventarioIngrediente>();
            ReceitaIngrediente = new HashSet<ReceitaIngrediente>();
        }

        public int IngredienteId { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public int Quantidade { get; set; }

        public ICollection<InventarioIngrediente> InventarioIngrediente { get; set; }
        public ICollection<ReceitaIngrediente> ReceitaIngrediente { get; set; }
    }
}
