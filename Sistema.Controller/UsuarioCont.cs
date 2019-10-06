using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Entity;

namespace Sistema.Controller
{
    public class UsuarioCont
    {
        public int Inserir(UsuarioEnt objetoTabela)
        {
            //criação do objeto que conecta com o DB
            using (SqlConnection conexao = new SqlConnection())
            {   
                //objeto do tipo conexao, sendo atribuido para ele valores retirado do XML app.config, INDISPENSAVEL para conexão
                conexao.ConnectionString = Properties.Settings.Default.banco;

                //para usar os SQL COMAND 
                SqlCommand comand = new SqlCommand();
                comand.CommandType = CommandType.Text;
                comand.CommandText = "INSERT INTO usuarios ([nome],[usuario]) VALUES (@nome,@usuario)";

                //inicializa conexão
                conexao.Open();

                //referencias para inserção
                comand.Parameters.Add("nome", SqlDbType.VarChar).Value = objetoTabela.Nome;//OBJETO que foi inseido na VIEW levando para MODEL e depois CONTROLLER
                comand.Parameters.Add("usuario", SqlDbType.VarChar).Value = objetoTabela.Usuario;
               

                //associar o comand a uma conexão
                comand.Connection = conexao;

                int qtd = comand.ExecuteNonQuery(); //retorno de validação recebimento de valor 0 = NÃO e 1 = SIM
                Console.Write("qtd");
                return qtd;//retorna a função para ser validado na camada VIEW
            }
        }

        public int Editar(UsuarioEnt objetoTabela)
        {
            using (SqlConnection conexao = new SqlConnection())
            {
                //objeto do tipo conexao, sendo atribuido para ele valores retirado do XML app.config, INDISPENSAVEL para conexão
                conexao.ConnectionString = Properties.Settings.Default.banco;

                //para usar os SQL COMAND 
                SqlCommand comand = new SqlCommand();
                comand.CommandType = CommandType.Text;
                comand.CommandText = "UPDATE usuarios SET nome = @nome,usuario = @usuario where id = @id";

                //inicializa conexão
                conexao.Open();

                //referencias para inserção
                comand.Parameters.Add("nome", SqlDbType.VarChar).Value = objetoTabela.Nome;//OBJETO que foi inseido na VIEW levando para MODEL e depois CONTROLLER
                comand.Parameters.Add("usuario", SqlDbType.VarChar).Value = objetoTabela.Usuario;
                comand.Parameters.Add("id", SqlDbType.Int).Value = objetoTabela.Id;

                //associar o comand a uma conexão
                comand.Connection = conexao;

                int qtd = comand.ExecuteNonQuery(); //retorno de validação recebimento de valor 0 = NÃO e 1 = SIM
                Console.Write("qtd");
                return qtd;//retorna a função para ser validado na camada VIEW
            }
        }

        public int Exluir(UsuarioEnt objetoTabela)
        {
            using (SqlConnection conexao = new SqlConnection())
            {
                //objeto do tipo conexao, sendo atribuido para ele valores retirado do XML app.config, INDISPENSAVEL para conexão
                conexao.ConnectionString = Properties.Settings.Default.banco;

                //para usar os SQL COMAND 
                SqlCommand comand = new SqlCommand();
                comand.CommandType = CommandType.Text;
                comand.CommandText = "DELETE from usuarios where id= @id";

                //inicializa conexão
                conexao.Open();

                //referencias para inserção
                comand.Parameters.Add("id", SqlDbType.Int).Value = objetoTabela.Id;

                //associar o comand a uma conexão
                comand.Connection = conexao;

                int qtd = comand.ExecuteNonQuery(); //retorno de validação recebimento de valor 0 = NÃO e 1 = SIM
                Console.Write("qtd");
                return qtd;//retorna a função para ser validado na camada VIEW
            }

        }

        public UsuarioEnt Login(UsuarioEnt obj)
        {
            using (SqlConnection conexao = new SqlConnection())
            {
                //objeto do tipo conexao, sendo atribuido para ele valores retirado do XML app.config, INDISPENSAVEL para conexão
                conexao.ConnectionString = Properties.Settings.Default.banco;

                //para usar os SQL COMAND 
                SqlCommand comand = new SqlCommand();
                comand.CommandType = CommandType.Text;
                comand.CommandText = "SELECT * from usuarios where usuario = @usuario AND senha = @senha";

                //inicializa conexão
                conexao.Open();

                //PRECISA DE PARAMETROS PARA WHERE
                //referencias para inserção
               
                comand.Parameters.Add("usuario", SqlDbType.VarChar).Value = obj.Usuario;
                comand.Parameters.Add("senha", SqlDbType.VarChar).Value = obj.Senha;



                comand.Connection = conexao;

                SqlDataReader dr;
                //NAO PRECISA EXIBIR EM NENHUM LOCAL
                //List<UsuarioEnt> lista = new List<UsuarioEnt>();

                dr = comand.ExecuteReader();


                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UsuarioEnt dado = new UsuarioEnt();

                        dado.Usuario = Convert.ToString(dr["usuario"]);
                        dado.Senha = Convert.ToString(dr["senha"]);

                    }
                }
                else 
                {
                    obj.Usuario = null;
                    obj.Senha = null;
                }
                return obj;
            }
        }

        public List<UsuarioEnt> Lista()
        {   //mesmo comando USING acima , poren com um SELEC e não um INSERT
            using (SqlConnection conexao = new SqlConnection())
            {
                //objeto do tipo conexao, sendo atribuido para ele valores retirado do XML app.config, INDISPENSAVEL para conexão
                conexao.ConnectionString = Properties.Settings.Default.banco;

                //para usar os SQL COMAND 
                SqlCommand comand = new SqlCommand();
                comand.CommandType = CommandType.Text;
                comand.CommandText = "SELECT * from usuarios ORDER BY id DESC";

                //inicializa conexão
                conexao.Open();

                //NAO PRECISA DE PARAMETROS PARA UM SELECT
           
                comand.Connection = conexao;

                SqlDataReader dr;
                List<UsuarioEnt> lista = new List<UsuarioEnt>();

                dr = comand.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UsuarioEnt dado = new UsuarioEnt();
                        dado.Id = Convert.ToInt32(dr["id"]);
                        dado.Nome = Convert.ToString(dr["nome"]);
                        dado.Usuario = Convert.ToString(dr["usuario"]);
                        

                        lista.Add(dado);
                    }
                }
                return lista;

            }
        }
    }
}
