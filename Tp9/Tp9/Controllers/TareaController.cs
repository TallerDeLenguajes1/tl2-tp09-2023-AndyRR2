namespace EspacioUsuarioController;
using Microsoft.AspNetCore.Mvc;

using EspacioTarea;
using EspacioTareaRepository;
using Microsoft.AspNetCore.DataProtection.Repositories;

[ApiController]
[Route("[controller]")]
public class TareaController : ControllerBase
{
    private readonly ILogger<TareaController> _logger;
    Tarea tarea;

    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
    }

    [HttpPost("api/tarea")]
    public ActionResult<List<Tarea>> AddTarea(Tarea newTarea){
        TareasRepository repo = new TareasRepository();
        repo.Create(newTarea);
        return Ok(newTarea);
    }

    [HttpGet("api/tarea/tablero/{Id}")]
    public ActionResult<Tarea> GetTareasDeTablero(int Id){
        TareasRepository repo = new TareasRepository();
        return Ok(repo.GetTareasDeTablero(Id));
    }
    [HttpGet("api/tarea/usuario/{Id}")]
    public ActionResult<Tarea> GetTareasDeUsuario(int Id){
        TareasRepository repo = new TareasRepository();
        return Ok(repo.GetTareasDeUsuario(Id));
    }
    [HttpGet("api/tarea/{estado}")]
    public ActionResult<Tarea> ContarTareasEstado(int estado){
        TareasRepository repo = new TareasRepository();
        return Ok(repo.ContarTareasEstado(estado));
    }

    [HttpDelete("api/Tarea/{Id}")]
    public ActionResult<Tarea> Delete(int Id){
        TareasRepository repo = new TareasRepository();
        repo.Remove(Id);
        return Ok();
    }

    [HttpPut("api/Tarea/tarea")]
    public ActionResult<Tarea> Update(Tarea tarea){
        TareasRepository repo = new TareasRepository();
        repo.Update(tarea);
        return Ok();
    }
}