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
    public partial class login : Form
    {
        private static string _connectionString = "Server=127.0.0.1;Database=mydb2;Uid=root;Pwd=;";
        private static MySqlConnection db = new MySqlConnection(_connectionString);


        public login()
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

            string nome = textBox1.Text;
            string pass = textBox2.Text;
            string query;


            MySqlConnection db = new MySqlConnection(Properties.Settings.Default.ConnectionString);
            db.Open();

            try
            {
                
                query = "SELECT Username, password FROM InfoUtilizador WHERE username = @nome AND password = @pass";

                MySqlCommand comando = new MySqlCommand(query, db);
                comando.CommandText = query;
                MySqlParameter uUsername = new MySqlParameter("@nome", MySqlDbType.String);
                MySqlParameter uPassword = new MySqlParameter("@pass", MySqlDbType.String);
                uUsername.Value = textBox1.Text;
                uPassword.Value = textBox2.Text;

                comando.Parameters.Add(uUsername);
                comando.Parameters.Add(uPassword);

                MySqlDataReader mydb = comando.ExecuteReader(CommandBehavior.CloseConnection);
                if(mydb.Read() == true)
                {
                    if (comboBox1.Text == "Autocarro")
                    {
                        Autocarro entrar = new Autocarro();
                        entrar.Owner = this;
                        this.Hide();
                        entrar.ShowDialog();
                        this.Dispose();
                    }
                    else if (comboBox1.Text == "Comboio")
                    {
                        Comboio entrar = new Comboio();
                        entrar.Owner = this;
                        this.Hide();
                        entrar.ShowDialog();
                        this.Dispose();
                    }
                    else if (comboBox1.Text == "Metro")
                    {
                        Metro entrar = new Metro();
                        entrar.Owner = this;
                        this.Hide();
                        entrar.ShowDialog();
                        this.Dispose();
                    }
                }
                else
                {
                    textBox1.Clear();
                    MessageBox.Show("tente de novo");
                }






            }
            catch (Exception k)
            {
                MessageBox.Show(k.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
