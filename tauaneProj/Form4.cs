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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private void UpdateListView()
        {
            listView1.Items.Clear();

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            List<Usuario> usuarios = usuarioDAO.SelectUsuario1();

            foreach (Usuario usuario in usuarios)
            {
                ListViewItem item = new ListViewItem(usuario.Id.ToString());
                item.SubItems.Add(usuario.rua);
                item.SubItems.Add(usuario.Bairro);
                item.SubItems.Add(usuario.Numero);
                listView1.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario("Rua", "Bairro", "Numero", "CEP");
            usuario.rua = textBox1.Text;
            usuario.Bairro = textBox2.Text;
            usuario.Numero = textBox3.Text;


            UsuarioDAO usuarioDAO = new UsuarioDAO();
            textBox1.Clear();
            usuarioDAO.InsertUsuario1(usuario);
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();

            UpdateListView();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario("Rua", "Bairro", "Numero", "CEP");
            usuario.Id = int.Parse(textBox5.Text);
            usuario.rua = textBox1.Text;
            usuario.Bairro = textBox2.Text;
            usuario.Numero = textBox3.Text;


            UsuarioDAO usuarioDAO = new UsuarioDAO();
            textBox1.Clear();
            usuarioDAO.UpdateUsuario1(usuario);
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();

            UpdateListView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario("Rua", "Bairro", "Numero", "CEP");
            usuario.Id = int.Parse(textBox5.Text);

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.DeleteUsuario1(usuario.Id);
            textBox1.Clear();
            textBox3.Clear();

            UpdateListView();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int index;
            index = listView1.FocusedItem.Index;
            textBox1.Text = (listView1.Items[index].SubItems[1].Text);
            textBox2.Text = (listView1.Items[index].SubItems[2].Text);
            textBox3.Text = listView1.Items[index].SubItems[3].Text;
            textBox5.Text = listView1.Items[index].SubItems[0].Text;
        }
    }
}
