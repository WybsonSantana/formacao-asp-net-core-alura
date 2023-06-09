using System.ComponentModel.DataAnnotations;

namespace FilmesApi.DTOs;

public class ReadFilmeDto
{
    public string Titulo { get; set; }

    public string Genero { get; set; }

    public int duracao { get; set; }

    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;

    public ICollection<ReadSessaoDto> Sessoes { get; set; }
}
