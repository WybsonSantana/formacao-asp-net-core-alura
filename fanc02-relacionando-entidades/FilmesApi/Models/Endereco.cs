using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo logradouro é obrigatório")]
    public string Logradouro { get; set; }

    [Required(ErrorMessage = "O campo número é obrigatório")]
    public int Numero { get; set; }

    public virtual Cinema Cinema { get; set; }
}