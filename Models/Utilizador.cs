using System;
using System.Collections.Generic;

namespace Assistente.Models
{
    public partial class Utilizador
    {
        public Utilizador()
        {
            FavoritoReceita = new HashSet<FavoritoReceita>();
            InventarioIngrediente = new HashSet<InventarioIngrediente>();
        }

        public int UtilizadorId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int InventarioId { get; set; }
        public int ListaComprasId { get; set; }
        public bool Admin { get; set; }
        public int FavoritosId { get; set; }

        public ICollection<FavoritoReceita> FavoritoReceita { get; set; }
        public ICollection<InventarioIngrediente> InventarioIngrediente { get; set; }
    }
}
