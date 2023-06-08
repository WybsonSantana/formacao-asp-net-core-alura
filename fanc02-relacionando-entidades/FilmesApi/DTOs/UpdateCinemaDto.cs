using System.ComponentModel.DataAnnotations;

namespace FilmesApi.DTOs;

public class UpdateCinemaDto
{
    [Required(ErrorMessage = "O campo de nome é obrigatório")]
    public string Nome { get; set; }
}
