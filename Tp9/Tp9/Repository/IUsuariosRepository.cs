using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EspacioUsuario;

namespace EspacioUsuarioRepository{
public interface IUsuariosRepository
{
    public List<Usuario> GetAll();
    public void Create(Usuario usuario);
    public Usuario GetById(int Id);
    public void Remove(int Id);
    public void Update(Usuario usuario);
}
}
