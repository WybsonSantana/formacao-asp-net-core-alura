using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Data.DTOs;
using UsuariosApi.Models;

namespace UsuariosApi.Services;

public class UsuarioService
{
    private IMapper _mapper;
    private UserManager<Usuario> _userManager;
    private SignInManager<Usuario> _signInManager;
    private TokenService _tokenService;

    public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, TokenService tokenService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task CadastraUsuario(CreateUsuarioDto createUsuarioDto)
    {
        Usuario usuario = _mapper.Map<Usuario>(createUsuarioDto);

        IdentityResult resultado = await
        _userManager.CreateAsync(usuario, createUsuarioDto.Password);

        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Falha ao cadastrar usuário!");
        }
    }

    public async Task<string> Login(LoginUsuarioDto loginUsuarioDto)
    {
        var resultado = await _signInManager.PasswordSignInAsync(loginUsuarioDto.Username, loginUsuarioDto.Password, false, false);

        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Usuário não autenticado!");
        }

        var usuario = _signInManager
            .UserManager
            .Users
            .FirstOrDefault(user => user.NormalizedUserName == loginUsuarioDto.Username.ToUpper());

        var token = _tokenService.GenerateToken(usuario);

        return token;
    }
}
