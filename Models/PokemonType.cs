namespace PokemonEH.Models
{
    public class PokemonType
    {
        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }

        public int TypeId { get; set; }
        public PokemonElementType PokemonElementType { get; set; }
    }

}
