using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using EspacioTablero;
using EspacioUsuario;
using System.Data.Entity.Migrations.Model;

namespace EspacioTableroRepository{
    public class TablerosRepository : ITablerosRepository
    {
        private string cadenaConexion = "Data Source=C:/Taller_2/tl2-tp09-2023-AndyRR2/Tp8/kamban.db;Cache=Shared";
        public List<Tablero> GetAll(){
            var queryString = @"SELECT * FROM Tablero;";
            List<Tablero> tableros = new List<Tablero>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection);
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tablero = new Tablero();
                        tablero.Id = Convert.ToInt32(reader["id"]);
                        tablero.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                        tablero.Nombre = reader["nombre"].ToString();
                        tablero.Descripcion = reader["descripcion"].ToString();
                        tableros.Add(tablero);
                    }
                }
                connection.Close();
            }
            return tableros;
        }
        public Tablero Create(Tablero newTablero){
            var query = $"INSERT INTO Tablero (id, id_usuario_propietario,nombre,descripcion) VALUES (@Id,@IdPropietario,@name,@descrip)";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);

                command.Parameters.Add(new SQLiteParameter("@Id", newTablero.Id));
                command.Parameters.Add(new SQLiteParameter("@IdPropietario", newTablero.IdUsuarioPropietario));
                command.Parameters.Add(new SQLiteParameter("@name", newTablero.Nombre));
                command.Parameters.Add(new SQLiteParameter("@descrip", newTablero.Descripcion));
                command.ExecuteNonQuery();

                connection.Close();   
            }
            return(newTablero);
        }
    }
}