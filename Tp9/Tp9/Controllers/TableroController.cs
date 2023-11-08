namespace EspacioUsuarioController;
using Microsoft.AspNetCore.Mvc;

using EspacioTablero;
using EspacioTableroRepository;
using Microsoft.AspNetCore.DataProtection.Repositories;

[ApiController]
[Route("[controller]")]
public class TableroController : ControllerBase
{
    private readonly ILogger<TableroController> _logger;
    Tablero tablero;

    public TableroController(ILogger<TableroController> logger)
    {
        _logger = logger;
        //Usuario usuario = new Usuario();
    }

    [HttpGet(Name = "Nombre Tablero")]
    public ActionResult<string> GetNombreUsuario(){
        if (tablero!=null)
      {
        return Ok(tablero.Nombre);
      }else
      {
        return NotFound("No existe un tablero");
      }
    }

    [HttpGet]
    [Route("ListarTableros")]
    public ActionResult<List<Tablero>> GetTabelros(){
        TablerosRepository repo = new TablerosRepository();
        return Ok(repo.GetAll());
    }

    [HttpPut]
    [Route("AgregarTablero")]
    public ActionResult<List<Tablero>> AddTablero(Tablero newTablero){
        TablerosRepository repo = new TablerosRepository();
        repo.Create(newTablero);
        return Ok(repo.GetAll());
    }

}