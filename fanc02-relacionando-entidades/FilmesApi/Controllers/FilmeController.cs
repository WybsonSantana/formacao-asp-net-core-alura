using AutoMapper;
using FilmesApi.Data;
using FilmesApi.DTOs;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Lista todos os filmes do banco de dados
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a consulta seja feita com sucesso</response>
    [HttpGet]
    public IEnumerable<ReadFilmeDto> listaFilmes(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult ListaFilmePorId(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

        if (filme == null) return NotFound();

        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);

        return Ok(filmeDto);
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult AdcionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        var filme = _mapper.Map<Filme>(filmeDto);

        _context.Filmes.Add(filme);
        _context.SaveChanges();

        return CreatedAtAction(
            nameof(ListaFilmePorId),
            new { id = filme.Id },
            value: filme
            );
    }

    [HttpPut("{id}")]
    public IActionResult atualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

        if (filme == null) return NotFound();

        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult atualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto> filmePatch)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

        if (filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

        filmePatch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult deletaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

        if (filme == null) return NotFound();

        _context.Remove(filme);
        _context.SaveChanges();

        return NoContent();
    }
}
