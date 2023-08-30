namespace PokemonEH.Models
{
    public class PokemonElementType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PokemonType> PokemonTypes { get; set; } = new List<PokemonType>();
    }
}