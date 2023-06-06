using System.ComponentModel.DataAnnotations;

namespace FilmesApi.DTOs
{
    public class CreateCinemaDto
    {
        [Required]
        public string Nome { get; set; }
    }
}
