using System;
using System.Collections.Generic;

namespace Assistente.Models
{
    public partial class Receita
    {
        public Receita()
        {
            FavoritoReceita = new HashSet<FavoritoReceita>();
            ReceitaIngrediente = new HashSet<ReceitaIngrediente>();
        }

        public int ReceitaId { get; set; }
        public string Prodecimento { get; set; }
        public string Descricao { get; set; }
        public double Avaliacao { get; set; }
        public double TempoPreparacao { get; set; }
        public string Nutricao { get; set; }

        public ICollection<FavoritoReceita> FavoritoReceita { get; set; }
        public ICollection<ReceitaIngrediente> ReceitaIngrediente { get; set; }
    }
}
