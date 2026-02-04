namespace APICatalogo.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; } //Entity Framework entende que Id= chave primaria, e nome da classe+id tambem (Categoria+Id)
        public string? Nome { get; set; }
        public string? ImagemUrl { get; set; }

        public ICollection<Produto>? Produtos { get; set; } //propriedade de navegação para representar o relacionamento entre Categoria e Produto
    }
}
