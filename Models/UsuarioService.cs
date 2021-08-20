using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Biblioteca.Models
{
    public class UsuarioService
    {
        public List<Usuario> Listar()
        {
            using(BibliotecaContext BC = new BibliotecaContext())
            {
                return BC.Usuarios.ToList();
            }
        }

        public Usuario Listar(int id)
        {
            using(BibliotecaContext BC = new BibliotecaContext())
            {
                return BC.Usuarios.Find(id);
            }
        }

        public void incluirUsuario(Usuario novoUsuario)
        {
            using(BibliotecaContext BC = new BibliotecaContext())
            {
                BC.Add(novoUsuario);
                BC.SaveChanges();               
            }
        }

        public void editarUsuario(Usuario userEditado)
        {
            using(BibliotecaContext BC = new BibliotecaContext())
            {
                Usuario user = BC.Usuarios.Find(userEditado.Id);

                user.Nome = userEditado.Nome;
                user.Login = userEditado.Login;
                user.Senha = userEditado.Senha;
                user.Tipo = userEditado.Tipo;

                BC.SaveChanges();
            }
        }

        public void excluirUsuario(int id)
        {
            using(BibliotecaContext BC = new BibliotecaContext())
            {
                BC.Usuarios.Remove(BC.Usuarios.Find(id));
                BC.SaveChanges();
            }
        }
    }
}