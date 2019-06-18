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
    public partial class Registo : Form
    {
        private static string _connectionString = "Server=127.0.0.1;Database=mydb2;Uid=root;Pwd=;";
        private static MySqlConnection db = new MySqlConnection(_connectionString);

        public Registo()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Welcome f1 = new Welcome();
            f1.Owner = this;
            this.Hide();
            f1.ShowDialog();
            this.Dispose();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string query;
            string nome = textBox1.Text;
            string pass = textBox3.Text;
            string email = textBox2.Text;

            MySqlConnection db = new MySqlConnection(Properties.Settings.Default.ConnectionString);
            db.Open();

            try
            {
                query = "INSERT INTO InfoUtilizador (Username, Password, Email) VALUES (@nome, @Pass, @email)";
                MySqlCommand comando = new MySqlCommand(query, db);
                comando.CommandText = query;
                comando.Parameters.Add("@nome", MySqlDbType.String).Value = nome;
                comando.Parameters.Add("@Pass", MySqlDbType.String).Value = pass;
                comando.Parameters.Add("@email", MySqlDbType.String).Value = email;
                comando.ExecuteNonQuery();

                login entrar = new login();
                this.Hide();
                entrar.ShowDialog();
                this.Dispose();
                
            }

            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
            this.Close();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
