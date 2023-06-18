using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.DTOs;
using UsuariosApi.Models;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    private UsuarioService _usuarioService;

    public UsuarioController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUsuarioDto loginUsuarioDto)
    {
        await _usuarioService.Login(loginUsuarioDto);

        return Ok("Usuário autenticado!");
    }

    [HttpPost]
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto createUsuarioDto)
    {
        await _usuarioService.CadastraUsuario(createUsuarioDto);
        return Ok("Usuário cadastrado!");
    }
}
