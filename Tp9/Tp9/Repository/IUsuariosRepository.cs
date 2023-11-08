using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EspacioUsuario;

namespace EspacioRepository{
public interface IUsuariosRepository
{
    public List<Usuario> GetAll();
    /*public Usuario GetById(int id);
    public void Create(Usuario usuario);
    public void Remove(int id);
    public void Update(Usuario usuario);*/
}
}
