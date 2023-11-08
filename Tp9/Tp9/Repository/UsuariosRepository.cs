using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using EspacioUsuario;

namespace EspacioRepository{
    public class UsuariosRepository : IUsuariosRepository
    {
        private List<Usuario> listaDeUsuarios = new List<Usuario>();
        public List<Usuario> ListaDeUsuarios { get => listaDeUsuarios; set => listaDeUsuarios = value; }
        private string cadenaConexion = "Data Source=C:/Taller_2/Tp8/kamban.db;Cache=Shared";
        public List<Usuario> GetAll(){
            var queryString = @"SELECT * FROM Usuario;";
            List<Usuario> usuarios = new List<Usuario>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection);
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(reader["id"]);
                        usuario.Nombre = reader["nombre_de_usuario"].ToString();
                        usuarios.Add(usuario);
                    }
                }
                connection.Close();
                ListaDeUsuarios = usuarios;
            }
            return usuarios;
        }

        public void Create(Usuario usuario){
            string? name=usuario.Nombre;
            int ID=usuario.Id;
            var query = $"INSERT INTO Usuario (id, nombre_de_usuario) VALUES (@Id,@name)";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);

                command.Parameters.Add(new SQLiteParameter("@name", usuario.Nombre));
                command.Parameters.Add(new SQLiteParameter("@Id", usuario.Id));
                command.ExecuteNonQuery();

                connection.Close();   
            }
        }
        /*public Usuario GetById(int id){

        }
        public void Remove(int id){

        }
        public void Update(Usuario usuario){

        }*/
    }
}