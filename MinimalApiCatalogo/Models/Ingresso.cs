﻿using System.Text.Json.Serialization;

namespace MinimalApiCatalogo.Models
{
    public class Ingresso
    {
        public int IngressoId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public string? Imagem { get; set; }
        public DateTime DataCompra { get; set; }
        public int Estoque { get; set; }

        public int CategoriaId {  get; set; }
        [JsonIgnore]
        public Categoria? Categoria {  get; set; }
    }
}
