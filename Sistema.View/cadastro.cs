using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Model; //declara camada MODEL
using Sistema.Entity;//declara camada ENTITY

namespace Sistema.View
{
    public partial class frmEndereco : Form
    {
        //usuario que acessa atributos da camada ENTITY
        UsuarioEnt objetoTabela = new UsuarioEnt();


        public frmEndereco()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            opcoes = "Novo";
            iniciarOpcoes();
         
        }

        private string opcoes = "";

        private void iniciarOpcoes()
        {
            switch (opcoes)
            {
                case "Novo":
                    HabilitarCampos();
                    LimparCampos();
                    break;

                case "Salvar":
                    try
                    {
                        //atribuindo valores pegos dos textBox da VIEW para OBJ da ENTITY
                        objetoTabela.Nome    = txtNome.Text;
                        //objetoTabela.Senha   = txtSenha.Text;
                        objetoTabela.Usuario = txtUsuario.Text;

                        //função que passar dados para MODEL
                        int x = UsuarioMod.inserir(objetoTabela);

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Usuario {0} foi inserido!",txtNome.Text));
                        }
                        else 
                        {
                            MessageBox.Show("Não inserido!");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao salvar" + ex.Message);
                        
                    }
                    break;

                case "Excluir":
                    try
                    {
                        //atribuindo valores pegos dos textBox da VIEW para OBJ da ENTITY
                        objetoTabela.Id =Convert.ToInt32(txtCodigo.Text);
                      

                        //função que passar dados para MODEL
                        int x = UsuarioMod.Excluir(objetoTabela);

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Usuario {0} foi Excluido!", txtNome.Text));
                        }
                        else
                        {
                            MessageBox.Show("Não Excluido!");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao salvar" + ex.Message);

                    }
                    break;

                case "Editar":
                    try
                    {
                        //atribuindo valores pegos dos textBox da VIEW para OBJ da ENTITY
                        objetoTabela.Id = Convert.ToInt32(txtCodigo.Text);
                        objetoTabela.Nome = txtNome.Text;
                        //objetoTabela.Senha = txtSenha.Text;
                        objetoTabela.Usuario = txtUsuario.Text;

                        //função que passar dados para MODEL
                        int x = UsuarioMod.Editar(objetoTabela);

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Usuario {0} foi Editado!", txtNome.Text));
                        }
                        else
                        {
                            MessageBox.Show("Não Alterado");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao Editar" + ex.Message);

                    }
                    break;

                default:
                    break;
            }

        }

        private void HabilitarCampos() 
        {
            txtNome.Enabled = true;
            txtUsuario.Enabled = true;
            //txtSenha.Enabled = true;
        }

        private void DesabilitarCampos()
        {
            txtNome.Enabled = false;
            txtUsuario.Enabled = false;
            //txtSenha.Enabled = false;
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtUsuario.Text = "";
            //txtSenha.Text = "";
            txtCodigo.Text = "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            opcoes = "Salvar";
            iniciarOpcoes();
            ListarGrid();
            DesabilitarCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            opcoes = "Excluir";
            iniciarOpcoes();
            ListarGrid();
            DesabilitarCampos();
            LimparCampos();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            opcoes = "Editar";
            iniciarOpcoes();
            ListarGrid();
            DesabilitarCampos();
            LimparCampos();
        }

        //Função para trazer dados do DB para a GRID
        private void ListarGrid()
        {
            try
            {
                List<UsuarioEnt> lista = new List<UsuarioEnt>();//objeto do tipo lista que vem da camada ENTITY
                lista = new UsuarioMod().Lista();
                grid.AutoGenerateColumns = false;
                grid.DataSource = lista;//introduz dados da lista para a grid

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao listar Dados"+ex.Message);
            }
        
        }

        private void frmCadastro_Load(object sender, EventArgs e)
        {
            ListarGrid();
        }

        //função de clique na linha da GRID para imprimir nas txtBox
        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtUsuario.Text = grid.CurrentRow.Cells[2].Value.ToString();

            HabilitarCampos();
           
            
        }

    
    }
}
