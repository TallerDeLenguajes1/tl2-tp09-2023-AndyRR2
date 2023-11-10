namespace EspacioUsuarioController;
using Microsoft.AspNetCore.Mvc;

using EspacioUsuario;
using EspacioUsuarioRepository;
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

    [HttpGet("api/usuario")]
    public ActionResult<List<Usuario>> GetUsuarios(){
        UsuariosRepository repo = new UsuariosRepository();
        return Ok(repo.GetAll());
    }

    [HttpGet("api/usuario/{Id}")]
    public ActionResult<Usuario> GetUsuarioID(int Id){
        UsuariosRepository repo = new UsuariosRepository();
        return Ok(repo.GetById(Id));
    }

    [HttpPost("api/usuario")]
    public ActionResult<List<Usuario>> AddUsuario(Usuario newUsuario){
        //Usuario newUsuario = new Usuario(id,nombre);
        UsuariosRepository repo = new UsuariosRepository();
        repo.Create(newUsuario);
        return Ok(repo.GetAll());
    }
    
    [HttpDelete("api/usuario/{Id}")]
    public ActionResult<List<Usuario>> DeleteUsuarioID(int Id){
        UsuariosRepository repo = new UsuariosRepository();
        repo.Remove(Id);
        return Ok(repo.GetAll());
    }
    
    [HttpPut("api/usuario/{Id}/nombre")]
    public ActionResult<List<Usuario>> UpdateUsuario(Usuario usuario){
        UsuariosRepository repo = new UsuariosRepository();
        repo.Update(usuario);
        return Ok(repo.GetAll());
    }

}