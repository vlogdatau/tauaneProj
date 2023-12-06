using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace tauaneProj
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void UpdateListView()
        {
            listView1.Items.Clear();

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            List<Usuario> usuarios = usuarioDAO.SelectUsuario();

            foreach (Usuario usuario in usuarios)
            {
                ListViewItem item = new ListViewItem(usuario.Id.ToString());
                item.SubItems.Add(usuario.Nome);
                item.SubItems.Add(usuario.Email);
                item.SubItems.Add(usuario.telefone);
                item.SubItems.Add(usuario.senha);
                listView1.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {

                if (textBox1.Text.Length < 4)
                {
                    MessageBox.Show("O campo Nome deve ter pelo menos 4 caracteres.");
                }
                else if (textBox2.Text.Length < 11)
                {
                    MessageBox.Show("O campo Email deve ter pelo menos 11 caracteres.");
                }
                else if (textBox3.Text.Length < 4)
                {
                    MessageBox.Show("O campo Senha deve ter pelo menos 4 caracteres.");
                }
                else
                {
                    Usuario usuario = new Usuario("Nome", "Email", "Telefone", "Senha");
                    usuario.Nome = textBox1.Text;
                    usuario.Email = textBox2.Text;
                    usuario.telefone = textBox4.Text;
                    usuario.senha = Criptografia.CriptografarSenha(textBox3.Text);

                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    usuarioDAO.InsertUsuario(usuario);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();

                    UpdateListView();
                }
            }
            else
            {
                MessageBox.Show("Aceite os termos e condicões");
            }
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario("Nome", "Email", "Telefone", "Senha");
            usuario.Id = int.Parse(textBox5.Text);
            usuario.Nome = textBox1.Text;
            usuario.Email = textBox2.Text;
            usuario.telefone = textBox4.Text;
            usuario.senha = Criptografia.CriptografarSenha(textBox3.Text);

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.UpdateUsuario(usuario);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

            UpdateListView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox5.Text);
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.DeletUsuario(id);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            UpdateListView();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int index;
            index = listView1.FocusedItem.Index;
            textBox1.Text = (listView1.Items[index].SubItems[1].Text);
            textBox2.Text = (listView1.Items[index].SubItems[2].Text);
            textBox3.Text = listView1.Items[index].SubItems[4].Text;
            textBox4.Text = listView1.Items[index].SubItems[3].Text;
            textBox5.Text = listView1.Items[index].SubItems[0].Text;
        }
    }
}
