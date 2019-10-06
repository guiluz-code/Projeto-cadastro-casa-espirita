using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Controller;
using Sistema.Entity;

namespace Sistema.Model
{
    public class UsuarioMod
    {
        public static int inserir(UsuarioEnt objetoTabela)
        {
            //função que conecta a MODEL com a CONTROLLER
            return new UsuarioCont().Inserir(objetoTabela);

        }

        public List<UsuarioEnt> Lista()
        {
            //função preeche GRID conecta a MODEL com a CONTROLLER
            return new UsuarioCont().Lista();
        }

        public UsuarioEnt Login(UsuarioEnt obj)
        {
            //função de login conecta MODEL com a CONTROLLER
            return new UsuarioCont().Login(obj);
        }

        public static int Excluir(UsuarioEnt objetoTabela)
        {
            return new UsuarioCont().Exluir(objetoTabela);
        }

        public static int Editar(UsuarioEnt objetoTabela)
        {
            return new UsuarioCont().Editar(objetoTabela);
        }
    }
}
