namespace EspacioUsuarioController;
using Microsoft.AspNetCore.Mvc;

using EspacioUsuario;
using EspacioRepository;
using Microsoft.AspNetCore.DataProtection.Repositories;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly ILogger<UsuarioController> _logger;
    Usuario usuario;

    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        //Usuario usuario = new Usuario();
    }

    [HttpGet(Name = "Nombre Usuario")]
    public ActionResult<string> GetNombreUsuario(){
        if (usuario!=null)
      {
        return Ok(usuario.Nombre);
      }else
      {
        return NotFound("No existe un usuario");
      }
    }

    [HttpGet]
    [Route("ListarUsuarios")]
    public ActionResult<List<Usuario>> GetUsuarios(){
        UsuariosRepository repo = new UsuariosRepository();
        return Ok(repo.GetAll());
    }

    [HttpPut]
    [Route("AgregarUsuario")]
    public ActionResult<List<Usuario>> AddUsuario(Usuario newUsuario){
        //Usuario newUsuario = new Usuario(id,nombre);
        UsuariosRepository repo = new UsuariosRepository();
        repo.Create(newUsuario);
        return Ok(repo.GetAll());
    }
}