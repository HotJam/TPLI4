using System;
using System.Collections.Generic;

namespace Assistente.Models
{
    public partial class FavoritoReceita
    {
        public int FavoritoReceitaId { get; set; }
        public int FavoritosId { get; set; }
        public int ReceitaId { get; set; }

        public Utilizador Favoritos { get; set; }
        public Receita Receita { get; set; }
    }
}
