namespace EspacioTablero;

public class Tablero{
    private int id;
    private int idUsuarioPropietario;
    private string? nombre;
    private string? descripcion;   

    public int Id { get => id; set => id = value; }
    public int IdUsuarioPropietario { get => idUsuarioPropietario; set => idUsuarioPropietario = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }

    public Tablero(){
        
    }
    public Tablero(int Id, int IdUsuarioPropietario, string? Nombre, string? Descripcion){
        id=Id;
        idUsuarioPropietario = IdUsuarioPropietario;
        nombre=Nombre;
        descripcion=Descripcion;
    }
    
}