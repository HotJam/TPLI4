using System;
using System.Collections.Generic;

namespace Assistente.Models
{
    public partial class InventarioIngrediente
    {
        public string InventarioIngredienteId { get; set; }
        public int InventarioId { get; set; }
        public int IngredienteId { get; set; }

        public Ingrediente Ingrediente { get; set; }
        public Utilizador Inventario { get; set; }
    }
}
