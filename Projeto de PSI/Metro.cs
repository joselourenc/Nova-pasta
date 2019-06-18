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
    public partial class Metro : Form
    {
        private static string _connectionString = "Server=127.0.0.1;Database=mydb;Uid=root;Pwd=;";
        private static MySqlConnection db = new MySqlConnection(_connectionString);

        public Metro()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            login entrar = new login();
            entrar.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            buscarHorario(primeiraHora, segundaHora);
        }

        private double buscarHorario(DateTime primeiraHora, DateTime segundaHora)
        {
            MySqlDataReader busca;
            MySqlCommand comando = new MySqlCommand();
            comando.Connection = db;

            try
            {
                db.Open();

                primeiraHora = Convert.ToDateTime(comboBox4.Text);
                segundaHora = Convert.ToDateTime(comboBox5.Text);
                Partida = Convert.ToString(comboBox3.Text);

                comando.CommandText = "select id from autocarros where horario=@primeirahora";
                comando.Parameters.Add("@primeirahora", MySqlDbType.Datetime).Value = primeiraHora;

                Console.WriteLine("A primeira hora é:" + primeiraHora);

                comando.CommandText = "select id from autocarros where horario=@segundahora";
                comando.Parameters.Add("@segundahora", MySqlDbType.Datetime).Value = segundaHora;

                Console.WriteLine("A segunda hora é:" + segundaHora, Partida);

                busca = comando.ExecuteReader();

                if (busca.HasRows)
                {
                    busca.Read();
                    int id = busca.GetInt32(0);
                    return id;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro: {ex.Message}");
            }
            finally
            {
                if (db.State == System.Data.ConnectionState.Open)
                {
                    db.Close();
                    Console.WriteLine("Adeus!!!");
                }
            }

            return -1;
        }

        private DateTime primeiraHora;
        private DateTime segundaHora;
        private String Partida;

    }
}
