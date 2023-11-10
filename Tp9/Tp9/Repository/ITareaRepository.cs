using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EspacioTarea;
using EspacioUsuario;


namespace EspacioTareaRepository{
public interface ITareasRepository
{
    public Tarea Create(Tarea newTarea);
    public List<Tarea> GetTareasDeTablero(int Id);
    public List<Tarea> GetTareasDeUsuario(int Id);
    public void Remove(int Id);
    public void Update(Tarea tarea);
}
}