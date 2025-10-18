namespace maxi_movie_mvc.Models
{
    public class Favorito
    {
        public int Id { get; set; }
        public string UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public int PeliculaId { get; set; }
        public Pelicula? Pelicula { get; set; }
        public DateTime Fecha { get; set; }
    }
}
