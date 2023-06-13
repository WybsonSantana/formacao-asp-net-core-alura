using Microsoft.AspNetCore.Mvc;
using UsuariosApi.Data.DTOs;

namespace UsuariosApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{

    [HttpPost]
    public IActionResult CadastraUsuario(CreateUsuarioDto createUsuarioDto)
    {
        throw new NotImplementedException();
    }
}
