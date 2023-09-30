using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeliculasDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                string connectionstring = 
                    "Server=localhost;" +
                    "Database=PruebaDB;" +
                    "Trusted_Connection=True;" +
                    "TrustServerCertificate=true;";

                SqlConnection conn = new SqlConnection(connectionstring);

                string query = "SELECT TOP (1000) [Id],[Nombre],[Email],[Password],[NombreUsuario] FROM [PruebaDB].[dbo].[Usuarios]";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;

                conn.Open();

                DataTable data = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                conn.Close();

                dataGridView1.DataSource = data;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionstring =
                    "Server=localhost;" +
                    "Database=PruebaDB;" +
                    "Trusted_Connection=True;" +
                    "TrustServerCertificate=true;";

                SqlConnection conn = new SqlConnection(connectionstring);

                string query = $"UPDATE Usuarios SET Nombre = '{txtNombre.Text}' WHERE Id=2";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.Text;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
 
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
