using System;
using System.Data;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            F f = new F();
            f.textBox2.Text =dataGridView1.CurrentRow.Cells[1].Value.ToString();
            f.textBox3.Text =dataGridView1.CurrentRow.Cells[2].Value.ToString();
            f.textBox4.Text =dataGridView1.CurrentRow.Cells[3].Value.ToString();
            f.textBox5.Text =dataGridView1.CurrentRow.Cells[4].Value.ToString();
            f.textBox6.Text =dataGridView1.CurrentRow.Cells[5].Value.ToString();

            
            f.ShowDialog();
            this.Close();
          


        }


        private void f_UpdateEventHandler(object sender, Ajout_d_un_nouveau_client.UpdateEventArgs args)
        {
            dataGridView1.DataSource = getAllClient();
        }
        private void Client_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = getAllClient();

        }

        public DataTable getAllClient()
        {
            Connexion conn = new Connexion();
          
            DataTable tableCde = new DataTable();
            MySqlCommand commnand = new MySqlCommand("select * from client", conn.getConnection());
            MySqlDataAdapter adapterCde = new MySqlDataAdapter();
            
            adapterCde.SelectCommand = commnand;
            adapterCde.Fill(tableCde);
            dataGridView1.DataSource = tableCde;
            return tableCde;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            F f = new F();
           
            f.textBox3.Text =dataGridView1.CurrentRow.Cells[1].Value.ToString();
            f.textBox4.Text =dataGridView1.CurrentRow.Cells[2].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ajout_d_un_nouveau_client ajoutDUnNouveauClient = new Ajout_d_un_nouveau_client();
            ajoutDUnNouveauClient.UpdateEventHandler += f_UpdateEventHandler;
            ajoutDUnNouveauClient.ShowDialog();
            
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}