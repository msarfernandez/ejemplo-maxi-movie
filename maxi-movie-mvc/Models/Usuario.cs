using Microsoft.AspNetCore.Identity;

namespace maxi_movie_mvc.Models
{
    public class Usuario : IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string ImagenUrlPerfil { get; set; }

        public List<Favorito>? PeliculasFavoritas { get; set; }
        public List<Review>? ReviewsUsuario { get; set; }

    }
}
