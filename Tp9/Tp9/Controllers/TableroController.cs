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
    }

    [HttpGet("api/tablero")]
    //[Route("ListarTableros")]
    public ActionResult<List<Tablero>> GetTabelros(){
        TablerosRepository repo = new TablerosRepository();
        return Ok(repo.GetAll());
    }

    [HttpPost("api/tablero")]
    //[Route("AgregarTablero")]
    public ActionResult<List<Tablero>> AddTablero(Tablero newTablero){
        TablerosRepository repo = new TablerosRepository();
        repo.Create(newTablero);
        return Ok(repo.GetAll());
    }

    [HttpGet("api/tablero/{Id}")]
    //[Route("TableroPorID")]
    public ActionResult<Tablero> GetTableroID(int Id){
        TablerosRepository repo = new TablerosRepository();
        return Ok(repo.GetById(Id));
    }

    [HttpPut("api/tablero/{Id}/nombre")]
    //[Route("UpdateTablero")]
    public ActionResult<List<Tablero>> UpdateTablero(Tablero tablero){
        TablerosRepository repo = new TablerosRepository();
        repo.Update(tablero);
        return Ok(repo.GetAll());
    }

    [HttpDelete("api/tablero/{Id}")]
    //[Route("DeleteTablero")]
    public ActionResult<List<Tablero>> DeleteTableroID(int Id){
        TablerosRepository repo = new TablerosRepository();
        repo.Remove(Id);
        return Ok(repo.GetAll());
    }

    [HttpGet/*("api/tablero/{Id}")*/]
    [Route("ListaDeTablerosIdPropietario")]
    public ActionResult<Tablero> GetTablerosDeUsuario(int Id){
        TablerosRepository repo = new TablerosRepository();
        return Ok(repo.GetListaTableros(Id));
    }

}