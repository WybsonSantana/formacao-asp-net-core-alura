using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.DTOs;
using UsuariosApi.Models;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    private IMapper _mapper;
    private UserManager<Usuario> _userManager;

    public UsuarioController(IMapper mapper, UserManager<Usuario> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto createUsuarioDto)
    {
        Usuario usuario = _mapper.Map<Usuario>(createUsuarioDto);
        IdentityResult resultado = await
        _userManager.CreateAsync(usuario, createUsuarioDto.Password);

        if (resultado.Succeeded)
        {
            return Ok("Usuário cadastrado!");
        }

        throw new ApplicationException("Falha ao cadastrar usuário!");
    }
}
