using System.Text.Json.Serialization;

namespace MinimalApiCatalogo.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }

        [JsonIgnore]
        public ICollection<Ingresso>? Ingressos {  get; set; }
        //ICollection pode ter mais de um produto !
    }
}
