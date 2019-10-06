using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Model;
using Sistema.Entity;

namespace Sistema.View
{
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtUsuario.Text == "") 
                {
                    MessageBox.Show("Preencha o campo usuario");
                    txtUsuario.Focus();
                    return;
                }

                if (txtSenha.Text == "")
                {
                    MessageBox.Show("Preencha o campo Senha");
                    txtUsuario.Focus();
                    return;
                }

                if(txtSenha.Text != "admin1" && txtUsuario.Text != "admin")
                {
                    lblMensagem.Text = "Usuario ou senha invalidos";
                    lblMensagem.ForeColor = Color.Red;
                    return;
                }

                frmEndereco formulario = new frmEndereco();
                this.Hide();//ocultar form
                formulario.Show();
                //this.Close();//fechar form

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao logar"+ex.Message);
            }

           

        }
    }
}
