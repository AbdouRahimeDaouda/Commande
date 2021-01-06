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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        DataTable tableCde = new DataTable();
        DataTable tableLine = new DataTable();
       

        public Form1()
        
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Connexion conn = new Connexion();
          
            MySqlCommand commnand = new MySqlCommand("select NumCmd as 'RefCommande', DateCommande as 'Date', Nom as 'Nom' from commande d, client c where c.NumCleint=d.NumClient", conn.getConnection());
            MySqlCommand ligne = new MySqlCommand("select p.Designation as 'Produit', l.Qte as  'Quantite', l.Prix as  'Prix' from produit p, lignecommande l where p.CodeProduit=l.CodeProduit", conn.getConnection());
            MySqlDataAdapter adapterCde = new MySqlDataAdapter();
            MySqlDataAdapter adapterLine = new MySqlDataAdapter();
            
            adapterCde.SelectCommand = commnand;
            adapterLine.SelectCommand = ligne;
            adapterCde.Fill(tableCde);
            adapterLine.Fill(tableLine);
            commandeTab.DataSource = tableCde;
            ligneCdeTab.DataSource = tableLine;
            

          
        }

       

      


        private void clientRech(object sender, EventArgs e)
        {
            DataView dv = new DataView(tableCde);
            dv.RowFilter = string.Format("Nom LIKE '%{0}%'", checkClient.Text);
            commandeTab.DataSource = dv;
        }

        

       private void infoClient(object sender, EventArgs e)
        {
            Connexion conn = new Connexion();
            conn.openConnection();
            MySqlCommand commnand = new MySqlCommand("SELECT Rue, Ville, CP, Tel FROM `client` where Nom=@Nom", conn.getConnection());
            commnand.Parameters.AddWithValue("@Nom", textBox6.Text);
            MySqlDataReader dataReader = commnand.ExecuteReader();
            while (dataReader.Read())

            {
                textBox7.Text = dataReader.GetValue(0).ToString();
                textBox8.Text = dataReader.GetValue(1).ToString();
                textBox9.Text = dataReader.GetValue(2).ToString();
                textBox10.Text = dataReader.GetValue(3).ToString();
            }
            conn.closeConnection();


        }

        private void commandeTab_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

       

        private void cdeTab(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Text = commandeTab.CurrentRow.Cells[2].Value.ToString();
            Connexion conn = new Connexion();
            conn.openConnection();
            MySqlCommand commnand = new MySqlCommand("select p.Designation as 'Produit', l.Qte as  'Quantite', l.Prix as  'Prix' from produit p, lignecommande l, client c, commande d where (p.CodeProduit=l.CodeProduit and c.NumCleint=d.NumClient and d.NumCmd=l.NumCmd and  c.Nom=@Nom)", conn.getConnection());
            commnand.Parameters.AddWithValue("@Nom", textBox6.Text);
        }

        private void refCde(object sender, EventArgs e)
        {
            commandeTab.DataSource = PopulateDataGridView();

        }

      
        private DataTable PopulateDataGridView()
        {
            Connexion conn = new Connexion();
            conn.openConnection();
            string query = "select NumCmd as 'RefCommande', DateCommande as 'Date', Nom as 'Nom' from commande d, client c";
            query += " where c.NumCleint=d.NumClient and NumCmd = '%' + @value + '%'";
            query += " OR @value = ''";
            
                
                MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
                
                    cmd.Parameters.AddWithValue("@value", textBox11.Text.Trim());
                    MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                    
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    
                
            }

        private void button1_Click_1(object sender, EventArgs e)
        {
            F f2 = new F(); 
            f2.ShowDialog();
        }
    }
}