namespace EspacioTarea;

public enum EstadoTarea{
  Ideas, 
  ToDo, 
  Doing, 
  Review, 
  Done
}
public class Tarea{
    private int id;
    private int idTablero;
    private string? nombre;
    private int estado;
    private string? descripcion;
    private string? color;
    private int? idUsuarioAsignado;
   
    public int Id { get => id; set => id = value; }
    public int IdTablero { get => idTablero; set => idTablero = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    public string? Color { get => color; set => color = value; }
    public int Estado { get => estado; set => estado = value; }
    public int? IdUsuarioAsignado { get => idUsuarioAsignado; set => idUsuarioAsignado = value; }

    public Tarea(){

    }

    public Tarea(int Id, int IdTablero, string? Nombre, string? Descripcion, string? Color, int Estado, int IdUsuario){
      id=Id;
      idTablero=IdTablero;
      nombre=Nombre;
      descripcion=Descripcion;
      color=Color;
      estado=Estado;
      idUsuarioAsignado=IdUsuario;
    }

}