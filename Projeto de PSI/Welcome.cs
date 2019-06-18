using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Projeto_de_PSI
{
    public partial class Welcome : Form
    {
        private static string _connectionString = "Server=127.0.0.1;Database=dbProjeto;Uid=root;Pwd=diogolourenco;";
        private static MySqlConnection db = new MySqlConnection(_connectionString);

        public Welcome()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            login log = new login();
            log.Owner = this;
            this.Hide();
            log.ShowDialog();
            this.Dispose();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Registo Reg = new Registo();
            Reg.Owner = this;
            this.Hide();
            Reg.ShowDialog();
            this.Dispose();
        }
    }
}
