using Microsoft.AspNetCore.Identity;

namespace PokemonEH.Models
{
    public class UserFavorite
    {
        public int Id { get; set; }  

        public string UserId { get; set; } 
        public virtual IdentityUser User { get; set; } 

        public int PokemonId { get; set; }
        public virtual Pokemon Pokemon { get; set; }
    }
}
